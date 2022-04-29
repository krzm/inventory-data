using EFCoreHelper;

namespace Inventory.Data;

public interface IInventoryUnitOfWork 
	: IUnitOfWork
{
	IGenericRepository<Category> Category { get; }
	IGenericRepository<Image> Image { get; }
	IGenericRepository<Item> Item { get; }
	IGenericRepository<Size> Size { get; }
	IGenericRepository<State> State { get; }
	IGenericRepository<Stock> Stock { get; }
	IGenericRepository<Tag> Tag { get; }
}