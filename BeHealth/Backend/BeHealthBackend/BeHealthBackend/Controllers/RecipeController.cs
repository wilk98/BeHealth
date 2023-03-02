using BeHealthBackend.DTOs.RecipeDtoFolder;
using BeHealthBackend.Services.RecipeService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeHealthBackend.Controllers;

[ApiController, Route("/api/recipes")]
//[Authorize(Roles = "Patient")]
public class RecipeController : ControllerBase
{
    private readonly IRecipeService _recipeService;

    public RecipeController(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<RecipeDto>>> GetRecipesByIdAsync([FromRoute] int id)
    {
        var recipes = await _recipeService.GetIdAsync(id);
        return Ok(recipes);
    }

}
