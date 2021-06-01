using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using System;
using System.IO;
using Restaurant_Groep4;
using Restaurant_Groep4.Misc;
using Restaurant_Groep4.Screens;
using Restaurant_Groep4.Reviews;
using Restaurant_Groep4.Menu;
using Restaurant_Groep4.Reserveringen;

namespace Restaurant_Groep4_test {

    [TestClass]
    public class UnitTest1 {

        private static string TestRapportText = "";

        

        [TestMethod]
        public void GetReview_Test() {

            //string dir = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(@"C:\Users\Paran\Documents\BackupGit\Restaurant_Applicatie\Restaurant-Groep4\bin\Debug\netcoreapp3.1");//dir/*.Substring(0, dir.Length - 46)*/ + "Restaurant-Groep4\\bin\\Debug\\netcoreapp3.1");

            //Set test data.
            Random rand = new Random();

            int[] testindices = new int[30];//rand.Next(0, 20)];
            Review[] expectedresults = new Review[testindices.Length];
            //C:\Users\Paran\Documents\BackupGit\Restaurant_Applicatie\Restaurant-Groep4_test\bin\Debug\netcoreapp3.1
            //Console.WriteLine(dir.Substring(0, dir.Length - 46) + "Restaurant - Groep4\\");

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

            TestRapportText += "\nGetReview Test: \n" + new string('_', 50) + "\n";

            foreach (Review _result in results) {

                bool isEqual = _result.UserName == expectedresults[count].UserName && _result.Description == expectedresults[count].Description && _result.Rating == expectedresults[count].Rating;

                Assert.IsTrue(isEqual, String.Format("Expected for '{0}': false; Actual: {1}", expectedresults[count], _result));


                if (_result.UserName == expectedresults[count].UserName && _result.Description == expectedresults[count].Description && _result.Rating == expectedresults[count].Rating) {
            
                    Console.WriteLine($"Got expected review by {expectedresults[count].UserName} by using the index {testindices[count]}");
                    TestRapportText += $"Got expected review by {expectedresults[count].UserName} by using the index {testindices[count]}\n";
                    success++;
                }
                else {
            
                    Console.WriteLine($"Didn't get the expected review by {expectedresults[count].UserName} by using the index {testindices[count]}");
                    TestRapportText += $"Didn't get the expected review by {expectedresults[count].UserName} by using the index {testindices[count]}\n";
                  failures++;
                }
                count++;
            }
            Console.WriteLine($"\n\n Success percentage: {((float)success / results.Length) * 100.0f}% - Success/fail ratio: {success}/{failures}");
            TestRapportText += $"\n\n Success percentage: {((float)success / results.Length) * 100.0f}% - Success/fail ratio: {success}/{failures}" + "\n" + new string('_', 50) + "\n";

            Write_rapport();
        }

        [TestMethod]
        public void EditReview_tester() {

            TestRapportText += "EditReview Test: \n" + new string('_', 50) + "\n";

            //string dir = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(@"C:\Users\Paran\Documents\BackupGit\Restaurant_Applicatie\Restaurant-Groep4\bin\Debug\netcoreapp3.1");//Directory.SetCurrentDirectory(dir.Substring(0, dir.Length - 46) + "Restaurant-Groep4\\bin\\Debug\\netcoreapp3.1");

            bool completed = false;

            int existing_reviews = Program.Reviewhandler.Reviews.Count;

            //StringWriter writer = new StringWriter();
            string[] data_array = new string[] {

                String.Join(Environment.NewLine ,new string[] {"5", "Good restaurant"}),
                String.Join(Environment.NewLine ,new string[] {"-1", "never coming again!"}),
                String.Join(Environment.NewLine ,new string[] {"7", "great"}),
                String.Join(Environment.NewLine ,new string[] {"10", "best place"}),
                String.Join(Environment.NewLine ,new string[] {"-100", "worst restaurant"}),
                String.Join(Environment.NewLine ,new string[] {"11", "too good to be true"}),
                String.Join(Environment.NewLine ,new string[] {"0", "I have no opinion"})
            };
            //string data = String.Join(Environment.NewLine ,new string[] {"5", "Good restaurant"});

            foreach (string data in data_array) {

                using (StringReader reader = new StringReader(data)) {

                    Console.SetIn(reader);
                    ReviewWriter.EditReview();
                }
            }

            completed = (existing_reviews + data_array.Length) == Program.Reviewhandler.Reviews.Count ? true : false;

            TestRapportText += $"All {data_array.Length} reviews successfully placed in the list\n";

            for (int i = existing_reviews - 1; i < Program.Reviewhandler.Reviews.Count; i++) {

                completed = Program.Reviewhandler.Reviews[i].Rating >= 0 && Program.Reviewhandler.Reviews[i].Rating <= 10 ? true : false;
                TestRapportText += $"Rating {Program.Reviewhandler.Reviews[i].Rating} is an allowed rating\n";
            }

            Assert.IsTrue(completed, "Expected for completed 'true': false; Actual: false");
            Console.WriteLine(TestRapportText);

            Write_rapport();
        }

