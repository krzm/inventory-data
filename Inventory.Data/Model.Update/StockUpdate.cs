using ModelHelper;

namespace Inventory.Data;

public class StockUpdate 
    : IUpdatable<Stock>
{
	public string? Description { get; set; }

    public int? ItemId { get; set; }

    public int? ContainerId { get; set; }

    public int? TagId { get; set; }

    public void Update(Stock model)
    {
        if (string.IsNullOrWhiteSpace(Description) == false
            && Description.Trim() != model.Description?.Trim())
            model.Description = Description;

        if (ItemId.HasValue
            && ItemId.Value != model.ItemId)
            model.ItemId = ItemId.Value;

        if (ContainerId.HasValue
            && ContainerId.Value != model.ContainerId)
            model.ContainerId = ContainerId.Value;
        
        if (TagId.HasValue
            && TagId.Value != model.TagId)
            model.TagId = TagId.Value;
    }
}