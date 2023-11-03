using System.Text.Json.Serialization;

namespace TechTestAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; } = 0;

        [JsonIgnore]
        public List<HistoryStock>? HistoryStock { get; set; }
    }
}
