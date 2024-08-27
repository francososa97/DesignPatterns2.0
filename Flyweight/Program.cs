namespace FlyweightPattern;

class Program
{
    static void Main(string[] args)
    {
        // Crear la fábrica Flyweight
        var factory = new FlyweightFactory();

        // Obtener Flyweights y utilizarlos
        var flyweight1 = factory.GetFlyweight("TypeA");
        flyweight1.Operation(new ExtrinsicState { Color = "Red", Position = 1 });

        var flyweight2 = factory.GetFlyweight("TypeB");
        flyweight2.Operation(new ExtrinsicState { Color = "Green", Position = 2 });

        // Obtener un Flyweight existente y reutilizarlo
        var flyweight3 = factory.GetFlyweight("TypeA");
        flyweight3.Operation(new ExtrinsicState { Color = "Blue", Position = 3 });

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}

// Estado extrínseco
public class ExtrinsicState
{
    public string Color { get; set; }
    public int Position { get; set; }
}

// Interfaz Flyweight
public interface IFlyweight
{
    void Operation(ExtrinsicState extrinsicState);
}

// Clase Flyweight concreta
public class ConcreteFlyweight : IFlyweight
{
    private readonly string _intrinsicState;

    public ConcreteFlyweight(string intrinsicState)
    {
        _intrinsicState = intrinsicState;
    }

    public void Operation(ExtrinsicState extrinsicState)
    {
        Console.WriteLine($"Flyweight con estado intrínseco {_intrinsicState} y estado extrínseco color {extrinsicState.Color}, posición {extrinsicState.Position}");
    }
}

// Fábrica Flyweight
public class FlyweightFactory
{
    private readonly Dictionary<string, IFlyweight> _flyweights = new Dictionary<string, IFlyweight>();

    public IFlyweight GetFlyweight(string key)
    {
        if (!_flyweights.ContainsKey(key))
        {
            _flyweights[key] = new ConcreteFlyweight(key);
            Console.WriteLine($"Creando nuevo Flyweight para la clave {key}");
        }
        else
        {
            Console.WriteLine($"Reutilizando Flyweight existente para la clave {key}");
        }

        return _flyweights[key];
    }
}
