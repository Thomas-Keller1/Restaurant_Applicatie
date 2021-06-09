using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Groep4.Misc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace Restaurant_Groep4.Reviews {
    public class ReviewHandler {

        public List<Review> Reviews {get; set;}

        public ReviewHandler() {

            Reviews = new List<Review>();
            LoadFromJson();
        }

        public void AddReview(Review _review) {
            Reviews.Add(_review);
            SaveToJson();
        }

        public Review GetReview(int _index) {

            if (Reviews.Count == 0) {
                return new Review("Geen", new Date(0, 0, 0, 0, 0), "Leeg", 0);
            }
            else if (_index > Reviews.Count - 1) {
                return Reviews[0];
            }
            else {
                return Reviews[_index];
            }
        }

        private void LoadFromJson() {
            string dir = Directory.GetCurrentDirectory();
            dir = dir.Substring(0, dir.Length - 23);
            dir += "Json\\Reviews\\" + "Reviews" + ".json";
            string jsonstring = File.ReadAllText(dir);

            using (JsonDocument document = JsonDocument.Parse(jsonstring)) {

                JsonElement root = document.RootElement;

                if (root.TryGetProperty("Reviews", out JsonElement ReviewsElement)) {

                    List<Review> TempListReviews = new List<Review>();

                    foreach (JsonElement ReviewElement in ReviewsElement.EnumerateArray()) {

                        if (ReviewElement.TryGetProperty("UserName", out JsonElement UsernameElement) && ReviewElement.TryGetProperty("ReviewDate", out JsonElement ReviewdateElement) &&
                            ReviewElement.TryGetProperty("Description", out JsonElement DescriptionElement) && ReviewElement.TryGetProperty("Rating", out JsonElement RatingElement)) {

                            if (ReviewdateElement.TryGetProperty("Year", out JsonElement YearElement) && ReviewdateElement.TryGetProperty("Month", out JsonElement MonthElement) 
                                && ReviewdateElement.TryGetProperty("Day", out JsonElement DayElement) && ReviewdateElement.TryGetProperty("Hour", out JsonElement HourElement) 
                                && ReviewdateElement.TryGetProperty("Minute", out JsonElement MinuteElement)) {

                                TempListReviews.Add(new Review(UsernameElement.GetString(), new Date(YearElement.GetInt32(), MonthElement.GetInt32(), DayElement.GetInt32(), HourElement.GetInt32(), MinuteElement.GetInt32()), DescriptionElement.GetString(), RatingElement.GetInt32()));
                            }
                        }
                    }
                    Reviews = TempListReviews;
                }
            }
        }

        private void SaveToJson() {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonstring = JsonSerializer.Serialize(this, options);
            string dir = Directory.GetCurrentDirectory();
            dir = dir.Substring(0, dir.Length - 23);
            File.WriteAllText(dir + "Json\\Reviews\\" + "Reviews" + ".json", jsonstring);
        }
    }
}
