namespace NullObject.Console;

public class Service: INullObject<Service>
{
    public static Service Null =>
        new()
        {
            Name = "Null Service",
            Description = "This is a null service"
        };

    public bool IsNull => this.Name == "Null Service" && this.Description == "This is a null service";

    public string Description { get; set; }

    public string Name { get; set; }
    
    public override string ToString()
    {
        return $"Name: {Name}, Description: {Description}" ;
    }
}