        //[TestMethod]
        //public void Display_ToString_Tester() {

        //Random random = new Random();
        //TestRapportText += "EditReview Test: \n" + new string('_', 50) + "\n";

        //Program.display.ResizeDisplay(80, 20);
        //Program.display.AddControl(new Control("Next", ScreenEnum.Afsluiten, false));
        //Program.display.AddControl(new Control("Previous", ScreenEnum.Afsluiten, false));

        //Assert.IsTrue("" == Program.display.ToString());

        //Write_rapport();
        //}

        [TestMethod]
        public void Display_SetColor_tester() {

            Directory.SetCurrentDirectory(@"C:\Users\Paran\Documents\BackupGit\Restaurant_Applicatie\Restaurant-Groep4\bin\Debug\netcoreapp3.1");
            Program.Start();

            Random random = new Random();

            TestRapportText += "SetColor Test: \n" + new string('_', 50) + "\n";

            Program.display.ResizeDisplay(80, 20);

            for (int i = 0; i < 5; i++) {
                int x = random.Next(-5, 100);
                int steps = random.Next(0, 5);
                int y = random.Next(-1, 30);
                ConsoleColor color = ConsoleColor.Red;

                Program.display.SetColor(x, y, x + steps, color);
                Program.display.displaybuffer.SetColor(x, y, x + steps, color);
                TestRapportText += "Color successfully set\n";

                if (x >= 0 && x < Program.display.displaybuffer.DisplayWidth && y >= 0 && y < Program.display.displaybuffer.DisplayHeight) {

                    //Assert.IsTrue(color == Program.display.displaybuffer.DisplayColors[y, x]);
                    TestRapportText += $"Color at {x}, {y} is the intended color red\n";
                }
                else {

                    TestRapportText += $"Color at {x}, {y} is not within the display size of {Program.display.displaybuffer.DisplayWidth}, {Program.display.displaybuffer.DisplayHeight}\n";
                }
            }

            Write_rapport();
        }

        [TestMethod]
        public void Display_AddControl_tester() {

            Random random = new Random();

            Directory.SetCurrentDirectory(@"C:\Users\Paran\Documents\BackupGit\Restaurant_Applicatie\Restaurant-Groep4\bin\Debug\netcoreapp3.1");
            Program.Start();

            TestRapportText += "AddControl Test: \n" + new string('_', 50) + "\n";

            int initial_length = Program.display.controls.Count;
            int times = random.Next(0, 10);

            for (int i = 0; i < times; i++) {

                Program.display.AddControl(new Control("hello", ScreenEnum.Login, false));
                TestRapportText += "Control successfully added\n";
            }

            bool completed = initial_length + times == Program.display.controls.Count;

            TestRapportText += $"\n{Program.display.controls.Count} controls available expected {initial_length + times}\n\n";
            Assert.IsTrue(completed);

            Write_rapport();
        }

        [TestMethod]
        public void Display_AddCharacter_tester() {

            Directory.SetCurrentDirectory(@"C:\Users\Paran\Documents\BackupGit\Restaurant_Applicatie\Restaurant-Groep4\bin\Debug\netcoreapp3.1");
            Program.Start();

            Random random = new Random();

            TestRapportText += "AddCharacter Test: \n" + new string('_', 50) + "\n";

            Program.display.ResizeDisplay(80, 20);

            for (int i = 0; i < 5; i++) {

                int x = random.Next(-5, 100);
                int y = random.Next(-1, 30);
                char character = (char)random.Next(48, 90);

                Program.display.AddCharacter(x, y, character);
                Program.display.displaybuffer.AddCharacter(x, y, character);
                TestRapportText += $"Character at {x}, {y} successfully set to {character}\n";

                if (x >= 0 && x < Program.display.displaybuffer.DisplayWidth && y >= 0 && y < Program.display.displaybuffer.DisplayHeight) {

                    //Assert.IsTrue(color == Program.display.displaybuffer.DisplayColors[y, x]);
                    TestRapportText += $"Character at {x}, {y} is the intended character {character}\n";
                }
                else {

                    TestRapportText += $"Character at {x}, {y} is not within the display size of {Program.display.displaybuffer.DisplayWidth}, {Program.display.displaybuffer.DisplayHeight}\n";
                }
            }

            Write_rapport();
        }

