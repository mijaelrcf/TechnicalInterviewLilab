using System.Text.Json.Serialization;

namespace TechTestAPI.Models
{
    public class HistoryStock
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Stock { get; set; }

        public int ProductId { get; set; }

        [JsonIgnore]
        public Product Product { get; set; }
    }
}
