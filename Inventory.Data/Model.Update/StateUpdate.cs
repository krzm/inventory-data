using ModelHelper;

namespace Inventory.Data;

public class StateUpdate 
    : ModelAUpdate
    , IUpdatable<State>
{
    public int? CategoryId { get; set; }

    public void Update(State model)
    {
        base.Update(model);
        
        if (CategoryId.HasValue
            && CategoryId.Value != model.CategoryId)
            model.CategoryId = CategoryId.Value;
    }
}