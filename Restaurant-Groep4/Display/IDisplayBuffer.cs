using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Groep4.Display
{
    interface IDisplayBuffer {

        string toString();
        void EmptyBuffer();
        void AddCharacter(int x, int y, char character);
    }
}
