namespace Inventory.Data;

public abstract class Model
{
    protected const int NameMaxLength = 70;
    protected const int DescriptionMaxLength = 160;
    protected const int PathMaxLength = 260;
    protected const double MaxDoubleValue = 1000000;
    protected const string IdError = "Id must be greater than zero";
}