﻿using System;
using System.Collections.Generic;

namespace Restaurant_Groep4 {
    class Program {

        public static bool running = true;              //Creating a public static variable that keeps the main program loop going
        public static Display.Display display;          //Creating a variable to hold our display
        public static string UserInput = "";            //Creating a variable to store any user input we get
        public static void Main(string[] args) {        //Main method

            Start();                                    //calling the Start method
            
            while (running) {                           //Creating the main program loop

                Update();                               //Calling the update method
            }
        }            

        private static void Start() {                   //Start method
            display = new Display.Display(80, 20);      //Setting the display variable to a new instance of our Display class
        }
 
        private static void Update() {                  //Update method
            display.ToConsole();                        //Displaying everything in our display to the console
            Console.WriteLine("Enter your input: ");    //Writing something to the console that is outside our displaybuffer
            UserInput = Console.ReadLine();             //Waiting for user to give input

            display.AddCharacter(5, 5, 'H');            //Just adding a character to the displaybuffer at Y:5, X: 5 for testing
        }
    }
}
