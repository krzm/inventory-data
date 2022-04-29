using ModelHelper;

namespace Inventory.Data;

public class CategoryUpdate 
    : ModelAUpdate
    , IUpdatable<Category>
{
    public int? ParentId { get; set; }

    public void Update(Category model)
    {
        base.Update(model);
        if (ParentId.HasValue
            && ParentId.Value != model.ParentId)
            model.ParentId = ParentId.Value;
    }
}