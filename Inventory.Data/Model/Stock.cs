using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Data;

public class Stock
    : Model
{
	public int Id { get; set; }
    
    [MaxLength(DescriptionMaxLength)]
	public string? Description { get; set; }

	public int ItemId { get; set; }

    [ForeignKey(nameof(Tag))]
	public int? TagId { get; set; }

    public Item? Item { get; set; }

    public Tag? Tag { get; set; }

    public ICollection<State>? States { get; set; }

    public ICollection<Item>? Containers { get; set; }

    public ICollection<StockCount>? StockCounter { get; set; }
}