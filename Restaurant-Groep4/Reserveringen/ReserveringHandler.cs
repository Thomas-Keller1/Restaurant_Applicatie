using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Restaurant_Groep4.Reserveringen {
    public class ReserveringHandler {
        public List<Reservering> Reserveringen { get; set; }
        public Table[] Tables;

        public ReserveringHandler() {

            Reserveringen = new List<Reservering>();
            Tables = new Table[15] {new Table(true, 2), new Table(true, 4), new Table(true, 2), new Table(true, 6), new Table(true, 4), new Table(true, 2), new Table(true, 2), new Table(true, 4), new Table(true, 2), new Table(true, 6), new Table(true, 4), new Table(true, 4), new Table(true, 2), new Table(true, 2), new Table(true, 2)};
            GetReserveringContents();
            RemoveReservering();
        }

        public void AddReservering(Reservering _reservering) {

            Reserveringen.Add(_reservering);
            Tables[_reservering.Tafel - 1].Available = false;
            SaveReservering();
        }

        public Reservering GetReservering(int _index) {

            if (Reserveringen.Count == 0) {

                return new Reservering("Niemand", 0, 0, new Date(0, 0, 0, 0, 0));
            }
            else if (_index > Reserveringen.Count - 1) {

                return Reserveringen[0];
            }
            else {

                return Reserveringen[_index];
            }
        }

        private void GetReserveringContents() {

            string dir = Directory.GetCurrentDirectory();
            dir = dir.Substring(0, dir.Length - 23);
            dir += "Json\\Reserveringen\\" + "Reserveringen" + ".json";
            string jsonstring = File.ReadAllText(dir);

            using (JsonDocument document = JsonDocument.Parse(jsonstring)) {

                JsonElement root = document.RootElement;

                if (root.TryGetProperty("Reserveringen", out JsonElement ReserveringsElement)) {

                    List<Reservering> TempListReserveringen = new List<Reservering>();

                    foreach (JsonElement ReserveringElement in ReserveringsElement.EnumerateArray()) {

                        if (ReserveringElement.TryGetProperty("Naam", out JsonElement NaamElement) && ReserveringElement.TryGetProperty("Datum", out JsonElement ReserveringDateElement) &&
                            ReserveringElement.TryGetProperty("Tafel", out JsonElement TafelElement) && ReserveringElement.TryGetProperty("Personnen", out JsonElement PersonnenElement)) {

                            if (ReserveringDateElement.TryGetProperty("Year", out JsonElement YearElement) && ReserveringDateElement.TryGetProperty("Month", out JsonElement MonthElement)
                                && ReserveringDateElement.TryGetProperty("Day", out JsonElement DayElement) && ReserveringDateElement.TryGetProperty("Hour", out JsonElement HourElement)
                                && ReserveringDateElement.TryGetProperty("Minute", out JsonElement MinuteElement)) {

                                TempListReserveringen.Add(new Reservering(NaamElement.GetString(), TafelElement.GetInt32(), PersonnenElement.GetInt32(), new Date(YearElement.GetInt32(), MonthElement.GetInt32(), DayElement.GetInt32(), HourElement.GetInt32(), MinuteElement.GetInt32())));
                                Tables[TempListReserveringen[TempListReserveringen.Count - 1].Tafel - 1].Available = false;

                            }
                        }
                    }
                    Reserveringen = TempListReserveringen;
                }
            }
        }

        private void SaveReservering() {

            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonstring = JsonSerializer.Serialize(this, options);
            string dir = Directory.GetCurrentDirectory();
            dir = dir.Substring(0, dir.Length - 23);
            File.WriteAllText(dir + "Json\\Reserveringen\\" + "Reserveringen" + ".json", jsonstring);
        }

        private void RemoveReservering() {

            DateTime today = DateTime.Now;
            int count = 0;
            List<int> toremove = new List<int>();
            foreach (Reservering reservering in Reserveringen) {
                if (today > new DateTime(reservering.Datum.Year, reservering.Datum.Month, reservering.Datum.Day, reservering.Datum.Hour, reservering.Datum.Minute, 0)) {

                    toremove.Add(count);
                }
                count++;
            }
            foreach (int index in toremove) {

                Reserveringen.RemoveAt(index);
            }
        }
    }
}