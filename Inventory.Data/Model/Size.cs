using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Data;

public class Size
    : Model
{
	public int Id { get; set; }

    [ForeignKey(nameof(SIUnit))]
	public int LengthUnit { get; set; }
    
    [ForeignKey(nameof(SIUnit))]
	public int VolumeUnit { get; set; }

	public double? Length { get; set; }

	public double? Heigth { get; set; }

	public double? Depth { get; set; }

    public double?  Diameter { get; set; }

	public double? Volume { get; set; }

	[MaxLength(DescriptionMaxLength)]
	public string? Description { get; set; }
}