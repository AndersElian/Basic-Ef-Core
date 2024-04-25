namespace Basic.Ef.Core.Models;

public class Person
{
    public required string Email { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
}