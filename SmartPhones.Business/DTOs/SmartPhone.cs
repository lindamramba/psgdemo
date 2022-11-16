using System.Text.Json.Serialization;

namespace SmartPhones.Business
{
    public class SmartPhone
    {
        [JsonPropertyName("products")]
        public List<Product>? Products { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("skip")]
        public int Skip { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }
    }
}
