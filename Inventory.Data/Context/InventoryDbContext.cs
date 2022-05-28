using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory.Data;

public class InventoryDbContext
    : DbContext
{
	public DbSet<Category>? Category { get; set; }

	public DbSet<Image>? Image { get; set; }

	public DbSet<Item>? Item { get; set; }

	public DbSet<Size>? Size { get; set; }

	public DbSet<State>? State { get; set; }

	public DbSet<Stock>? Stock { get; set; }

	public DbSet<StockState>? StockState { get; set; }

	public DbSet<Tag>? Tag { get; set; }

    public static readonly Microsoft.Extensions.Logging.LoggerFactory myLoggerFactory = 
        new LoggerFactory(new[] { 
            new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider() 
        });

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
        var helper = new DbConfigHelper();
		optionsBuilder.UseSqlServer(helper.GetConnectionString());
        if(helper.Config.UseLogger)
            optionsBuilder.UseLoggerFactory(myLoggerFactory);
	}
}