﻿using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Reviews;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Screens {
    public static class ReviewWriter {

        public static List<Review> CurrentReviewHolder = new List<Review>();
        public static bool MakingReview = false;

        public static void ToDisplay() {

            Program.display.ResizeDisplay(80, 14);
            //if (!MakingReview) {
            //    DateTime TimeOfReview = DateTime.Now;
            //    CurrentReviewHolder.Add(new Review("Anonymous", new Date(TimeOfReview.Year, TimeOfReview.Month, TimeOfReview.Day, TimeOfReview.Hour, TimeOfReview.Minute), "empty", 10));
            //}
            EditReview();
            //Program.Reviewhandler.AddReview(CurrentReviewHolder[0]);
            Program.display.AddString(0, 0, $"{new string('=', 31)}Schrijf een Review{new string('=', 31)}");
            Program.display.AddString(0, 1, x => (x.Email == null ? $"Niet ingelogd!" : $"Ingelogd met account: {x.GebruikersNaam}"), ConsoleColor.White);
            Program.display.AddString(0, 3, $"Jouw huidige review");
            Program.display.AddString(0, 5, $"Geschreven door: {CurrentReviewHolder[0].UserName}");
            Program.display.AddString(0, 7, $"Cijfer: {CurrentReviewHolder[0].Rating}/10");
            Program.display.AddString(0, 9, $"Beschrijving:");
            Program.display.AddString(0, 10, $"{CurrentReviewHolder[0].Description}");
            int nextPlus = 0;
            if (CurrentReviewHolder[0].Description.Length > 80) { nextPlus += (CurrentReviewHolder[0].Description.Length / 80); }
            Program.display.AddString(0, 12 + nextPlus, $"Geschreven op: {CurrentReviewHolder[0].ReviewDate.Day}/{CurrentReviewHolder[0].ReviewDate.Month}/{CurrentReviewHolder[0].ReviewDate.Year}");
            Program.display.AddString(0, 14, new string('=', 80));

            Program.display.AddControl(new Control("Terug", ScreenEnum.Reviews, false));

        }

        public static void EditReview() {

            DateTime TimeOfReview = DateTime.Now;
            CurrentReviewHolder.Add(new Review(Program.CurrentAccount.Naam, new Date(TimeOfReview.Year, TimeOfReview.Month, TimeOfReview.Day, TimeOfReview.Hour, TimeOfReview.Minute), "leeg", 10));

            Console.WriteLine("Geef een cijfer van 1 tot 10: ");
            string input = Console.ReadLine();
            int g = 0;
            if (Int32.TryParse(input, out int grade)) {
                if (grade < 0) { grade = 1; g = grade; Console.WriteLine($"Jouw cijfer lag niet tussen de 1 en de 10 en is gewijzigd naar {g}"); }
                else if (grade > 10) { grade = 10; g = grade; Console.WriteLine($"Jouw cijfer lag niet tussen de 1 en de 10 en is gewijzigd naar {g}"); }
                else {g = grade;}
            }
            else {
                Console.WriteLine($"Jouw invoer is geen nummer! en is gewijzigd naar {g}");
            }
            Console.WriteLine("Geef een beschrijving: ");
            input = Console.ReadLine();

            //Console.WriteLine($"{g}, {input}");

            CurrentReviewHolder[0].Rating = g;
            CurrentReviewHolder[0].Description = input;

            Program.Reviewhandler.AddReview(CurrentReviewHolder[0]);
        }
    }
}
