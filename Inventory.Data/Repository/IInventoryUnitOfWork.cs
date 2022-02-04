using EFCoreHelper;

namespace Inventory.Data;

public interface IInventoryUnitOfWork 
	: IUnitOfWork
{
	IGenericRepository<Item> Item { get; }
	IGenericRepository<ItemCategory> ItemCategory { get; }
	IGenericRepository<ItemDetail> ItemDetail { get; }
	IGenericRepository<ItemImage> ItemImage { get; }
	IGenericRepository<Stock> Stock { get; }
	IGenericRepository<StockDetail> StockDetail { get; }
}