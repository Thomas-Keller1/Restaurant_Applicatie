﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Groep4.Display
{
    class DisplayBuffer : IDisplayBuffer { //Creating the DisplayBuffer Class That implements the IDisplayBuffer Interface

        public char[,] Displaybuffer;       //The actual 2 dimentional char array that represents the displaybuffer
        public int DisplayHeight;           //The height of the buffer will be stored here so it can be used outside the constructor later
        public int DisplayWidth;            //The width of the buffer will be stored here so it can be used outside the constructor later

        public DisplayBuffer(int width, int height) {       //Constructor for the DisplayBuffer Class
            Displaybuffer = new char[height, width];        //Initializing the char array
            DisplayHeight = height;                         //Storing the Height of the buffer
            DisplayWidth = width;                           //Storing the Width of the buffer 
        }

        public string toString() {                          //implementing the toString method from the interface IDisplayBuffer
            //This method will convert the char array to a single string that can be displayed in the console with Console.WriteLine()

            string result = "";                             //initializing the result variable to store the result in
            for (int y = 0; y < DisplayHeight; y++) {       //Looping through all the columns in the Displaybuffer array
                for (int x = 0; x < DisplayWidth; x++) {    //Looping through all the rows in the Displaybuffer array
                    
                    if (Displaybuffer[y, x] == '\0') {      //If the item in the array at this location is the chars default value 
                        result += " ";                      //Add a space to the result
                    }
                    else {                                  //Else if it is not the default value
                        result += Displaybuffer[y, x];      //Add whatever is there to the final result
                    }
                }
                result += "\n";                             //At the end of the row add a /n to print on the next line
            }
            return result;                                  //returning the result
        }

        public void EmptyBuffer() {                         //implementing the EmptyBuffer method from the interface IDisplayBuffer
            Displaybuffer = new char[DisplayHeight, DisplayWidth];  //set the Displaybuffer array to a new char array of the size of the buffer
        }

        public void AddCharacter(int x, int y, char character) { //implementing the AddCharacter method from the interface IDisplayBuffer

            Displaybuffer[y, x] = character;                //add the character at the specified location
        }

        public void ResizeDisplayBuffer(int newwidth, int newheight) {

            Displaybuffer = new char[newheight, newwidth];
            DisplayHeight = newheight;
            DisplayWidth = newwidth;
        
        }
    }
}