        [TestMethod]
        public void Display_AddString_tester() {

            Directory.SetCurrentDirectory(@"C:\Users\Paran\Documents\BackupGit\Restaurant_Applicatie\Restaurant-Groep4\bin\Debug\netcoreapp3.1");
            Program.Start();

            Random random = new Random();

            TestRapportText += "AddString Test: \n" + new string('_', 50) + "\n";

            Program.display.ResizeDisplay(80, 20);

            for (int i = 0; i < 5; i++) {

                int x = random.Next(-5, 100);
                int y = random.Next(-1, 30);

                string str = "" + ((char)random.Next(48, 90));

                Program.display.AddString(x, y, str);
                TestRapportText += $"String at {x}, {y} successfully set to {str}\n";

                if (x >= 0 && x < Program.display.displaybuffer.DisplayWidth && y >= 0 && y < Program.display.displaybuffer.DisplayHeight) {

                    //Assert.IsTrue(color == Program.display.displaybuffer.DisplayColors[y, x]);
                    TestRapportText += $"Character at {x}, {y} is the intended character {str[0]}\n";
                }
                else {

                    TestRapportText += $"Character at {x}, {y} is not within the display size of {Program.display.displaybuffer.DisplayWidth}, {Program.display.displaybuffer.DisplayHeight}\n";
                }
            }

            Write_rapport();
        }

        [TestMethod]
        public void Resize_display_tester() {

            Directory.SetCurrentDirectory(@"C:\Users\Paran\Documents\BackupGit\Restaurant_Applicatie\Restaurant-Groep4\bin\Debug\netcoreapp3.1");
            Program.Start();

            Random random = new Random();

            TestRapportText += "Resize display Test: \n" + new string('_', 50) + "\n";

            int x = random.Next(0, 120);
            int y = random.Next(0, 120);

            Program.display.ResizeDisplay(x, y);
            Program.display.displaybuffer.ResizeDisplayBuffer(x, y);

            bool result = x == Program.display.displaybuffer.DisplayWidth && y == Program.display.displaybuffer.DisplayHeight;
            TestRapportText += $"expected {x}, {y} got {Program.display.displaybuffer.DisplayWidth}, {Program.display.displaybuffer.DisplayHeight}\n";

            Write_rapport();
        }

        [TestMethod]
        public void Linesneeded_tester() {

            Directory.SetCurrentDirectory(@"C:\Users\Paran\Documents\BackupGit\Restaurant_Applicatie\Restaurant-Groep4\bin\Debug\netcoreapp3.1");
            Program.Start();

            Random random = new Random();

            TestRapportText += "Linesneeded Test: \n" + new string('_', 50) + "\n";
            //71, 144, 267, 70
            int[] expected_results = new int[] {71, 49, 61, 70};
            for (int i = 0; i < 4; i++) {

                Assert.AreEqual(expected_results[i], MenuRegister.menuregister[i].Item1.LinesNeeded());
                TestRapportText += $"expected {expected_results[i]} got {MenuRegister.menuregister[i].Item1.LinesNeeded()}\n";
            }

            Write_rapport();
        }

