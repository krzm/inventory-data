using ModelHelper;

namespace Inventory.Data;

#nullable enable
public class ItemImageUpdate 
    : IUpdatable<ItemImage>
{
    public int? ItemId { get; set; }

    public string? Path { get; set; }

    public void Update(ItemImage model)
    {
        if (ItemId.HasValue
            && ItemId.Value != model.ItemId)
            model.ItemId = ItemId.Value;
        if (string.IsNullOrWhiteSpace(Path) == false
           && Path.Trim() != model.Path.Trim())
            model.Path = Path;
    }
}