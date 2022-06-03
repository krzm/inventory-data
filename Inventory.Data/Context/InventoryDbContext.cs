using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Inventory.Data;

public class InventoryDbContext
    : DbContext
{
	public DbSet<Category>? Category { get; set; }

	public DbSet<Image>? Image { get; set; }

	public DbSet<Item>? Item { get; set; }

	public DbSet<Container>? Container { get; set; }

	public DbSet<Size>? Size { get; set; }

	public DbSet<State>? State { get; set; }

	public DbSet<Stock>? Stock { get; set; }

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
        .SelectMany(t => t.GetForeignKeys())
        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;

        var allEntities = modelBuilder.Model.GetEntityTypes();

        foreach (var entity in allEntities)
        {
            entity.AddProperty("CreatedDate",typeof(DateTime));
            entity.AddProperty("UpdatedDate",typeof(DateTime));
        }

        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e =>
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified);

        foreach (var entityEntry in entries)
        {
            entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now;
            }
        }

        return base.SaveChanges();
    }
}