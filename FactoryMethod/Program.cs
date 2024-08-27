namespace FactoryMethodPattern;

class Program
{
    static void Main(string[] args)
    {
        // Crear una fábrica de productos de tipo ConcreteProductA
        Creator creatorA = new ConcreteCreatorA();
        IProduct productA = creatorA.FactoryMethod();
        Console.WriteLine("Producto creado por ConcreteCreatorA:");
        productA.Operation();

        // Crear una fábrica de productos de tipo ConcreteProductB
        Creator creatorB = new ConcreteCreatorB();
        IProduct productB = creatorB.FactoryMethod();
        Console.WriteLine("Producto creado por ConcreteCreatorB:");
        productB.Operation();

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}

// Interfaz Producto
public interface IProduct
{
    void Operation();
}

// Producto concreto A
public class ConcreteProductA : IProduct
{
    public void Operation()
    {
        Console.WriteLine("Operación del ConcreteProductA.");
    }
}

// Producto concreto B
public class ConcreteProductB : IProduct
{
    public void Operation()
    {
        Console.WriteLine("Operación del ConcreteProductB.");
    }
}

// Clase creadora abstracta
public abstract class Creator
{
    // Método de fábrica
    public abstract IProduct FactoryMethod();
}

// Creador concreto A
public class ConcreteCreatorA : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductA();
    }
}

// Creador concreto B
public class ConcreteCreatorB : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductB();
    }
}
