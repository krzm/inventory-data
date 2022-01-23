using Microsoft.EntityFrameworkCore;

namespace Inventory.Data;

public class InventoryContext : DbContext
{
	public DbSet<ItemCategory> ItemCategory { get; set; }

	public DbSet<Item> Item { get; set; }

	public DbSet<ItemDetail> ItemDetail { get; set; }

	public DbSet<ItemImage> ItemImage { get; set; }

	public DbSet<Stock> Stock { get; set; }

	public DbSet<StockDetail> StockDetail { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=InventoryData");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.Entity<Stock>()
			.HasOne(r => r.Item)
			.WithMany()
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Stock>()
			.HasOne(r => r.Container)
			.WithMany()
			.OnDelete(DeleteBehavior.Restrict);
    }
}