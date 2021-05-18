using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Restaurant_Groep4.Reserveringen {
    class ReserveringHandler {
        public List<Reservering> Reservering { get; set; }

        public ReserveringHandler() {

            Reservering = new List<Reservering>();
            GetReserveringContents();
        }

        public void AddReservering(Reservering _reservering) {

            Reservering.Add(_reservering);
            SaveReservering();
        }

        public Reservering GetReservering(int _index) {

            if (Reservering.Count == 0) {

                return new Reservering("Niemand", 0, 0, new Date(0, 0, 0, 0, 0));
            }
            else if (_index > Reservering.Count - 1) {

                return Reservering[0];
            }
            else {

                return Reservering[_index];
            }
        }
        private void GetReserveringContents() {

            string dir = Directory.GetCurrentDirectory();
            dir = dir.Substring(0, dir.Length - 23);
            dir += "Json\\Reserveringen\\" + "Reserveringen" + ".json";
            string jsonstring = File.ReadAllText(dir);

            using (JsonDocument document = JsonDocument.Parse(jsonstring)) {

                JsonElement root = document.RootElement;

                if (root.TryGetProperty("Reservering", out JsonElement ReserveringsElement)) {

                    List<Reservering> TempListReservering = new List<Reservering>();

                    foreach (JsonElement ReserveringElement in ReserveringsElement.EnumerateArray()) {

                        if (ReserveringElement.TryGetProperty("Naam", out JsonElement NaamElement) && ReserveringElement.TryGetProperty("Datum", out JsonElement ReserveringDateElement) &&
                            ReserveringElement.TryGetProperty("Tafel", out JsonElement TafelElement) && ReserveringElement.TryGetProperty("Personen", out JsonElement PersonnenElement)) {

                            if (ReserveringDateElement.TryGetProperty("Year", out JsonElement YearElement) && ReserveringDateElement.TryGetProperty("Month", out JsonElement MonthElement)
                                && ReserveringDateElement.TryGetProperty("Day", out JsonElement DayElement) && ReserveringDateElement.TryGetProperty("Hour", out JsonElement HourElement)
                                && ReserveringDateElement.TryGetProperty("Minute", out JsonElement MinuteElement)) {

                                TempListReservering.Add(new Reservering(NaamElement.GetString(), TafelElement.GetInt32(), PersonnenElement.GetInt32(), new Date(YearElement.GetInt32(), MonthElement.GetInt32(), DayElement.GetInt32(), HourElement.GetInt32(), MinuteElement.GetInt32())));
                                
                            }
                        }
                        Reservering = TempListReservering;
                    }
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

        }
    }
}