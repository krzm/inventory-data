using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Data;

public class Item
    : Model
{
	public int Id { get; set; }
	
	[Required]
	[MaxLength(NameMaxLength)]
	public string? Name { get; set; }

    [MaxLength(DescriptionMaxLength)]
	public string? Description { get; set; }

    [ForeignKey(nameof(Data.Category))]
	public int CategoryId { get; set; }
    
	[ForeignKey(nameof(Data.Size))]
	public int? SizeId { get; set; }

	public Category? Category { get; set; }

	public Size? Size { get; set; }

	public ICollection<Image>? Images { get; set; }
}