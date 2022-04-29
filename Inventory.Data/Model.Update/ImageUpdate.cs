using ModelHelper;

namespace Inventory.Data;

#nullable enable
public class ImageUpdate 
    : IUpdatable<Image>
{
    public int? ItemId { get; set; }

    public string? Path { get; set; }

    public void Update(Image model)
    {
        if (ItemId.HasValue
            && ItemId.Value != model.ItemId)
            model.ItemId = ItemId.Value;
            
        if (string.IsNullOrWhiteSpace(Path) == false
           && Path.Trim() != model.Path.Trim())
            model.Path = Path;
    }
}