using Core;

namespace Inventory.Data;

#nullable enable
public class ItemDetailUpdate : IUpdatable<ItemDetail>
{
    public string? Description { get; set; }

    public double? Width { get; set; }

    public double? Depth { get; set; }

    public double? Heigth { get; set; }

    public double? Diameter { get; set; }

    public double? Volume { get; set; }

    public void Update(ItemDetail model)
    {
        if (string.IsNullOrWhiteSpace(Description) == false
            && Description.Trim() != model.Description?.Trim())
            model.Description = Description;
        if (Width.HasValue
            && Width.Value != model.Width)
            model.Width = Width.Value;
        if (Depth.HasValue
            && Depth.Value != model.Depth)
            model.Depth = Depth.Value;
        if (Heigth.HasValue
             && Heigth.Value != model.Heigth)
            model.Heigth = Heigth.Value;
        if (Diameter.HasValue
             && Diameter.Value != model.Diameter)
            model.Diameter = Diameter.Value;
        if (Volume.HasValue
            && Volume.Value != model.Volume)
            model.Volume = Volume.Value;
    }
}