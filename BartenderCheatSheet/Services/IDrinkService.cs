using BartenderCheatSheet.Models;

namespace BartenderCheatSheet.Services
{
	public interface IDrinkService
	{
		Task<IEnumerable<Ingredient>> GetIngredients();
		Task<IEnumerable<Drink>> GetDrinks(string query);
		Task<IEnumerable<Drink>> GetDrinksByIngredient(string ingredient);
		Task<Drink> GetRandomDrink();
		Task<Drink> GetDrinkById(int id);
	}
}
