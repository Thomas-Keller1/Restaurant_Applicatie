using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Reviews;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens {
    public static class ReviewViewer {

        private static int OnPage = 1;
        private static int ReviewsPerPage = 5;
        private static int PageCount = CalculatePageCount();

        public static void ToDisplay() {

            Program.display.ResizeDisplay(80, LinesNeeded());
            int CurrentY = 0;
            int count = 0;
            int Rcount = 0;
            Program.display.AddString(0, CurrentY, $"{new string('=', 36)}Reviews={new string('=', 36)}");
            CurrentY++;
            Program.display.AddString(0, CurrentY, x => (x.Email == null ? $"Niet ingelogd!" : $"Ingelogd met account: {x.GebruikersNaam}"), ConsoleColor.White);
            CurrentY += 2;
            foreach (Review review in Program.Reviewhandler.Reviews) {
                if (count < (OnPage * ReviewsPerPage) && count >= ((OnPage - 1) * ReviewsPerPage)) {

                    Program.display.AddString(0, CurrentY, $"#{Rcount + 1}:");
                    CurrentY++;
                    Program.display.AddString(0, CurrentY, $"Geschreven door: {review.UserName}");
                    CurrentY += 2;
                    Program.display.AddString(0, CurrentY, $"Cijfer: {review.Rating}/10");
                    CurrentY += 2;
                    Program.display.AddString(0, CurrentY, $"Beschrijving:");
                    CurrentY++;
                    Program.display.AddString(0, CurrentY, $"{review.Description}");
                    if (review.Description.Length > 80) {CurrentY += (review.Description.Length / 80);} 
                    CurrentY += 2;
                    Program.display.AddString(0, CurrentY, $"Geschreven op: {review.ReviewDate.Day}/{review.ReviewDate.Month}/{review.ReviewDate.Year}");
                    CurrentY++;
                    Program.display.AddString(0, CurrentY, new string('-', 80));
                    CurrentY++;
                    Rcount++;
                }
                if (Rcount >= ReviewsPerPage) {break;}
                count++;
            }
            Program.display.AddString(0, CurrentY + 1, $"Pagina {OnPage} van de {PageCount}");
            Program.display.AddString(0, CurrentY + 2, new string('=', 80));
            Program.display.AddControl(new Control("Terug", ScreenEnum.Mainmenu, false));
            Program.display.AddControl(new Control("Review schrijven", ScreenEnum.WriteReview, false));
            if (OnPage > 1) {
                Program.display.AddControl(new Control("Vorige pagina", ScreenEnum.Mainmenu, true));
            }
            if (OnPage < PageCount) {
                Program.display.AddControl(new Control("Volgende pagina", ScreenEnum.Menus, true));
            }
            PageCount = CalculatePageCount();
        }

        private static int LinesNeeded() {

            int y = 2;
            int count = 0;
            int Rcount = 0;
            foreach (Review review in Program.Reviewhandler.Reviews) {
                if (count < (OnPage * ReviewsPerPage) && count >= ((OnPage - 1) * ReviewsPerPage)) {
                    y += 6;
                    if (review.Description.Length > 80) {y += (review.Description.Length / 80);}
                    y += 4;
                    Rcount++;
                }
                if (Rcount >= ReviewsPerPage) {break;}
                count++;
            }
            return y + 3;
        }

        private static int CalculatePageCount() {

            int count = Program.Reviewhandler.Reviews.Count / ReviewsPerPage;
            if (Program.Reviewhandler.Reviews.Count % ReviewsPerPage != 0) {count++;}

            return count;
        }

        public static void ModifyPrivateValue(int modifier) {
            OnPage += modifier;
        }
    }
}
