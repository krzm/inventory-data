using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModelHelper;

namespace Inventory.Data;

public class Container
    : Model
    , IModelA
{
	public int Id { get; set; }
	
	[Required]
	[MaxLength(NameMaxLength)]
	public string? Name { get; set; }

    [MaxLength(DescriptionMaxLength)]
	public string? Description { get; set; }

    [ForeignKey(nameof(Data.Category))]
	public int CategoryId { get; set; }
    
	[ForeignKey(nameof(Container))]
	public int? ParentId { get; set; }
	
	[ForeignKey(nameof(Data.Size))]
	public int? SizeId { get; set; }

	public Category? Category { get; set; }
	
	public Container? Parent { get; set; }
	
	public Size? Size { get; set; }

	public ICollection<Image>? Images { get; set; }

    public List<Stock>? Stocks { get; set; }
}