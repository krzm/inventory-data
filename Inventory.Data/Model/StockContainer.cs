using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Data;

public class StockContainer
    : Model
{
	public int Id { get; set; }

	[ForeignKey(nameof(Stock))]
	public int StockId { get; set; }

	[ForeignKey(nameof(Item))]
	public int ItemId { get; set; }

    [MaxLength(DescriptionMaxLength)]
	public string? Description { get; set; }

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime Created { get; set; }

    public Stock? Stock { get; set; }

    public Item? Item { get; set; }
}