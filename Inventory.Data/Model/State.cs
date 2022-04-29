using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModelHelper;

namespace Inventory.Data;

public class State
    : Model
    , IModelA
{
	public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
	public string? Name { get; set; }

    [MaxLength(DescriptionMaxLength)]
	public string? Description { get; set; }

	[ForeignKey(nameof(Category))]
	public int CategoryId { get; set; }

	public Category? Category { get; set; }
}