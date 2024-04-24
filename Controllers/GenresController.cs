using Basic.Ef.Core.Data;
using Basic.Ef.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dometrain.EFCore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GenresController : Controller
{
    private readonly MoviesContext _context;

    public GenresController(MoviesContext context)
    {
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Genre>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllGenres()
    {
        return Ok(await _context.Genres.ToListAsync());
    }

    [HttpGet]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(Genre), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetGenreById([FromRoute] int id)
    {
        var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);
        return genre is null ? NotFound() : Ok(genre);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Genre), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateGenre([FromBody] Genre genre)
    {
        if (genre is null)
            return BadRequest();

        await _context.AddAsync(genre);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetGenreById), new {id = genre.Id }, genre);
    }

    [HttpPatch]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(Genre), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest | StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateGenre([FromRoute] int id, [FromBody] Genre genre)
    {
        if(genre is null)
            return BadRequest();

        var genreToUpdate = await _context.Genres.FindAsync(id);

        if(genreToUpdate is null)
            return NotFound();

        genreToUpdate.Name = genre.Name;
        await _context.SaveChangesAsync();

        return Ok(genreToUpdate);
    }


    [HttpDelete]
    [Route("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteGenreById([FromRoute] int id)
    {
        var genreToRemove = await _context.Genres.FindAsync(id);

        if (genreToRemove is null)
            return NotFound();

        _context.Remove(genreToRemove);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
