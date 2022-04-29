using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Data;

public class StockState
    : Model
{
	public int Id { get; set; }

	[ForeignKey(nameof(Stock))]
	public int StockId { get; set; }

	[ForeignKey(nameof(State))]
	public int StateId { get; set; }

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime Created { get; set; }

    public Stock? Stock { get; set; }

    public State? State { get; set; }
}