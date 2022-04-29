using ModelHelper;

namespace Inventory.Data;

public class TagUpdate
    : ModelAUpdate
    , IUpdatable<Tag>
{
    public void Update(Tag model)
    {
        base.Update(model);
    }
}