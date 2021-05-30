using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Restaurant_Groep4.Reserveringen
{
    class ReserveringHandler
    {
        public List<Reservering> Reserveringen { get; set;}

        public ReserveringHandler()
        {
            Reserveringen = new List<Reservering>();
            this.LoadFromJson();
        }
        public void Addreservering(Reservering _reservering)
        {
            Reserveringen.Add(_reservering);
            SaveToJson();
        }

        public Reservering GetReservering(int _index)
        {

            if (Reserveringen.Count == 0)
            {
                return new Reservering();
            }
            else if (_index > Reserveringen.Count - 1)
            {
                return Reserveringen[0];
            }
            else
            {
                return Reserveringen[_index];
            }
        }
        private void SaveToJson()
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonstring = JsonSerializer.Serialize(this.Reserveringen, options);
            string dir = Directory.GetCurrentDirectory();
            dir = dir.Substring(0, dir.Length - 23);
            File.WriteAllText(dir + "Json\\Reserveringen\\Reserveringen.json", jsonstring);
        }
        private void LoadFromJson()
        {
            string dir = Directory.GetCurrentDirectory();
            dir = dir.Substring(0, dir.Length - 23);
            dir += "Json\\Reserveringen\\" + "Reserveringen" + ".json";
            string jsonstring = File.ReadAllText(dir);
            JsonSerializer.Deserialize<List<Reservering>>(jsonstring);

        }
    }
}
