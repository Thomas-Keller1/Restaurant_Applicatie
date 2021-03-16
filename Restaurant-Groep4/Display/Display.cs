using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Groep4.Display
{
    class Display {

        public DisplayBuffer displaybuffer;

        public Display(int width, int height) {
            displaybuffer = new DisplayBuffer(width, height);
        }

        public void ToConsole() {
            Console.WriteLine(displaybuffer.toString());
        }

        public void AddCharacter(int x, int y, char character) {
            displaybuffer.AddCharacter(x, y, character);
        }
    }
}
