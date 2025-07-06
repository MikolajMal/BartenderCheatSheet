namespace BartenderCheatSheet.Models
{
	public class IngredientQuantity
	{
		public string Name { get; set; }
		public string Quantity { get; set; }
		public string NameWithQuantity => Name + (string.IsNullOrEmpty(Quantity) ? string.Empty : $" - {Quantity}");
	}
}
