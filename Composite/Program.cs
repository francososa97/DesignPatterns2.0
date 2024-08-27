namespace DecoratorPattern;

class Program
{
    static void Main(string[] args)
    {
        // Crear un objeto Component simple
        IComponent component = new ConcreteComponent();
        Console.WriteLine("Component básico:");
        component.Operation();

        // Decorar el componente con ConcreteDecoratorA
        component = new ConcreteDecoratorA(component);
        Console.WriteLine("\nComponent con ConcreteDecoratorA:");
        component.Operation();

        // Decorar el componente con ConcreteDecoratorB
        component = new ConcreteDecoratorB(component);
        Console.WriteLine("\nComponent con ConcreteDecoratorB:");
        component.Operation();

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}

// Interfaz Component
public interface IComponent
{
    void Operation();
}

// Componente concreto
public class ConcreteComponent : IComponent
{
    public void Operation()
    {
        Console.WriteLine("Operación de ConcreteComponent.");
    }
}

// Decorador base
public abstract class Decorator : IComponent
{
    protected IComponent _component;

    public Decorator(IComponent component)
    {
        _component = component;
    }

    public virtual void Operation()
    {
        _component.Operation();
    }
}

// Decorador concreto A
public class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(IComponent component) : base(component) { }

    public override void Operation()
    {
        base.Operation();
        Console.WriteLine("Adicional de ConcreteDecoratorA.");
    }
}

// Decorador concreto B
public class ConcreteDecoratorB : Decorator
{
    public ConcreteDecoratorB(IComponent component) : base(component) { }

    public override void Operation()
    {
        base.Operation();
        Console.WriteLine("Adicional de ConcreteDecoratorB.");
    }
}
