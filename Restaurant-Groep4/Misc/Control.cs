using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Groep4.Misc {
    public class Control {

        public string DisplayName {get; set;}
        public ScreenEnum ToDisplay {get; set;}
        public bool LocalSwitch {get; set;}

        public Control(string _displayname, ScreenEnum _todisplay, bool _localswitch) {

            DisplayName = _displayname;
            ToDisplay = _todisplay;
            LocalSwitch = _localswitch;
        }
    }
}
