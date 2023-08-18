// See https://aka.ms/new-console-template for more information

using NullObject;
using NullObject.Console;

Console.WriteLine("Hello, from NullObject World!");

INullObject<Product> nulProduct = Product.Null;

Console.WriteLine($"Null Product is null: {nulProduct.IsNull}");

INullObject<Product> awesomeProduct = new Product()
{
    Name = "Awesome Product",
    Description = "A product that is awesome"
};
Console.WriteLine($"Awesome Product is null: {awesomeProduct.IsNull}");

INullObject<Service> nullService = Service.Null;

Console.WriteLine($"Null Service is null: {nullService.IsNull}");

INullObject<Service> fastService = new Service() { 
    Name = "Fast Service",
    Description = "A service that is fast"
};
Console.WriteLine($"Fast Service null: {fastService.IsNull}");