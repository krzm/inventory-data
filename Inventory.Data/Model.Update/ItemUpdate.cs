using ModelHelper;

namespace Inventory.Data;

public class ItemUpdate 
    : ModelAUpdate 
    , IUpdatable<Item>
{
    public int? CategoryId { get; set; }

    public int? SizeId { get; set; }

    public void Update(Item model)
    {
        base.Update(model);
        
        if (CategoryId.HasValue
            && CategoryId.Value != model.CategoryId)
            model.CategoryId = CategoryId.Value;

        if (SizeId.HasValue
            && SizeId.Value != model.SizeId)
            model.SizeId = SizeId.Value;
    }
}