using Basic.Ef.Core.Models;

namespace Basic.Ef.Core.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }    
    public DateTime ReleaseDate { get; set; }
    public string? Synopsis { get; set; }
    public Genre Genre { get; set; }
    public Person Director { get; set; }
}

public class MovieTitle
{
    public int Id { get; set; }
    public string? Title { get; set; }
}
