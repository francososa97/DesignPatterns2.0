namespace FacadePattern;

public class Program
{
    /// <summary>
    /// El patrón Facade proporciona una interfaz simplificada a un conjunto complejo de interfaces en un subsistema. Es útil para hacer que un sistema sea más fácil de usar y entender.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        Console.WriteLine("Este ejemplo demuestra el patrón Facade, que proporciona una interfaz simplificada a un conjunto complejo de interfaces en un subsistema.");
        // Crear la fachada
        var facade = new Facade();

        // Utilizar la fachada para realizar operaciones complejas
        Console.WriteLine("Utilizando la fachada para operaciones simples:");
        facade.OperationA();
        facade.OperationB();

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}

// Subsistema 1
public class Subsystem1
{
    public void Operation1()
    {
        Console.WriteLine("Subsystem1: Ejecutando operación 1.");
    }
}

// Subsistema 2
public class Subsystem2
{
    public void Operation2()
    {
        Console.WriteLine("Subsystem2: Ejecutando operación 2.");
    }
}

// Subsistema 3
public class Subsystem3
{
    public void Operation3()
    {
        Console.WriteLine("Subsystem3: Ejecutando operación 3.");
    }
}

// Clase Facade
public class Facade
{
    private readonly Subsystem1 _subsystem1;
    private readonly Subsystem2 _subsystem2;
    private readonly Subsystem3 _subsystem3;

    public Facade()
    {
        _subsystem1 = new Subsystem1();
        _subsystem2 = new Subsystem2();
        _subsystem3 = new Subsystem3();
    }

    public void OperationA()
    {
        Console.WriteLine("Facade: Realizando operación A usando subsistemas:");
        _subsystem1.Operation1();
        _subsystem2.Operation2();
    }

    public void OperationB()
    {
        Console.WriteLine("Facade: Realizando operación B usando subsistemas:");
        _subsystem2.Operation2();
        _subsystem3.Operation3();
    }
}
