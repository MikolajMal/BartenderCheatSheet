using BartenderCheatSheet.Models;
using BartenderCheatSheet.Services;
using Microsoft.AspNetCore.Mvc;

namespace BartenderCheatSheet.Controllers
{
	public class DrinkController : Controller
	{
		IDrinkService drinkService;

		public DrinkController(IDrinkService service)
		{
			drinkService = service;
		}

		public async Task<IActionResult> Index(int drinkId)
		{
			Drink? drink = await drinkService.GetDrinkById(drinkId);
			return View(drink);
		}
	}
}
