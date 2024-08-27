namespace CompositePattern;

public class Program
{
    /// <summary>
    /// El patrón Composite permite tratar objetos individuales y composiciones de objetos de manera uniforme. Es útil para representar jerarquías de objetos y tratar tanto objetos simples como compuestos de manera consistente.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        Console.WriteLine("Este ejemplo demuestra el patrón Composite, que permite tratar objetos individuales y composiciones de objetos de manera uniforme.");
        // Crear la estructura del árbol
        var root = new Composite("Root");

        var leaf1 = new Leaf("Leaf 1");
        var leaf2 = new Leaf("Leaf 2");

        var subTree = new Composite("SubTree");
        var leaf3 = new Leaf("Leaf 3");

        subTree.Add(leaf3);
        root.Add(leaf1);
        root.Add(leaf2);
        root.Add(subTree);

        // Ejecutar la operación
        Console.WriteLine("Estructura completa:");
        root.Operation();

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}

// Componente base
public abstract class Component
{
    protected string _name;

    public Component(string name)
    {
        _name = name;
    }

    public abstract void Operation();
    public virtual void Add(Component component) { }
    public virtual void Remove(Component component) { }
    public virtual bool IsComposite() => true;
}

// Hoja (Leaf)
public class Leaf : Component
{
    public Leaf(string name) : base(name) { }

    public override void Operation()
    {
        Console.WriteLine($"Hoja: {_name}");
    }

    public override bool IsComposite()
    {
        return false;
    }
}

// Compuesto (Composite)
public class Composite : Component
{
    private readonly List<Component> _children = new List<Component>();

    public Composite(string name) : base(name) { }

    public override void Operation()
    {
        Console.WriteLine($"Nodo Compuesto: {_name}");
        foreach (var child in _children)
        {
            child.Operation();
        }
    }

    public override void Add(Component component)
    {
        _children.Add(component);
    }

    public override void Remove(Component component)
    {
        _children.Remove(component);
    }
}

