using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Reviews;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens {
    class ReviewWriter {

        public static List<Review> CurrentReviewHolder = new List<Review>();
        public static bool MakingReview = false;

        public static void ToDisplay() {

            Program.display.ResizeDisplay(80, 14);
            if (!MakingReview) {
                DateTime TimeOfReview = DateTime.Now;
                CurrentReviewHolder.Add(new Review("Anoniem", new Date(TimeOfReview.Year, TimeOfReview.Month, TimeOfReview.Day, TimeOfReview.Hour, TimeOfReview.Minute), "empty", 10));
            }
            EditReview();
            Program.Reviewhandler.AddReview(CurrentReviewHolder[0]);
            Program.display.AddString(0, 0, $"{new string('=', 31)}Schrijf een Review{new string('=', 31)}");
            Program.display.AddString(0, 2, $"Jouw huidige review");
            Program.display.AddString(0, 4, $"Geschreven door: {CurrentReviewHolder[0].UserName}");
            Program.display.AddString(0, 6, $"Cijfer: {CurrentReviewHolder[0].Rating}/10");
            Program.display.AddString(0, 8, $"Beschrijving:");
            Program.display.AddString(0, 9, $"{CurrentReviewHolder[0].Description}");
            int nextPlus = 0;
            if (CurrentReviewHolder[0].Description.Length > 80) { nextPlus += (CurrentReviewHolder[0].Description.Length / 80); }
            Program.display.AddString(0, 11 + nextPlus, $"Geschreven op: {CurrentReviewHolder[0].ReviewDate.Day}/{CurrentReviewHolder[0].ReviewDate.Month}/{CurrentReviewHolder[0].ReviewDate.Year}");
            Program.display.AddString(0, 13, new string('=', 80));

            Program.display.AddControl(new Control("Terug", ScreenEnum.Reviews, false));

        }

        public static void EditReview() {

            Console.WriteLine("Geef een cijfer van 1 tot 10: ");
            string input = Console.ReadLine();
            int g = 0;
            if (Int32.TryParse(input, out int grade)) {
                if (grade < 0) { grade = 0; g = grade; }
                else if (grade > 10) { grade = 10; g = grade; }
                else {g = grade;}
            }
            Console.WriteLine("Geef een beschrijving: ");
            input = Console.ReadLine();

            CurrentReviewHolder[0].Rating = g;
            CurrentReviewHolder[0].Description = input;
        }
    }
}
