namespace ChainOfResponsibilityPattern;

class Program
{
    static void Main(string[] args)
    {
        // Configurar la cadena de responsabilidad
        var handler1 = new ConcreteHandler1();
        var handler2 = new ConcreteHandler2();
        var handler3 = new ConcreteHandler3();

        handler1.SetNext(handler2).SetNext(handler3);

        // Realizar las solicitudes
        Console.WriteLine("Solicitud con valor 5:");
        handler1.HandleRequest(5);

        Console.WriteLine("\nSolicitud con valor 15:");
        handler1.HandleRequest(15);

        Console.WriteLine("\nSolicitud con valor 25:");
        handler1.HandleRequest(25);

        Console.ReadKey();
    }
}

// Interfaz Handler
public abstract class Handler
{
    private Handler _nextHandler;

    public Handler SetNext(Handler nextHandler)
    {
        _nextHandler = nextHandler;
        return _nextHandler;
    }

    public virtual void HandleRequest(int request)
    {
        if (_nextHandler != null)
        {
            _nextHandler.HandleRequest(request);
        }
    }
}

// Manejador concreto 1
public class ConcreteHandler1 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request < 10)
        {
            Console.WriteLine($"ConcreteHandler1 maneja la solicitud con valor {request}.");
        }
        else
        {
            base.HandleRequest(request);
        }
    }
}

// Manejador concreto 2
public class ConcreteHandler2 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 10 && request < 20)
        {
            Console.WriteLine($"ConcreteHandler2 maneja la solicitud con valor {request}.");
        }
        else
        {
            base.HandleRequest(request);
        }
    }
}

// Manejador concreto 3
public class ConcreteHandler3 : Handler
{
    public override void HandleRequest(int request)
    {
        if (request >= 20)
        {
            Console.WriteLine($"ConcreteHandler3 maneja la solicitud con valor {request}.");
        }
        else
        {
            base.HandleRequest(request);
        }
    }
}
