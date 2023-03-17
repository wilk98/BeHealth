using BeHealthBackend.DTOs.RecipeDtoFolder;

namespace BeHealthBackend.Services.RecipeService
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeDto>> GetIdAsync(int id);
    }
}
