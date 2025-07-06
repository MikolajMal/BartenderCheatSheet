namespace BartenderCheatSheet.Models
{
	public class Drink
	{
		public int DrinkId { get; set; }
		public string Name { get; set; } = string.Empty;
		public List<IngredientQuantity>? MeasurementsOfIngredients { get; set; }
		public string? Instructions { get; set; }
		public string? ImageUrl { get; set; }
	}
}
