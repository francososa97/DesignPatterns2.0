namespace AdapterPattern;

public class Program
{
    /// <summary>
    /// El patrón Adapter permite que interfaces incompatibles trabajen juntas al convertir la interfaz de una clase en otra esperada por el cliente. Es útil para integrar componentes que no fueron diseñados para trabajar juntos.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        Console.WriteLine("Este ejemplo demuestra el patrón Adapter, que permite que interfaces incompatibles trabajen juntas al convertir la interfaz de una clase en otra esperada por el cliente.");
        // Crear un objeto de la clase Adaptee existente
        Adaptee adaptee = new Adaptee();

        // Crear el adaptador, pasando la instancia del Adaptee
        ITarget target = new Adapter(adaptee);

        // Usar la interfaz del target
        Console.WriteLine("Adaptador en acción:");
        Console.WriteLine(target.GetRequest());

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}

// Interfaz objetivo (Target)
public interface ITarget
{
    string GetRequest();
}

// Clase que se desea adaptar (Adaptee)
public class Adaptee
{
    public string GetSpecificRequest()
    {
        return "Esta es la solicitud específica de Adaptee.";
    }
}

// Adaptador que hace compatible la interfaz del Adaptee con el ITarget
public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public string GetRequest()
    {
        // Convertir la interfaz del Adaptee a la interfaz ITarget
        return $"Este es el adaptador traduciendo: '{_adaptee.GetSpecificRequest()}'";
    }
}
