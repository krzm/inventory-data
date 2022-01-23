using System.ComponentModel.DataAnnotations;

namespace Inventory.Data;

public class ItemDetail
{
	public int Id { get; set; }

	[MaxLength(250)]
	public string Description { get; set; }

	public double?  Width { get; set; }

	public double?  Depth { get; set; }

	public double?  Heigth { get; set; }

	public double?  Diameter { get; set; }

	public double? Volume { get; set; }
}