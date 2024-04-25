using Basic.Ef.Core.Data;
using Basic.Ef.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Basic.Ef.Core.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : Controller
{
    private readonly MoviesContext _context;

    public PersonController(MoviesContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<Person>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Persons.ToListAsync());
    }
    
    [HttpGet("{email}")]
    [ProducesResponseType(typeof(Person),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPersonByEmail([FromRoute] string email)
    {
        var person = await _context.Persons.FindAsync(email);
        return person == null ? NotFound() : Ok(person);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Person), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreatePerson([FromBody] Person person)
    {
        if(string.IsNullOrWhiteSpace(person.Email) || string.IsNullOrWhiteSpace(person.LastName))
            return BadRequest("Email is required and LastName is required");

        await _context.Persons.AddAsync(person);
        await _context.SaveChangesAsync();

        return Ok(person);
    }
    
    [HttpDelete("{email}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RetirePerson([FromRoute] string email)
    {
        var person = await _context.Persons.FindAsync(email);
        if(person == null)
            return NotFound();
        
        _context.Entry(person).Property<bool>("isRetired").CurrentValue = true;
        await _context.SaveChangesAsync();

        return Ok();
    }
}