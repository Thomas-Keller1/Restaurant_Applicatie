using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;
using Restaurant_Groep4;

namespace Restaurant_Groep4.Screens {

    class FloorPlan {

        public static void ToDisplay() {

            Program.display.ResizeDisplay(80, 30);
            Program.display.AddString(0, 0, $"{new string('=', 36)}Legenda={new string('=', 36)}");
            Program.display.AddString(0, 2, "■ = Tafel");
            Program.display.AddString(0, 3, "▬ = stoel");
            Program.display.AddString(0, 4, "║ = muur");
            Program.display.AddString(0, 5, "/ or \\ = deur");
            Program.display.AddString(0, 6, "- = raam");
            Program.display.AddString(0, 8, new string('=', 80));
            Program.display.AddString(0, 10, "--═--══-══---══--══╦/\\╗");
            Program.display.AddString(0, 11, "▬  ▬▬  ▬  ▬▬▬  ▬▬  ║  ║");
            Program.display.AddString(0, 12, "■  ■■  ■  ■■■  ■■  ║  ║");
            Program.display.AddString(0, 13, "▬  ▬▬  ▬  ▬▬▬  ▬▬  ║  ║");
            Program.display.AddString(0, 14, "                   ║  ║");
            Program.display.AddString(0, 15, " ▬  ▬  ▬▬  ▬  ▬▬▬  ║  ║");
            Program.display.AddString(0, 16, " ■  ■  ■■  ■  ■■■  ║  ║");
            Program.display.AddString(0, 17, " ▬  ▬  ▬▬  ▬  ▬▬▬  ║  ║");
            Program.display.AddString(0, 18, "                   /  ║");
            Program.display.AddString(0, 19, "═/\\═════╗  ▬▬  ▬▬  ╠══╝");
            Program.display.AddString(0, 20, "        ║  ■■  ■■  ║");
            Program.display.AddString(0, 21, "        ║  ▬▬  ▬▬  ║");
            Program.display.AddString(0, 22, "        ║          ║");
            Program.display.AddString(0, 23, "        ║  ▬ ▬  ▬  ║");
            Program.display.AddString(0, 24, "        ║  ■ ■  ■  ║");
            Program.display.AddString(0, 25, "        ║  ▬ ▬  ▬  ║");
            Program.display.AddString(0, 26, "════════╩══════════╝");
            Program.display.AddString(0, 28, new string('=', 80));
        }
    }
}
