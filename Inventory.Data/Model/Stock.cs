using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Data;

public class Stock
{
	public int Id { get; set; }

	public int ItemId { get; set; }

	public int ContainerId { get; set; }

	[Column(TypeName = "datetime2")]
	public DateTime Stored { get; set; }

	[Column(TypeName = "datetime2")]
	public DateTime? Open { get; set; }

	[Column(TypeName = "datetime2")]
	public DateTime? Used { get; set; }
	
	[ForeignKey("StockDetail")]
	public int? StockDetailId { get; set; }

	public Item Item { get; set; }

	public Item Container { get; set; }

	public StockDetail StockDetail { get; set; }
}