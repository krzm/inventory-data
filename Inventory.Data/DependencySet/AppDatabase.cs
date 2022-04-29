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
            .RegisterSingleton<IInventoryUnitOfWork, InventoryUnitOfWork>();
        RegRepo<Category>();
        RegRepo<Image>();
        RegRepo<Item>();
        RegRepo<Size>();
        RegRepo<State>();
        RegRepo<Stock>();
        RegRepo<Tag>();
    }

    private void RegRepo<TModel>()
        where TModel : class
    {
         Container
            .RegisterSingleton<IGenericRepository<TModel>, EFGenericRepository<TModel, InventoryContext>>();
    }
}