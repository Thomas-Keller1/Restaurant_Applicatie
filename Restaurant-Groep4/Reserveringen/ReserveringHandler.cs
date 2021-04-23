using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;

namespace Restaurant_Groep4.Reserveringen
{
    class ReserveringHandler
    {
        public List<Reservering> Reserveringen { get; set;}

        public ReserveringHandler()
        {
            Reserveringen = new List<Reservering>();
        }

        public void CheckDates(){

            DateTime dateNow = DateTime.Now;
            Date dateReservation = new Date(dateNow.Year, dateNow.Month, dateNow.Day, dateNow.Hour, dateNow.Minute);
            int Count = 0;
            
            foreach(Reservering reservering in Reserveringen){
                if (dateReservation.Day > reservering.Datum.Day){
                    Reserveringen.RemoveAt(Count);
                }
                else if (dateReservation.Month > reservering.Datum.Month){
                    Reserveringen.RemoveAt(Count);
                }
                Count += 1;
            }
            // Save the list to json file
        }
    }
}


