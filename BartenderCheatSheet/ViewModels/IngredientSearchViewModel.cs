using BartenderCheatSheet.Models;

namespace BartenderCheatSheet.ViewModels
{
	public class IngredientSearchViewModel
	{
		public List<Ingredient> Ingredients { get; set; } = new();
		public List<Drink> Drinks { get; set; } = new();
	}
}
