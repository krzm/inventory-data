using System;
using ModelHelper;

namespace Inventory.Data;

public class StockUpdate 
    : IUpdatable<Stock>
{
    public int? ItemId { get; set; }

    public int? ContainerId { get; set; }

    public DateTime? Stored { get; set; }

    public DateTime? Open { get; set; }

    public DateTime? Used { get; set; }

    public int? StockDetailId { get; set; }

    public void Update(Stock model)
    {
        if (ItemId.HasValue
            && ItemId.Value != model.ItemId)
            model.ItemId = ItemId.Value;
        if (ContainerId.HasValue
            && ContainerId.Value != model.ContainerId)
            model.ContainerId = ContainerId.Value;
    }
}