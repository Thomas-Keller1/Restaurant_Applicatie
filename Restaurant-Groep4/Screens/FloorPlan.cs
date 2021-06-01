using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;
using Restaurant_Groep4;

namespace Restaurant_Groep4.Screens {

    public static class FloorPlan {

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
            Program.display.AddString(0, 12, "■  ■■  ■  ■■■  ■■  ║  ║ <- 1, 2, 3, 4, 5");
            Program.display.AddString(0, 13, "▬  ▬▬  ▬  ▬▬▬  ▬▬  ║  ║");
            Program.display.AddString(0, 14, "                   ║  ║");
            Program.display.AddString(0, 15, " ▬  ▬  ▬▬  ▬  ▬▬▬  ║  ║");
            Program.display.AddString(0, 16, " ■  ■  ■■  ■  ■■■  ║  ║ <- 6, 7, 8, 9, 10");
            Program.display.AddString(0, 17, " ▬  ▬  ▬▬  ▬  ▬▬▬  ║  ║");
            Program.display.AddString(0, 18, "                   /  ║");
            Program.display.AddString(0, 19, "═/\\═════╗  ▬▬  ▬▬  ╠══╝");
            Program.display.AddString(0, 20, "        ║  ■■  ■■  ║ <- 11, 12");
            Program.display.AddString(0, 21, "        ║  ▬▬  ▬▬  ║");
            Program.display.AddString(0, 22, "        ║          ║");
            Program.display.AddString(0, 23, "        ║  ▬ ▬  ▬  ║");
            Program.display.AddString(0, 24, "        ║  ■ ■  ■  ║ <- 13, 14, 15");
            Program.display.AddString(0, 25, "        ║  ▬ ▬  ▬  ║");
            Program.display.AddString(0, 26, "════════╩══════════╝");
            Program.display.SetColor(0, 12, 1, Program.Reserveringhandler.Tables[0].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(3, 12, 5, Program.Reserveringhandler.Tables[1].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(7, 12, 8, Program.Reserveringhandler.Tables[2].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(10, 12, 13, Program.Reserveringhandler.Tables[3].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(15, 12, 17, Program.Reserveringhandler.Tables[4].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(0, 11, 1, Program.Reserveringhandler.Tables[0].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(3, 11, 5, Program.Reserveringhandler.Tables[1].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(7, 11, 8, Program.Reserveringhandler.Tables[2].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(10, 11, 13, Program.Reserveringhandler.Tables[3].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(15, 11, 17, Program.Reserveringhandler.Tables[4].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(0, 13, 1, Program.Reserveringhandler.Tables[0].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(3, 13, 5, Program.Reserveringhandler.Tables[1].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(7, 13, 8, Program.Reserveringhandler.Tables[2].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(10, 13, 13, Program.Reserveringhandler.Tables[3].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(15, 13, 17, Program.Reserveringhandler.Tables[4].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(1, 16, 2, Program.Reserveringhandler.Tables[5].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(4, 16, 5, Program.Reserveringhandler.Tables[6].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(7, 16, 9, Program.Reserveringhandler.Tables[7].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(10, 16, 12, Program.Reserveringhandler.Tables[8].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(14, 16, 17, Program.Reserveringhandler.Tables[9].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(1, 15, 2, Program.Reserveringhandler.Tables[5].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(4, 15, 5, Program.Reserveringhandler.Tables[6].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(7, 15, 9, Program.Reserveringhandler.Tables[7].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(10, 15, 12, Program.Reserveringhandler.Tables[8].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(14, 15, 17, Program.Reserveringhandler.Tables[9].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(1, 17, 2, Program.Reserveringhandler.Tables[5].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(4, 17, 5, Program.Reserveringhandler.Tables[6].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(7, 17, 9, Program.Reserveringhandler.Tables[7].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(10, 17, 12, Program.Reserveringhandler.Tables[8].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(14, 17, 17, Program.Reserveringhandler.Tables[9].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(11, 20, 13, Program.Reserveringhandler.Tables[10].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(15, 20, 17, Program.Reserveringhandler.Tables[11].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(11, 19, 13, Program.Reserveringhandler.Tables[10].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(15, 19, 17, Program.Reserveringhandler.Tables[11].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(11, 21, 13, Program.Reserveringhandler.Tables[10].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(15, 21, 17, Program.Reserveringhandler.Tables[11].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(11, 24, 12, Program.Reserveringhandler.Tables[12].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(13, 24, 14, Program.Reserveringhandler.Tables[13].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(16, 24, 17, Program.Reserveringhandler.Tables[14].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(11, 23, 12, Program.Reserveringhandler.Tables[12].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(13, 23, 14, Program.Reserveringhandler.Tables[13].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(16, 23, 17, Program.Reserveringhandler.Tables[14].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(11, 25, 12, Program.Reserveringhandler.Tables[12].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(13, 25, 14, Program.Reserveringhandler.Tables[13].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.SetColor(16, 25, 17, Program.Reserveringhandler.Tables[14].Available ? ConsoleColor.Green : ConsoleColor.Red);
            Program.display.AddString(0, 28, new string('=', 80));
        }
    }
}
