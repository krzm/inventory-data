using ModelHelper;

namespace Inventory.Data;

#nullable enable
public class SizeUpdate 
    : IUpdatable<Size>
{
    public double? Length { get; set; }
    public double? Heigth { get; set; }
	public double? Depth { get; set; }
    public double? Diameter { get; set; }
    public double? Volume { get; set; }
	public string? Description { get; set; }

    public void Update(Size model)
    {
        if (Length.HasValue
            && Length.Value != model.Length)
            model.Length = Length.Value;

        if (Heigth.HasValue
             && Heigth.Value != model.Heigth)
            model.Heigth = Heigth.Value;

        if (Depth.HasValue
            && Depth.Value != model.Depth)
            model.Depth = Depth.Value;
        
        if (Diameter.HasValue
             && Diameter.Value != model.Diameter)
            model.Diameter = Diameter.Value;
            
        if (Volume.HasValue
            && Volume.Value != model.Volume)
            model.Volume = Volume.Value;

         if (string.IsNullOrWhiteSpace(Description) == false
            && Description.Trim() != model.Description?.Trim())
            model.Description = Description;
    }
}