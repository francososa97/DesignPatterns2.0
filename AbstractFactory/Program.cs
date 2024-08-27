
namespace AbstractFactoryPattern;

class Program
{
    static void Main(string[] args)
    {
        // Crear fábrica concreta 1 y productos
        IGUIFactory factory1 = new WinFactory();
        var button1 = factory1.CreateButton();
        var checkbox1 = factory1.CreateCheckbox();

        button1.Paint();
        checkbox1.Paint();

        // Crear fábrica concreta 2 y productos
        IGUIFactory factory2 = new MacFactory();
        var button2 = factory2.CreateButton();
        var checkbox2 = factory2.CreateCheckbox();

        button2.Paint();
        checkbox2.Paint();

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}

// Interfaz de la fábrica abstracta
public interface IGUIFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}

// Fábrica concreta 1
public class WinFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new WinButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new WinCheckbox();
    }
}

// Fábrica concreta 2
public class MacFactory : IGUIFactory
{
    public IButton CreateButton()
    {
        return new MacButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new MacCheckbox();
    }
}

// Interfaz de Producto Abstracto A
public interface IButton
{
    void Paint();
}

// Producto Concreto A1
public class WinButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Renderizando un botón en estilo Windows.");
    }
}

// Producto Concreto A2
public class MacButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("Renderizando un botón en estilo Mac.");
    }
}

// Interfaz de Producto Abstracto B
public interface ICheckbox
{
    void Paint();
}

// Producto Concreto B1
public class WinCheckbox : ICheckbox
{
    public void Paint()
    {
        Console.WriteLine("Renderizando una casilla de verificación en estilo Windows.");
    }
}

// Producto Concreto B2
public class MacCheckbox : ICheckbox
{
    public void Paint()
    {
        Console.WriteLine("Renderizando una casilla de verificación en estilo Mac.");
    }
}
