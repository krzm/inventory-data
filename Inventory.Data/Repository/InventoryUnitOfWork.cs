using System;
using EFCoreHelper;

namespace Inventory.Data;

public class InventoryUnitOfWork 
	: IInventoryUnitOfWork
{
	private readonly InventoryContext context;
	private readonly IGenericRepository<Item> item;
	private readonly IGenericRepository<ItemCategory> itemCategory;
	private readonly IGenericRepository<ItemDetail> itemDetail;
	private readonly IGenericRepository<ItemImage> itemImage;
	private readonly IGenericRepository<Stock> stock;
	private readonly IGenericRepository<StockDetail> stockDetail;
	private bool disposed = false;

	public IGenericRepository<Item> Item => item;
	public IGenericRepository<ItemCategory> ItemCategory => itemCategory;
	public IGenericRepository<ItemDetail> ItemDetail => itemDetail;
	public IGenericRepository<ItemImage> ItemImage => itemImage;
	public IGenericRepository<Stock> Stock => stock;
	public IGenericRepository<StockDetail> StockDetail => stockDetail;

    public InventoryUnitOfWork(
		InventoryContext context
		, IGenericRepository<Item> item
		, IGenericRepository<ItemCategory> itemCategory
		, IGenericRepository<ItemDetail> itemDetail
		, IGenericRepository<ItemImage> itemImage
		, IGenericRepository<Stock> stock
		, IGenericRepository<StockDetail> stockDetail)
    {
		this.context = context;
		this.item = item;
		this.itemCategory = itemCategory;
		this.itemDetail = itemDetail;
        this.itemImage = itemImage;
        this.stock = stock;
		this.stockDetail = stockDetail;

		ArgumentNullException.ThrowIfNull(this.context);
		ArgumentNullException.ThrowIfNull(this.item);
		ArgumentNullException.ThrowIfNull(this.itemCategory);
		ArgumentNullException.ThrowIfNull(this.itemDetail);
		ArgumentNullException.ThrowIfNull(this.itemImage);
		ArgumentNullException.ThrowIfNull(this.stock);
		ArgumentNullException.ThrowIfNull(this.stockDetail);
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