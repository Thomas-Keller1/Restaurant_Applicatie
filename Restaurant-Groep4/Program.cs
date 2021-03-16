using System;
using System.Collections.Generic;

namespace Restaurant_Groep4 {
    class Program {

        public static bool running = true;
        public static Display.Display display;
        public static string UserInput = "";
        public static void Main(string[] args) {

            Start();
            
            while (running) {

                Update();
            }
        }

        int[,] array = new int[50, 50];

        private static void Start() {
            display = new Display.Display(80, 20);
        }

        private static void Update() {
            display.ToConsole();
            Console.WriteLine("Enter your input: ");
            UserInput = Console.ReadLine();

            display.AddCharacter(5, 5, 'H');
        }
    }
}
