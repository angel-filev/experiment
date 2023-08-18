namespace NullObject.Console;

public class Product : INullObject<Product>
{
    public string Name { get; set; }
    public string Description { get; set; }

    public static Product Null =>
        new()
        {
            Name = "Null Product",
            Description = "This is a null product"
        };

    public override string ToString()
    {
        return $"Name: {Name}, Description: {Description}" ;
    }
}