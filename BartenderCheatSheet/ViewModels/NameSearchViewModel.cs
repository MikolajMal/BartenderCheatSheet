using BartenderCheatSheet.Models;

namespace BartenderCheatSheet.ViewModels
{
	public class NameSearchViewModel
	{
		public string Query { get; set; } = string.Empty;
		public List<Drink> QueryResult { get; set; } = new();
	}
}
