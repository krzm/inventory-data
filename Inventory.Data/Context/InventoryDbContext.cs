using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

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

    public static readonly LoggerFactory myLoggerFactory = 
        new LoggerFactory(new[] { new DebugLoggerProvider() });

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        ConfigureContextByJsonFileSystem(optionsBuilder);
    }

    private static void ConfigureContextByJsonFileSystem(DbContextOptionsBuilder optionsBuilder)
    {
        var helper = new DbConfigHelper();
        optionsBuilder.UseSqlServer(helper.GetConnectionString());
        if (helper.Config.UseLogger)
            optionsBuilder.UseLoggerFactory(myLoggerFactory);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SetRestrictDeleteBehaviorPolicy(modelBuilder);
        SetModDatesShadowPropsToAllEntities(modelBuilder);
        SeedData(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private static void SetRestrictDeleteBehaviorPolicy(ModelBuilder modelBuilder)
    {
        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;
    }

    private static void SetModDatesShadowPropsToAllEntities(ModelBuilder modelBuilder)
    {
        var allEntities = modelBuilder.Model.GetEntityTypes();

        foreach (var entity in allEntities)
        {
            entity.AddProperty("CreatedDate", typeof(DateTime));
            entity.AddProperty("UpdatedDate", typeof(DateTime));
        }
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SIUnit>()
            .HasData(
                new SIUnit { Id = 1, Symbol = "cm", Name = "centimeter" }
                , new SIUnit { Id = 2, Symbol = "l", Name = "liter" });
    }

    public override int SaveChanges()
    {
        SetModDatesShadowProps();
        return base.SaveChanges();
    }

    private void SetModDatesShadowProps()
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
    }
}