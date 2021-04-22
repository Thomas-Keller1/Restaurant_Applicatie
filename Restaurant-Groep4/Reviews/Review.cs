using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Reviews {
    class Review {

        public string UserName {get; set;}
        public Date ReviewDate {get; set;}
        public string Description {get; set;}
        public int Rating {get; set;}

        public Review(string _username, Date _reviewdate, string _description, int _rating) {

            UserName = _username;
            ReviewDate = _reviewdate;
            Description = _description;
            Rating = _rating;
        }
    }
}
