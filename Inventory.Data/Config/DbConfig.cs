namespace Inventory.Data;

public class DbConfig
{
    private string? dbTypeKey;

    public DbType? DbType { get; private set; }

    public string? DbTypeKey
    {
        get => dbTypeKey; set
        {
            dbTypeKey = value;
            if(Enum.TryParse(dbTypeKey, true, out DbType result) == false)
            {
                throw new ArgumentException("DbTypeKey should have value Local or LocalTest");
            }
            else
            {
                DbType = result;
            }
        }
    }

    public string? LocalTestConnectionString { get; set; }

    public string? LocalConnectionString { get; set; }

    public bool UseLogger { get; set; }
}