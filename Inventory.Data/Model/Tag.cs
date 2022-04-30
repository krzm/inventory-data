using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModelHelper;

namespace Inventory.Data;

public class Tag
    : Model
    , IModelA
{
	public int Id { get; set; }

    [MaxLength(NameMaxLength)]
	public string? Name { get; set; }

    [MaxLength(DescriptionMaxLength)]
	public string? Description { get; set; }

	[Required]
    [Column(TypeName = "datetime2")]
    public DateTime Created { get; set; }
}