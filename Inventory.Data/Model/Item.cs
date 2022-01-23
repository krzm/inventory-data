using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Data;

public class Item
{
	public int Id { get; set; }

	[ForeignKey("ItemCategory")]
	public int ItemCategoryId { get; set; }

	[Required]
	[MaxLength(25)]
	public string Name { get; set; }

	[ForeignKey("ItemDetail")]
	public int? ItemDetailId { get; set; }

	public ItemCategory ItemCategory { get; set; }

	public ItemDetail ItemDetail { get; set; }

	public ICollection<ItemImage> Images { get; set; }
}