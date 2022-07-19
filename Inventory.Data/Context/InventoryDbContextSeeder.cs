using Microsoft.EntityFrameworkCore;

namespace Inventory.Data;

public abstract class InventoryDbContextSeeder
    : InventoryDbContextBase
{
    protected override void SeedData(ModelBuilder builder)
    {
        builder.Entity<SIUnit>()
            .HasData(
                GetSIUnit(1, "cm", "centimeter")
                , GetSIUnit(2, "l", "liter"));
    }

    private object GetSIUnit(int id, string symbol, string name)
    {
        return new 
        { 
            Id = id
            , Symbol = symbol
            , Name = name
            , CreatedDate = DateTime.Now
            , UpdatedDate = DateTime.Now
        };
    }
}