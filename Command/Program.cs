namespace CommandPattern;

class Program
{
    static void Main(string[] args)
    {
        // Crear el invocador
        var invoker = new Invoker();

        // Crear el receptor
        var receiver = new Receiver();

        // Crear comandos concretos
        var commandA = new ConcreteCommandA(receiver);
        var commandB = new ConcreteCommandB(receiver);

        // Ejecutar comandos a través del invocador
        invoker.SetCommand(commandA);
        invoker.ExecuteCommand();

        invoker.SetCommand(commandB);
        invoker.ExecuteCommand();

        Console.ReadKey();
    }
}

// Interfaz Command
public interface ICommand
{
    void Execute();
}

// Receptor que realiza la acción real
public class Receiver
{
    public void ActionA()
    {
        Console.WriteLine("Receiver: Ejecutando Acción A.");
    }

    public void ActionB()
    {
        Console.WriteLine("Receiver: Ejecutando Acción B.");
    }
}

// Comando concreto A
public class ConcreteCommandA : ICommand
{
    private readonly Receiver _receiver;

    public ConcreteCommandA(Receiver receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.ActionA();
    }
}

// Comando concreto B
public class ConcreteCommandB : ICommand
{
    private readonly Receiver _receiver;

    public ConcreteCommandB(Receiver receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.ActionB();
    }
}

// Invocador que llama a los comandos
public class Invoker
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void ExecuteCommand()
    {
        _command.Execute();
    }
}
