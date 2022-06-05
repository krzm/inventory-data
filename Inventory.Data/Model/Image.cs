using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Data;

public class Image
    : Model
{
	public int Id { get; set; }

    [Required]
	[MaxLength(PathMaxLength)]
	public string? Path { get; set; }

    [MaxLength(DescriptionMaxLength)]
	public string? Description { get; set; }

	[ForeignKey(nameof(Item))]
	public int ItemId { get; set; }

	public Item? Item { get; set; }
}