using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Data;

public class StockCount
    : Model
{
	public int Id { get; set; }

	[ForeignKey(nameof(Stock))]
	public int StockId { get; set; }

	public int Count { get; set; }

    [MaxLength(DescriptionMaxLength)]
	public string? Description { get; set; }
    
    public Stock? Stock { get; set; }
}