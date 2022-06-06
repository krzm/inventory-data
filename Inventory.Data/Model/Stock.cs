using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Data;

public class Stock
    : Model
{
	public int Id { get; set; }
    
	[ForeignKey(nameof(Item))]
	public int ItemId { get; set; }

    [ForeignKey(nameof(Tag))]
	public int? TagId { get; set; }
	
    [MaxLength(DescriptionMaxLength)]
	public string? Description { get; set; }

    public Item? Item { get; set; }

    public Tag? Tag { get; set; }

    public ICollection<State>? States { get; set; }

    public ICollection<Container>? Containers { get; set; }

    public ICollection<StockCount>? StockCounts { get; set; }
}