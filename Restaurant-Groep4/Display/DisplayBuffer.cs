using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Groep4.Display
{
    class DisplayBuffer : IDisplayBuffer {

        public char[,] Displaybuffer;
        public int DisplayHeight;
        public int DisplayWidth;

        public DisplayBuffer(int width, int height) {
            Displaybuffer = new char[height, width];
            DisplayHeight = height;
            DisplayWidth = width;
        }

        public string toString() {

            string result = "";
            for (int y = 0; y < DisplayHeight; y++) {
                for (int x = 0; x < DisplayWidth; x++) {

                    if (Displaybuffer[y, x] == '\0')
                    {
                        result += " ";
                    }
                    else {
                        result += Displaybuffer[y, x];
                    }
                }
                result += "\n";
            }
            return result;
        }

        public void EmptyBuffer() {
            Displaybuffer = new char[DisplayHeight, DisplayWidth];
        }

        public void AddCharacter(int x, int y, char character) {

            Displaybuffer[y, x] = character;
        }
    }
}
