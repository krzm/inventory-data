using Core.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Data;

public class ItemCategory : IModelA
{
	public int Id { get; set; }
		
	[Required]
	[MaxLength(25)]
	public string Name { get; set; }

	[MaxLength(70)]
	public string Description { get; set; }

	public int? ParentId { get; set; }

	public ItemCategory Parent { get; set; }

	public IEnumerable<ItemCategory> Children { get; set; }
}