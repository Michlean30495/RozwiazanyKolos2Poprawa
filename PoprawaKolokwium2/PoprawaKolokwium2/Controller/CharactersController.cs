using Microsoft.AspNetCore.Mvc;
using PoprawaKolokwium2.Services;

namespace PoprawaKolokwium2.Controller;

[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;

    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCharacter(int id)
    {
        try
        {
            var result = await _dbService.GetCharacterById(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(new {message = ex.Message});
        }
    }

    [HttpPost("{id}/backpacks")]
    public async Task<IActionResult> AddBackpack([FromBody] List<int> ids, int id)
    {
        try
        {
            await _dbService.AddItemToCharacterBackpack(ids, id);
            return StatusCode(StatusCodes.Status201Created);
        }
        catch (Exception ex)
        {
            return NotFound(new {message = ex.Message});
        }
    }
}