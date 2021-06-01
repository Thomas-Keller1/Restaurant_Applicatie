using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Reviews;
using Restaurant_Groep4.Screens;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.UnitTesting {

    class Reviews_testers {

        public static void GetReview_Test() {

            //Set test data.
            Random rand = new Random();

            int[] testindices = new int[30];//rand.Next(0, 20)];
            Review[] expectedresults = new Review[testindices.Length];

            for (int i = 0; i < testindices.Length; i++) {

                testindices[i] = rand.Next(0, 20);
                expectedresults[i] = testindices.Length == 0 ? new Review("None", new Date(0, 0, 0, 0, 0), "Empty", 0) : (testindices[i] + 1) > Program.Reviewhandler.Reviews.Count ? Program.Reviewhandler.Reviews[0] : Program.Reviewhandler.Reviews[testindices[i]];
            }

            //Get results
            Review[] results = new Review[testindices.Length];
            for (int i = 0; i < testindices.Length; i++) {

                results[i] = Program.Reviewhandler.GetReview(testindices[i]);
            }

            //Check if the data is correct

            int count = 0;
            int success = 0;
            int failures = 0;

            foreach (Review _result in results) {

                if (_result.UserName == expectedresults[count].UserName && _result.Description == expectedresults[count].Description && _result.Rating == expectedresults[count].Rating) {

                    Console.WriteLine($"Got expected review by {expectedresults[count].UserName} by using the index {testindices[count]}");
                    success++;
                }
                else {
                    Console.WriteLine($"Didn't get the expected review by {expectedresults[count].UserName} by using the index {testindices[count]}");
                    failures++;
                }
                count++;
            }
            Console.WriteLine($"\n\n Success percentage: {((float)success / results.Length) * 100.0f}% - Success/fail ratio: {success}/{failures}");
        }
    }
}
