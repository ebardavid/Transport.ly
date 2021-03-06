using System.Text.Json.Serialization;

namespace Trasnport.ly
{
    public class Order
    {
        public string Id { get; set; }

        [JsonPropertyNameAttribute("destination")]
        public string Destination { get; set; }
        public Schedule Schedule { get; set; }
        public bool IsApplied() => Schedule == null ? false : true;
    }
}
