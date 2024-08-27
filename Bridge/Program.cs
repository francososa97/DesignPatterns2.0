namespace BridgePattern;

public class Program
{
    /// <summary>
    /// El patrón Bridge separa la abstracción de su implementación, permitiendo que ambas evolucionen independientemente. Es útil para evitar un crecimiento exponencial en la cantidad de clases necesarias para representar combinaciones de abstracciones e implementaciones.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        Console.WriteLine("Este ejemplo demuestra el patrón Bridge, que separa la abstracción de su implementación para que ambas puedan evolucionar independientemente.");
        // Crear una abstracción refinada con una implementación concreta
        Abstraction abstraction1 = new RefinedAbstraction(new ConcreteImplementorA());
        abstraction1.Operation();

        // Cambiar la implementación de la misma abstracción
        Abstraction abstraction2 = new RefinedAbstraction(new ConcreteImplementorB());
        abstraction2.Operation();

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}

// Interfaz de Implementación
public interface IImplementor
{
    void OperationImpl();
}

// Abstracción
public abstract class Abstraction
{
    protected IImplementor implementor;

    protected Abstraction(IImplementor implementor)
    {
        this.implementor = implementor;
    }

    public abstract void Operation();
}

// Abstracción refinada
public class RefinedAbstraction : Abstraction
{
    public RefinedAbstraction(IImplementor implementor) : base(implementor)
    {
    }

    public override void Operation()
    {
        Console.WriteLine("RefinedAbstraction: Operation con:");
        implementor.OperationImpl();
    }
}



// Implementación concreta A
public class ConcreteImplementorA : IImplementor
{
    public void OperationImpl()
    {
        Console.WriteLine("ConcreteImplementorA: OperationImpl");
    }
}

// Implementación concreta B
public class ConcreteImplementorB : IImplementor
{
    public void OperationImpl()
    {
        Console.WriteLine("ConcreteImplementorB: OperationImpl");
    }
}
