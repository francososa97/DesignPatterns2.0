namespace CQRS;


// Comando para agregar un producto
public class AddProductCommand
{
    public string Name { get; }
    public double Price { get; }

    public AddProductCommand(string name, double price)
    {
        Name = name;
        Price = price;
    }
}

// Consulta para obtener la lista de productos
public class GetProductsQuery { }

// Modelo de Producto
public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
}

// Handler para Comandos
public class ProductCommandHandler
{
    private readonly List<Product> _products;

    public ProductCommandHandler(List<Product> products)
    {
        _products = products;
    }

    public void Handle(AddProductCommand command)
    {
        var product = new Product { Name = command.Name, Price = command.Price };
        _products.Add(product);
        Console.WriteLine($"Producto agregado: {product.Name}, Precio: {product.Price:C}");
    }
}

// Handler para Consultas
public class ProductQueryHandler
{
    private readonly List<Product> _products;

    public ProductQueryHandler(List<Product> products)
    {
        _products = products;
    }

    public IEnumerable<Product> Handle(GetProductsQuery query)
    {
        return _products;
    }
}

public class Program
{
    /// <summary>
    ///  El patrón CQRS separa las operaciones de lectura y escritura en diferentes modelos, optimizando cada uno para sus respectivas tareas. Es útil en sistemas donde las operaciones de lectura y escritura tienen diferentes requisitos de rendimiento.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        Console.WriteLine("Este ejemplo demuestra el patrón CQRS (Command Query Responsibility Segregation), que separa las operaciones de lectura y escritura en diferentes modelos.");
        // Lista compartida de productos (actúa como nuestra "base de datos" en memoria)
        var products = new List<Product>();

        // Crear handlers para comandos y consultas
        var commandHandler = new ProductCommandHandler(products);
        var queryHandler = new ProductQueryHandler(products);

        // Ejemplo de uso de CQRS

        // Agregar productos (escritura)
        commandHandler.Handle(new AddProductCommand("Laptop", 1500.00));
        commandHandler.Handle(new AddProductCommand("Smartphone", 800.00));

        // Obtener productos (lectura)
        var productsQuery = new GetProductsQuery();
        var productList = queryHandler.Handle(productsQuery);

        Console.WriteLine("\nLista de Productos:");
        foreach (var product in productList)
        {
            Console.WriteLine($"- {product.Name}: {product.Price:C}");
        }

        Console.ReadKey();
    }
}
