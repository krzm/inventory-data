using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Data;

public class ItemImage
{
	public int Id { get; set; }

	[ForeignKey("Item")]
	public int ItemId { get; set; }

	[Required]
	[MaxLength(250)]
	public string Path { get; set; }

	public Item Item { get; set; }
}