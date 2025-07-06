using BartenderCheatSheet.Models;
using BartenderCheatSheet.Services;
using Microsoft.AspNetCore.Mvc;

namespace BartenderCheatSheet.Controllers
{
	public class HomeController : Controller
	{
		IDrinkService drinkService;

		public HomeController(IDrinkService service)
		{
			drinkService = service;
		}

		public async Task<IActionResult> Index()
		{
			Drink? drink = await drinkService.GetRandomDrink();
			return View(drink);
		}

		public IActionResult About()
		{
			return View();
		}
	}
}
