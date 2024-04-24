using System.Text.Json.Serialization;

namespace Basic.Ef.Core.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Movie> Movies { get; set; }
    }
}
