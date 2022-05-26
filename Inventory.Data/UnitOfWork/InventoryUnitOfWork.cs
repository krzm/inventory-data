using EFCore.Helper;

namespace Inventory.Data;

public class InventoryUnitOfWork 
	: UnitOfWork
        , IInventoryUnitOfWork
{
	private readonly InventoryDbContext inventoryDbContext;
	private readonly IRepository<Category> category;
	private readonly IRepository<Image> image;
	private readonly IRepository<Item> item;
	private readonly IRepository<Size> size;
	private readonly IRepository<State> state;
	private readonly IRepository<Stock> stock;
	private readonly IRepository<Tag> tag;

	public IRepository<Category> Category => category;
	public IRepository<Image> Image => image;
	public IRepository<Item> Item => item;
	public IRepository<Size> Size => size;
	public IRepository<State> State => state;
	public IRepository<Stock> Stock => stock;
	public IRepository<Tag> Tag => tag;

    public InventoryUnitOfWork(
		InventoryDbContext inventoryDbContext
		, IRepository<Category> category
		, IRepository<Image> image
		, IRepository<Item> item
		, IRepository<Size> size
		, IRepository<State> state
		, IRepository<Stock> stock
		, IRepository<Tag> tag) : base(inventoryDbContext)
    {
		this.inventoryDbContext = inventoryDbContext;
		this.category = category;
        this.image = image;
		this.item = item;
		this.size = size;
		this.state = state;
        this.stock = stock;
		this.tag = tag;

		ArgumentNullException.ThrowIfNull(this.inventoryDbContext);
		ArgumentNullException.ThrowIfNull(this.category);
		ArgumentNullException.ThrowIfNull(this.image);
		ArgumentNullException.ThrowIfNull(this.item);
		ArgumentNullException.ThrowIfNull(this.size);
		ArgumentNullException.ThrowIfNull(this.state);
		ArgumentNullException.ThrowIfNull(this.stock);
		ArgumentNullException.ThrowIfNull(this.tag);
	}
}