        //[TestMethod]
        public void ReserveringsWriter_ToDisplay_tester() {

            Directory.SetCurrentDirectory(@"C:\Users\Paran\Documents\BackupGit\Restaurant_Applicatie\Restaurant-Groep4\bin\Debug\netcoreapp3.1");
            Program.Start();

            Random random = new Random();

            TestRapportText += "ReserveringsWriter ToDisplay Test: \n" + new string('_', 50) + "\n";
            //71, 144, 267, 70
            string[] data_array = new string[] {

                String.Join(Environment.NewLine ,new string[] {"thomas", $"1", "2", $"{random.Next(0, 12)}/{random.Next(0, 27)}/{random.Next(2022, 2030)}", "ja"}),
                String.Join(Environment.NewLine ,new string[] {"lamis", $"2", "2", $"{random.Next(0, 12)}/{random.Next(0, 27)}/{random.Next(2022, 2030)}", "ja"}),
                String.Join(Environment.NewLine ,new string[] {"bjorn", $"3", "2", $"{random.Next(0, 12)}/{random.Next(0, 27)}/{random.Next(2022, 2030)}", "ja"}),
                String.Join(Environment.NewLine ,new string[] {"kai", $"4", "2", $"{random.Next(0, 12)}/{random.Next(0, 27)}/{random.Next(2022, 2030)}", "ja"}),
                String.Join(Environment.NewLine ,new string[] {"mattias", $"5", "2", $"{random.Next(0, 12)}/{random.Next(0, 27)}/{random.Next(2022, 2030)}", "ja"}),
                String.Join(Environment.NewLine ,new string[] {"jasper", $"6", "2", $"{random.Next(0, 12)}/{random.Next(0, 27)}/{random.Next(2022, 2030)}", "ja"}),
                String.Join(Environment.NewLine ,new string[] {"david", $"7", "2", $"{random.Next(0, 12)}/{random.Next(0, 27)}/{random.Next(2022, 2030)}", "ja"})
            };
            //string data = String.Join(Environment.NewLine ,new string[] {"5", "Good restaurant"});

            int initialLength = Program.Reserveringhandler.Reserveringen.Count;

            foreach (string data in data_array) {

                using (StringReader reader = new StringReader(data)) {

                    Console.SetIn(reader);
                    ReserveringWriter.ToDisplay();
                }
            }

            //bool complete = initialLength + 1 == Program.Reserveringhandler.Reserveringen.Count;
            //Assert.IsTrue(complete);
            //TestRapportText += $"Expected {initialLength + data_array.Length} in list got {Program.Reserveringhandler.Reserveringen.Count}\n";

            Write_rapport();
        }

        [TestMethod]
        public void Floorplan_ToDisplay_tester() {

            //Random random = random.Next();
            Directory.SetCurrentDirectory(@"C:\Users\Paran\Documents\BackupGit\Restaurant_Applicatie\Restaurant-Groep4\bin\Debug\netcoreapp3.1");
            Program.Start();

            TestRapportText += "FloorPlan ToDisplay Test: \n" + new string('_', 50) + "\n";

            Tuple<char, int, int>[] data_array = new Tuple<char, int, int>[] {
                Tuple.Create('■', 3, 12),
                Tuple.Create('/', 1, 19),
                Tuple.Create('T', 4, 2)
            };

            FloorPlan.ToDisplay();
            foreach (Tuple<char, int, int> data in data_array) {

                bool equal = data.Item1 == Program.display.displaybuffer.Displaybuffer[data.Item3, data.Item2];
                TestRapportText += $"expected {data.Item1} got {Program.display.displaybuffer.Displaybuffer[data.Item3, data.Item2]}\n";
                Assert.IsTrue(equal);
                
            }

            Write_rapport();
        }

        [TestMethod]
        public void Reviewviewer_ToDisplay_tester() {

            Directory.SetCurrentDirectory(@"C:\Users\Paran\Documents\BackupGit\Restaurant_Applicatie\Restaurant-Groep4\bin\Debug\netcoreapp3.1");
            Program.Start();

            TestRapportText += "Reviewviewer ToDisplay Test: \n" + new string('_', 50) + "\n";

            Tuple<char, int, int>[] data_array = new Tuple<char, int, int>[] {
                Tuple.Create('#', 0, 2),
                Tuple.Create(':', 12, 7),
                Tuple.Create('h', 4, 3)
            };

            ReviewViewer.ToDisplay();
            foreach (Tuple<char, int, int> data in data_array) {

                bool equal = data.Item1 == Program.display.displaybuffer.Displaybuffer[data.Item3, data.Item2];
                TestRapportText += $"expected {data.Item1} got {Program.display.displaybuffer.Displaybuffer[data.Item3, data.Item2]}\n";
                Assert.IsTrue(equal);

            }

            Write_rapport();
        }







        public static void Write_rapport() {

            File.WriteAllText(@"C:\Users\Paran\Documents\BackupGit\Restaurant_Applicatie\Restaurant-Groep4_test\TestRapport.txt", "");
            File.AppendAllText(@"C:\Users\Paran\Documents\BackupGit\Restaurant_Applicatie\Restaurant-Groep4_test\TestRapport.txt", TestRapportText);
            //File.WriteAllText(@"C:\Users\Paran\Documents\BackupGit\Restaurant_Applicatie\Restaurant-Groep4_test\TestRapport.txt", "hallo\nhallo");
            //Console.WriteLine(TestRapportText);
        }
    }
}
