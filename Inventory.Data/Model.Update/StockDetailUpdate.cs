using Core;

namespace Inventory.Data;

#nullable enable
public class StockDetailUpdate : IUpdatable<StockDetail>
{
    public string? Description { get; set; }

    public void Update(StockDetail model)
    {
        if (string.IsNullOrWhiteSpace(Description) == false
            && Description.Trim() != model.Description.Trim())
            model.Description = Description;
    }
}