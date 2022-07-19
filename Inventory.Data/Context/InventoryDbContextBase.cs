using EFCore.Helper;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Data;

public abstract class InventoryDbContextBase
    : DbContextExtended
{
	public DbSet<Category>? Category { get; set; }
	public DbSet<Container>? Container { get; set; }
	public DbSet<Image>? Image { get; set; }
	public DbSet<Item>? Item { get; set; }
	public DbSet<SIUnit>? SIUnit { get; set; }
	public DbSet<Size>? Size { get; set; }
	public DbSet<State>? State { get; set; }
	public DbSet<Stock>? Stock { get; set; }
	public DbSet<Tag>? Tag { get; set; }
}