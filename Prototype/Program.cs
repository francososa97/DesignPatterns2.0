namespace PrototypePattern;

class Program
{
    static void Main(string[] args)
    {
        // Crear un prototipo concreto
        var originalPrototype = new ConcretePrototype("Prototype 1", 100);
        Console.WriteLine("Original Prototype:");
        originalPrototype.Display();

        // Clonar el prototipo
        var clonedPrototype = originalPrototype.Clone();
        Console.WriteLine("\nCloned Prototype:");
        clonedPrototype.Display();

        // Modificar el clon y mostrar ambos para ver que son independientes
        clonedPrototype.Name = "Prototype 2";
        clonedPrototype.Value = 200;

        Console.WriteLine("\nAfter Modification:");
        Console.WriteLine("Original Prototype:");
        originalPrototype.Display();
        Console.WriteLine("Cloned Prototype:");
        clonedPrototype.Display();

        Console.ReadKey();
    }
}

// Interfaz Prototype
public abstract class Prototype
{
    public string Name { get; set; }
    public int Value { get; set; }

    public Prototype(string name, int value)
    {
        Name = name;
        Value = value;
    }

    // Método de clonación
    public abstract Prototype Clone();

    public void Display()
    {
        Console.WriteLine($"Name: {Name}, Value: {Value}");
    }
}

// Prototipo concreto
public class ConcretePrototype : Prototype
{
    public ConcretePrototype(string name, int value) : base(name, value) { }

    // Implementación del método de clonación
    public override Prototype Clone()
    {
        return (Prototype)this.MemberwiseClone();
    }
}
