namespace BuilderPattern;

public class Program
{
    /// <summary>
    ///  El patrón Builder permite construir objetos complejos paso a paso, separando la construcción de la representación final. Es útil cuando un objeto puede construirse de muchas maneras diferentes.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        Console.WriteLine("Este ejemplo demuestra el patrón Builder, que permite construir objetos complejos paso a paso, separando la construcción de la representación final.");
        // Crear el director y los builders
        var director = new Director();
        var carBuilder = new CarBuilder();
        var truckBuilder = new TruckBuilder();

        // Construir un coche
        director.ConstructSportsCar(carBuilder);
        var car = carBuilder.GetResult();
        Console.WriteLine($"Car built:\n{car.ListParts()}");

        // Construir un camión
        director.ConstructTruck(truckBuilder);
        var truck = truckBuilder.GetResult();
        Console.WriteLine($"Truck built:\n{truck.ListParts()}");

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}

// Producto final
public class Vehicle
{
    private readonly List<object> _parts = new List<object>();

    public void AddPart(string part)
    {
        _parts.Add(part);
    }

    public string ListParts()
    {
        return "Parts: " + string.Join(", ", _parts);
    }
}

// Interfaz Builder
public interface IVehicleBuilder
{
    void BuildPartA();
    void BuildPartB();
    void BuildPartC();
    Vehicle GetResult();
}

// Builder concreto para un coche
public class CarBuilder : IVehicleBuilder
{
    private Vehicle _vehicle = new Vehicle();

    public void BuildPartA()
    {
        _vehicle.AddPart("Car Part A");
    }

    public void BuildPartB()
    {
        _vehicle.AddPart("Car Part B");
    }

    public void BuildPartC()
    {
        _vehicle.AddPart("Car Part C");
    }

    public Vehicle GetResult()
    {
        return _vehicle;
    }
}

// Builder concreto para un camión
public class TruckBuilder : IVehicleBuilder
{
    private Vehicle _vehicle = new Vehicle();

    public void BuildPartA()
    {
        _vehicle.AddPart("Truck Part A");
    }

    public void BuildPartB()
    {
        _vehicle.AddPart("Truck Part B");
    }

    public void BuildPartC()
    {
        _vehicle.AddPart("Truck Part C");
    }

    public Vehicle GetResult()
    {
        return _vehicle;
    }
}

// Director que define el orden de construcción
public class Director
{
    public void ConstructSportsCar(IVehicleBuilder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
        builder.BuildPartC();
    }

    public void ConstructTruck(IVehicleBuilder builder)
    {
        builder.BuildPartA();
        builder.BuildPartC();
    }
}
