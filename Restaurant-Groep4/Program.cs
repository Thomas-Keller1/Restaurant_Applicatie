using System;
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
            Console.OutputEncoding = System.Text.Encoding.UTF8; //To enable unicode characters in the console (Characters such as: €, Ⓥ)
        }
 
        private static void Update() { 
            display.AddString(0,0,"1: Inloggen");
            display.AddString(0,1,"2: Reserveren");
            display.AddString(0,2,"1: Reviews plaatsen");   
            display.AddString(0,3,"1: Afsluiten");   
            display.AddString(0,4,"1: Inloggen");                       //Update method
            display.ToConsole();
                          //Displaying everything in our display to the console
            Console.WriteLine("Enter your input: ");    //Writing something to the console that is outside our displaybuffer
            UserInput = Console.ReadLine();
                     //Waiting for user to give input

            //display.AddCharacter(5, 5, 'H');            //Just adding a character to the displaybuffer at Y:5, X: 5 for testing
            //display.AddString(75, 6, "Helloooooooooooooooooooooooooo");     //Test for the AddString method

            //Menu.SinglePageMenu testmenu = new Menu.SinglePageMenu("testmenu", new Menu.MenuPart("TestPart", new Menu.MenuItem("TestItem", 1500, "This is a testItem", false, false)));
            //testmenu.ToDisplay(display);
            Menu.SinglePageMenu testmenu = new Menu.SinglePageMenu("testmenu");
            testmenu.ToDisplay(display);
        }
    }
}