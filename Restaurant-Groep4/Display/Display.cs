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

        public void ResizeDisplay(int newwidth, int newheight) {//ResizeDisplay method taking in an int for the new width and an int for the new height
            displaybuffer.ResizeDisplayBuffer(newwidth, newheight);//With the input in this function calling the function in our displayBuffer class
        }

        public void AddString(int startX, int startY, string String) {          //Method to add an intire string to the displaybuffer

            for (int i = 0; i < String.Length; i++) {                           //starting a for loop to loop through all the characters in the string

                if (startX >= displaybuffer.DisplayWidth) {                     //if our current x position is bigger then the width of the displaybufffer go to the next line
                    startX = 0;                                                 //set the our current x to 0
                    startY++;                                                   //increment our current y by 1
                }
                if (startY >= displaybuffer.DisplayHeight && startX >= displaybuffer.DisplayWidth || startY >= displaybuffer.DisplayHeight) {   //if our current y is bigger then our displaybuffer height or our current y and our current x are bigger
                    break;                                                                                                                      //Break the loop
                }

                displaybuffer.AddCharacter(startX, startY, String[i]);          //if it is all fine call the AddCharacter method from the displaybuffer class with our current x and y and the character we are on
                startX++;                                                       //after this increment current x by 1

            }

        }
    }
}

