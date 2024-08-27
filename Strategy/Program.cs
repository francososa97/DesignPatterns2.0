namespace StrategyPattern;

class Program
{
    static void Main(string[] args)
    {
        // Crear el contexto con una estrategia inicial
        var context = new Context(new ConcreteStrategyA());
        Console.WriteLine("Estrategia inicial:");
        context.ExecuteStrategy();

        // Cambiar la estrategia en tiempo de ejecución
        context.SetStrategy(new ConcreteStrategyB());
        Console.WriteLine("\nEstrategia después de cambiar:");
        context.ExecuteStrategy();

        Console.ReadKey();
    }
}

// Interfaz Strategy
public interface IStrategy
{
    void Execute();
}

// Estrategia concreta A
public class ConcreteStrategyA : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Estrategia A ejecutada.");
    }
}

// Estrategia concreta B
public class ConcreteStrategyB : IStrategy
{
    public void Execute()
    {
        Console.WriteLine("Estrategia B ejecutada.");
    }
}

// Contexto que utiliza una estrategia
public class Context
{
    private IStrategy _strategy;

    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void ExecuteStrategy()
    {
        _strategy.Execute();
    }
}
