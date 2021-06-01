using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Groep4.Misc {
    public class Date {

        public int Year {get; set;}
        public int Month {get; set;}
        public int Day {get; set;}
        public int Hour {get; set;}
        public int Minute {get; set;}

        public Date(int _year, int _month, int _day, int _hour, int _minute) {

            Year = _year;
            Month = _month;
            Day = _day;
            Hour = _hour;
            Minute = _minute;
        }

    }
}
