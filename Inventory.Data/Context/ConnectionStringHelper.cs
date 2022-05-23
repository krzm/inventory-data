namespace Inventory.Data;

public static class ConnectionStringHelper
{
    public static string GetConnectionString()
    {
        var config = Config.Wrapper.ConfigTool.ReadConfig<DbConfig>();
        if (config == null)
            throw new Exception($"Cant load config section {nameof(DbConfig)}");
        else
        {
            switch (config.DbType)
            {
                case DbType.Local:
                    return config.LocalConnectionString!;
                case DbType.LocalTest:
                    return config.LocalTestConnectionString!;
                default :
                    return config.LocalConnectionString!;
            }
        }
    }
}