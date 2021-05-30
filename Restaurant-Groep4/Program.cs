using System;
using System.Collections.Generic;
using Restaurant_Groep4.Misc;
using Restaurant_Groep4.Screens;
using Restaurant_Groep4.Reviews;
using Restaurant_Groep4.Reserveringen;
using Restaurant_Groep4.Contactpagina;


namespace Restaurant_Groep4 {
    class Program {

        public static bool running = true;              //Creating a public static variable that keeps the main program loop going
        public static Display.Display display;          //Creating a variable to hold our display
        public static string UserInput = "";            //Creating a variable to store any user input we get
        public static ScreenEnum onScreen = ScreenEnum.Mainmenu;                          //Create a variable to hold our enum values this will track on which screen we are at every moment
        public static ReviewHandler Reviewhandler = new ReviewHandler();
        public static ReserveringHandler Reserveringhandler = new ReserveringHandler();
        public static ContactpaginaHandler Contactpaginahandler = new ContactpaginaHandler();
        //public static Menu.MultiPageMenu testmenu = new Menu.MultiPageMenu("testmenu", 1);
        public static void Main(string[] args) {        //Main method

            Start();                                    //calling the Start method
            
            while (running) {                           //Creating the main program loop

                Update();                               //Calling the update method
            }

        }            

        private static void Start() {                   //Start method
            display = new Display.Display(80,20);      //Setting the display variable to a new instance of our Display class
            Console.OutputEncoding = System.Text.Encoding.UTF8; //To enable unicode characters in the console (Characters such as: €, Ⓥ)
            Menu.MenuRegister.RegisterMenus();                          //Call the registermenus method in the Menuregister class
            //Menu.MenuRegister.menuregister[0].Item1.ToDisplay(display); //Making it start with displaying the testmenu(Kindermenu)
            Screens.Mainmenu.ToDisplay();
            display.ToConsole();                                        //Making it display before the main program loop starts

        }
 
        private static void Update() {                  //Update method
                                                        //Displaying everything in our display to the console
            Console.WriteLine("Enter your input: ");    //Writing something to the console that is outside our displaybuffer
            UserInput = Console.ReadLine();             //Waiting for user to give input
            if (ControlHandler.IsInputValid()) {        //Checks if the input given is valid by calling the IsInputValid method from our controlhandler
                ControlHandler.HandleInput();           //Calling the HandleInput method from our controlhandler
                ControlHandler.HandleDisplay();
                display.ToConsole();                    //Putting everything in the display in the console if correct input has been given(If not we don't need to update the display)
            }
        }
    }
}