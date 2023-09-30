using Cosmos.System;
using IL2CPU.API.Attribs;
using ProjectDMG.Utils;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Kernel = CrystalOS2.Kernel;

namespace ProjectDMG {
    public class ProjectDMG {

        [ManifestResourceStream(ResourceName = "CrystalOS2.Gameboy.4_in_1.gb")] public static byte[] game;
        [ManifestResourceStream(ResourceName = "CrystalOS2.Gameboy.Tetris.gb")] public static byte[] game1;
        [ManifestResourceStream(ResourceName = "CrystalOS2.Gameboy.Caesars_Palace.gb")] public static byte[] game2;
        [ManifestResourceStream(ResourceName = "CrystalOS2.Gameboy.Zelda.gb")] public static byte[] game3;
        [ManifestResourceStream(ResourceName = "CrystalOS2.Gameboy.Smurfs_Nightmare.gb")] public static byte[] game4;

        private CPU cpu;
        private MMU mmu;
        private PPU ppu;
        private TIMER timer;
        public JOYPAD joypad;

        public bool power_switch;

        public void POWER_ON() {
            mmu = new MMU();
            cpu = new CPU(mmu);
            ppu = new PPU();
            timer = new TIMER();
            joypad = new JOYPAD();

            if(Kernel.gamenum == 0)
            {
                mmu.loadGamePak(game);
            }
            else if (Kernel.gamenum == 1)
            {
                mmu.loadGamePak(game1);
            }
            else if (Kernel.gamenum == 2)
            {
                mmu.loadGamePak(game2);
            }
            else if (Kernel.gamenum == 3)
            {
                mmu.loadGamePak(game3);
            }
            else if (Kernel.gamenum == 4)
            {
                mmu.loadGamePak(game4);
            }

            power_switch = true;

            //Task t = Task.Factory.StartNew(EXECUTE, TaskCreationOptions.LongRunning);
        }

        public void POWER_OFF() {
            power_switch = false;
        }

        int cyclesThisUpdate = 0;
        int cpuCycles = 0;

        public void EXECUTE() {
            if (KeyboardManager.TryReadKey(out KeyEvent key))
            {
                joypad.handleKeyDown(key.Key);
            }

            while (cyclesThisUpdate < Constants.CYCLES_PER_UPDATE)
            {
                cpuCycles = cpu.Exe();
                cyclesThisUpdate += cpuCycles;

                timer.update(cpuCycles, mmu);
                ppu.update(cpuCycles, mmu);
                joypad.update(mmu);
                handleInterrupts();
            }
            cyclesThisUpdate -= Constants.CYCLES_PER_UPDATE;

            if (key != null)
            {
                joypad.handleKeyUp(key.Key);

                //key = null;
            }
        }

        private void handleInterrupts() {
            byte IE = mmu.IE;
            byte IF = mmu.IF;
            for (int i = 0; i < 5; i++) {
                if ((((IE & IF) >> i) & 0x1) == 1) {
                    cpu.ExecuteInterrupt(i);
                }
            }

            cpu.UpdateIME();
        }

    }
}
