using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Groep4.Display
{
    interface IDisplayBuffer { //Creating the interface IDisPlayBuffer


        //Interface Methods (These have no bodies because they are interface methods)
        string toString();
        void EmptyBuffer();
        void AddCharacter(int x, int y, char character);
    }
}
