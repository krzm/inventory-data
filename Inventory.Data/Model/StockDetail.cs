using System.ComponentModel.DataAnnotations;

namespace Inventory.Data;

public class StockDetail
{
	public int Id { get; set; }

	[MaxLength(250)]
	public string Description { get; set; }
}