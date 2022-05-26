using EFCore.Helper;
using Unity;
using UnityDependencySet = DIHelper.Unity.UnityDependencySet;

namespace Inventory.Data;

public class InventoryDatabase 
    :   UnityDependencySet
{
    public InventoryDatabase(
        IUnityContainer container) 
            : base(container)
    {
    }

    public override void Register()
    {
        RegisterDbContext();
        RegiserRepos();
        RegisterUnitOfWork();
    }

    protected void RegisterDbContext()
    {
        Container
            .RegisterSingleton<InventoryDbContext>();
    }

    private void RegiserRepos()
    {
        RegisterRepo<Category>();
        RegisterRepo<Image>();
        RegisterRepo<Item>();
        RegisterRepo<Size>();
        RegisterRepo<State>();
        RegisterRepo<Stock>();
        RegisterRepo<Tag>();
    }

    protected void RegisterRepo<TModel>()
        where TModel : class
    {
         Container
            .RegisterSingleton<
                IRepository<TModel>
                , EFRepository<TModel, InventoryDbContext>>();
    }

    private void RegisterUnitOfWork()
    {
        Container
            .RegisterSingleton<IInventoryUnitOfWork
                , InventoryUnitOfWork>();
    }
}