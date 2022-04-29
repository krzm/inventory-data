using System;
using EFCoreHelper;

namespace Inventory.Data;

public class InventoryUnitOfWork 
	: IInventoryUnitOfWork
{
	private readonly InventoryContext context;
	private readonly IGenericRepository<Category> category;
	private readonly IGenericRepository<Image> image;
	private readonly IGenericRepository<Item> item;
	private readonly IGenericRepository<Size> size;
	private readonly IGenericRepository<State> state;
	private readonly IGenericRepository<Stock> stock;
	private readonly IGenericRepository<Tag> tag;
	private bool disposed = false;

	public IGenericRepository<Category> Category => category;
	public IGenericRepository<Image> Image => image;
	public IGenericRepository<Item> Item => item;
	public IGenericRepository<Size> Size => size;
	public IGenericRepository<State> State => state;
	public IGenericRepository<Stock> Stock => stock;
	public IGenericRepository<Tag> Tag => tag;

    public InventoryUnitOfWork(
		InventoryContext context
		, IGenericRepository<Category> category
		, IGenericRepository<Image> image
		, IGenericRepository<Item> item
		, IGenericRepository<Size> size
		, IGenericRepository<State> state
		, IGenericRepository<Stock> stock
		, IGenericRepository<Tag> tag)
    {
		this.context = context;
		this.category = category;
        this.image = image;
		this.item = item;
		this.size = size;
		this.state = state;
        this.stock = stock;
		this.tag = tag;

		ArgumentNullException.ThrowIfNull(this.context);
		ArgumentNullException.ThrowIfNull(this.category);
		ArgumentNullException.ThrowIfNull(this.image);
		ArgumentNullException.ThrowIfNull(this.item);
		ArgumentNullException.ThrowIfNull(this.size);
		ArgumentNullException.ThrowIfNull(this.state);
		ArgumentNullException.ThrowIfNull(this.stock);
		ArgumentNullException.ThrowIfNull(this.tag);
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposed)
		{
			if (disposing)
			{
				context.Dispose();
			}
		}
		disposed = true;
	}

    public void Save() => 
		context.SaveChanges();
}