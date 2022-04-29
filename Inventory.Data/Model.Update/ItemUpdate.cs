using ModelHelper;

namespace Inventory.Data;

#nullable enable
public class ItemUpdate 
    : IUpdatable<Item>
{
    public int? ItemCategoryId { get; set; }

    public string? Name { get; set; }

    public int? ItemDetailId { get; set; }

    public void Update(Item model)
    {
        if (ItemCategoryId.HasValue
            && ItemCategoryId.Value != model.CategoryId)
            model.CategoryId = ItemCategoryId.Value;
        if (string.IsNullOrWhiteSpace(Name) == false
           && Name.Trim() != model.Name.Trim())
            model.Name = Name;
        if (ItemDetailId.HasValue
            && ItemDetailId.Value != model.SizeId)
            model.SizeId = ItemDetailId.Value;
    }
}