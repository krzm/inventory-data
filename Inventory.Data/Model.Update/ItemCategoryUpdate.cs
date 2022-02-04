using ModelHelper;

namespace Inventory.Data;

public class ItemCategoryUpdate 
    : ModelAUpdate
    , IUpdatable<ItemCategory>
{
    public int? ParentId { get; set; }

    public void Update(ItemCategory model)
    {
        base.Update(model);
        if (ParentId.HasValue
            && ParentId.Value != model.ParentId)
            model.ParentId = ParentId.Value;
    }
}