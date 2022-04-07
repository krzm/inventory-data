using EFCoreHelper;
using Unity;

namespace Inventory.Data;

public class AppDatabase 
    : DIHelper.Unity.UnityDependencySet
{
    public AppDatabase(
        IUnityContainer container) 
            : base(container)
    {
    }

    public override void Register()
    {
        Container
            .RegisterSingleton<InventoryContext>()

            .RegisterSingleton<IGenericRepository<Item>, EFGenericRepository<Item, InventoryContext>>()
            .RegisterSingleton<IGenericRepository<ItemCategory>, EFGenericRepository<ItemCategory, InventoryContext>>()
            .RegisterSingleton<IGenericRepository<ItemDetail>, EFGenericRepository<ItemDetail, InventoryContext>>()
            .RegisterSingleton<IGenericRepository<ItemImage>, EFGenericRepository<ItemImage, InventoryContext>>()
            .RegisterSingleton<IGenericRepository<Stock>, EFGenericRepository<Stock, InventoryContext>>()
            .RegisterSingleton<IGenericRepository<StockDetail>, EFGenericRepository<StockDetail, InventoryContext>>()

            .RegisterSingleton<IInventoryUnitOfWork, InventoryUnitOfWork>();
    }
}