using System.ComponentModel.DataAnnotations.Schema; // [Column]
namespace Packt.Shared;

public class Category
{
    // these properies map to columns in the database
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
    [Column(TypeName = "ntext")]
    public string? Description { get; set; }
    // defines a navigation property for related rows
    public virtual ICollection<Product> Products { get; set; }
    public Category()
    {
        // to enable develpers to add products to a Catefory we must
        // initilize the navigation property to an empty collection
        Products = new HashSet<Product>();
    }
}
