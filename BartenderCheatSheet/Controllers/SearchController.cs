using BartenderCheatSheet.Models;
using BartenderCheatSheet.Services;
using BartenderCheatSheet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BartenderCheatSheet.Controllers
{
	public class SearchController : Controller
	{
		IDrinkService drinkService;

		public SearchController(IDrinkService service)
		{
			drinkService = service;
		}

		public IActionResult SearchByName()
		{
			return View(new NameSearchViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> SearchByName(NameSearchViewModel nameSearchViewModel)
		{
			string query = nameSearchViewModel.Query;

			if (string.IsNullOrEmpty(query))
				nameSearchViewModel.QueryResult.Clear();
			else
			{
				IEnumerable<Drink> drinks = await drinkService.GetDrinks(query);

				if(drinks != null)
					nameSearchViewModel.QueryResult = new(drinks);
			}

			return View(nameSearchViewModel);
		}

		public async Task<IActionResult> SearchByIngredients()
		{
			IEnumerable<Ingredient> ingredients = await drinkService.GetIngredients();

			List<Ingredient> ingredientList = ingredients.OrderBy(i => i.Name).ToList();

			IngredientSearchViewModel ingredientSearchViewModel = new ();
			ingredientSearchViewModel.Ingredients = ingredientList;

			return View(ingredientSearchViewModel);
		}

		[HttpPost]
		public async Task<IActionResult> SearchByIngredients(IngredientSearchViewModel ingredientSearchViewModel)
		{
			List<Ingredient> selectedIngredients = ingredientSearchViewModel.Ingredients.Where(i => i.IsSelected).ToList();

			if (selectedIngredients.Count == 0) return View(ingredientSearchViewModel);

			IEnumerable<Drink> drinks = await drinkService.GetDrinksByIngredient(selectedIngredients.Select(i => i.Name).FirstOrDefault());

			IEnumerable<int> ids = drinks.Select(d => d.DrinkId);

			foreach (Ingredient ingredient in selectedIngredients)
			{
				IEnumerable<Drink> drinksToCompare = await drinkService.GetDrinksByIngredient(ingredient.Name);
				IEnumerable<int> i = drinksToCompare.Select(d => d.DrinkId);
				ids = ids.Intersect(i);
			}

			drinks = drinks.Where(d => ids.Contains(d.DrinkId));

			ingredientSearchViewModel.Drinks.Clear();

			foreach (Drink drink in drinks)
			{
				ingredientSearchViewModel.Drinks.Add(drink);
			}

			return View(ingredientSearchViewModel);
		}
	}
}
