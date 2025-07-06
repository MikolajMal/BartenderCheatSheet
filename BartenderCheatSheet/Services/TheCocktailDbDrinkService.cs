using BartenderCheatSheet.Models;

namespace BartenderCheatSheet.Services
{
	public class TheCocktailDbDrinkService : IDrinkService
	{
		HttpClient httpClient;

		public TheCocktailDbDrinkService(HttpClient client)
		{
			httpClient = client;
		}

		public async Task<IEnumerable<Drink>> GetDrinks(string query)
		{
			try
			{
				string url = $"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={query}";
				var response = await httpClient.GetFromJsonAsync<DrinkApiResponse>(url);

				if (response == null || response.Drinks == null) return Enumerable.Empty<Drink>();

				return GenerateDrinkList(response);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return new List<Drink>();
		}

		public async Task<IEnumerable<Drink>> GetDrinksByIngredient(string ingredient)
		{
			try
			{
				string url = $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?i={ingredient}";
				var response = await httpClient.GetFromJsonAsync<DrinkApiResponse>(url);

				if (response == null || response.Drinks == null) return Enumerable.Empty<Drink>();

				return GenerateDrinkList(response);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return new List<Drink>();
		}

		List<Drink> GenerateDrinkList(DrinkApiResponse drinkApiResponse)
		{
			List<Drink> drinks = new();

			foreach (DrinkDto drinkDto in drinkApiResponse.Drinks)
			{
				List<IngredientQuantity> ingredientQuantities = GetIngredientQuantities(drinkDto);

				drinks.Add(new Drink
				{
					DrinkId = int.Parse(drinkDto.IdDrink),
					Name = drinkDto.StrDrink,
					MeasurementsOfIngredients = ingredientQuantities,
					Instructions = drinkDto.StrInstructions,
					ImageUrl = drinkDto.StrDrinkThumb
				});
			}

			return drinks;
		}

		public async Task<IEnumerable<Ingredient>> GetIngredients()
		{
			List<Ingredient> drinks = new();

			try
			{
				string url = $"https://www.thecocktaildb.com/api/json/v1/1/list.php?i=list";
				var response = await httpClient.GetFromJsonAsync<DrinkApiResponse>(url);

				if (response == null || response.Drinks == null) return Enumerable.Empty<Ingredient>();

				foreach (DrinkDto drinkDto in response.Drinks)
				{
					drinks.Add(new Ingredient
					{
						Name = drinkDto.StrIngredient1
					});
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return drinks;
		}

		public async Task<Drink> GetRandomDrink()
		{
			try
			{
				string url = $"https://www.thecocktaildb.com/api/json/v1/1/random.php";
				var response = await httpClient.GetFromJsonAsync<DrinkApiResponse>(url);

				if (response == null) return new();

				DrinkDto? drinkDto = response.Drinks.FirstOrDefault();

				if (drinkDto == null) return new();

				List<IngredientQuantity> ingredientQuantities = GetIngredientQuantities(drinkDto);

				return new Drink
				{
					DrinkId = int.Parse(drinkDto.IdDrink),
					Name = drinkDto.StrDrink,
					MeasurementsOfIngredients = ingredientQuantities,
					Instructions = drinkDto.StrInstructions,
					ImageUrl = drinkDto.StrDrinkThumb
				};
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return new();
		}

		public async Task<Drink> GetDrinkById(int id)
		{
			try
			{
				string url = $"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={id}";
				var response = await httpClient.GetFromJsonAsync<DrinkApiResponse>(url);

				if (response == null || response.Drinks == null) return new();

				DrinkDto? drinkDto = response.Drinks.FirstOrDefault();

				if (drinkDto == null) return new();

				List<IngredientQuantity> ingredientQuantities = GetIngredientQuantities(drinkDto);

				return new Drink
				{
					DrinkId = int.Parse(drinkDto.IdDrink),
					Name = drinkDto.StrDrink,
					MeasurementsOfIngredients = ingredientQuantities,
					Instructions = drinkDto.StrInstructions,
					ImageUrl = drinkDto.StrDrinkThumb
				};
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return new();
		}

		List<IngredientQuantity> GetIngredientQuantities(DrinkDto? drinkDto)
		{
			List<IngredientQuantity> ingredientQuantities = new();

			if (drinkDto == null) return ingredientQuantities;

			for (int i = 1; i <= 15; i++)
			{
				string? ingredient = drinkDto.GetType().GetProperty($"StrIngredient{i}")?.GetValue(drinkDto) as string;
				string? quantity = drinkDto.GetType().GetProperty($"StrMeasure{i}")?.GetValue(drinkDto) as string ?? string.Empty;

				if (!string.IsNullOrEmpty(ingredient))
				{
					ingredientQuantities.Add(
						new IngredientQuantity
						{
							Name = ingredient,
							Quantity = quantity
						});
				}
			}

			return ingredientQuantities;
		}
	}
}
