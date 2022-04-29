using System.ComponentModel.DataAnnotations;

namespace Inventory.Data;

public class Size
    : Model
{
	public int Id { get; set; }

    [Required]
	public double Length { get; set; }

    [Required]
	public double Heigth { get; set; }

    [Required]
	public double Depth { get; set; }

    public double?  Diameter { get; set; }

	public double? Volume { get; set; }

	[MaxLength(DescriptionMaxLength)]
	public string Description { get; set; }
}