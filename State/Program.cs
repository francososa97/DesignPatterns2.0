namespace StatePattern;

class Program
{
    static void Main(string[] args)
    {
        // Crear el contexto con un estado inicial
        var context = new Context(new ConcreteStateA());

        // Ejecutar acciones en diferentes estados
        context.Request();
        context.Request();

        Console.ReadKey();
    }
}

// Interfaz de estado
public interface IState
{
    void Handle(Context context);
}

// Estado concreto A
public class ConcreteStateA : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("El contexto está en Estado A. Cambiando a Estado B.");
        context.SetState(new ConcreteStateB());
    }
}

// Estado concreto B
public class ConcreteStateB : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("El contexto está en Estado B. Cambiando a Estado A.");
        context.SetState(new ConcreteStateA());
    }
}

// Clase de contexto
public class Context
{
    private IState _state;

    public Context(IState state)
    {
        SetState(state);
    }

    public void SetState(IState state)
    {
        _state = state;
        Console.WriteLine($"Estado cambiado a: {_state.GetType().Name}");
    }

    public void Request()
    {
        _state.Handle(this);
    }
}
