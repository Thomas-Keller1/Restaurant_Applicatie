using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Groep4.Display
{
    class Display {                                             //Create the Display Class

        public DisplayBuffer displaybuffer;                     //Creating the variable displaybuffer to hold an instance of our DisplayBuffer Class

        public Display(int width, int height) {                 //Constructer for the Display Class taking a int width and a int height
            displaybuffer = new DisplayBuffer(width, height);   //Setting the variable displaybuffer to a new instance of our DisplayBuffer Class with the specified width and height
        }

        public void ToConsole() {                               //Display the display into the console
            Console.WriteLine(displaybuffer.toString());        //convert the displaybuffer to a string and then write the string to the console
        }

        public void AddCharacter(int x, int y, char character) {//Addcharacter method to access from outside this class
            displaybuffer.AddCharacter(x, y, character);        //Using the AddCharacter method from the DisplayBuffer Class
        }

        public void ResizeDisplay(int newwidth, int newheight) {
            displaybuffer.ResizeDisplayBuffer(newwidth, newheight);
        }
    }
}
