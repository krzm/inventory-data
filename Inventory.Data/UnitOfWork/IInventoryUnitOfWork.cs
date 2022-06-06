using EFCore.Helper;

namespace Inventory.Data;

public interface IInventoryUnitOfWork 
	: IUnitOfWork
{
	IRepository<Category> Category { get; }
	IRepository<Image> Image { get; }
	IRepository<Item> Item { get; }
	IRepository<Size> Size { get; }
	IRepository<State> State { get; }
	IRepository<Stock> Stock { get; }
	IRepository<StockCount> StockCount { get; }
	IRepository<Tag> Tag { get; }
}