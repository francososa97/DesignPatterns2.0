namespace EventSourcingPattern;

public class Program
{
    /// <summary>
    ///  El patrón Event Sourcing almacena el estado de un sistema como una secuencia de eventos. Es útil para garantizar que el estado del sistema pueda ser reconstruido o revertido en cualquier momento.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        Console.WriteLine("Este ejemplo demuestra el patrón Event Sourcing, que almacena el estado de un sistema como una secuencia de eventos.");
        // Crear una cuenta bancaria
        var account = new BankAccount();

        // Aplicar eventos
        account.ApplyEvent(new MoneyDepositedEvent(100));
        account.ApplyEvent(new MoneyWithdrawnEvent(30));
        account.ApplyEvent(new MoneyDepositedEvent(50));

        // Obtener y mostrar el balance actual
        Console.WriteLine($"El balance actual es: {account.GetBalance()}");

        // Mostrar el historial de eventos
        Console.WriteLine("Historial de eventos:");
        foreach (var evt in account.GetEventHistory())
        {
            Console.WriteLine(evt);
        }

        Console.ReadKey();
    }
}

// Interfaz de evento
public interface IEvent
{
    void Apply(BankAccount account);
}

// Evento de depósito de dinero
public class MoneyDepositedEvent : IEvent
{
    public decimal Amount { get; }

    public MoneyDepositedEvent(decimal amount)
    {
        Amount = amount;
    }

    public void Apply(BankAccount account)
    {
        account.Deposit(Amount);
    }

    public override string ToString()
    {
        return $"Deposited: {Amount:C}";
    }
}

// Evento de retiro de dinero
public class MoneyWithdrawnEvent : IEvent
{
    public decimal Amount { get; }

    public MoneyWithdrawnEvent(decimal amount)
    {
        Amount = amount;
    }

    public void Apply(BankAccount account)
    {
        account.Withdraw(Amount);
    }

    public override string ToString()
    {
        return $"Withdrawn: {Amount:C}";
    }
}

// Clase de cuenta bancaria
public class BankAccount
{
    private decimal _balance = 0;
    private readonly List<IEvent> _eventHistory = new List<IEvent>();

    public void ApplyEvent(IEvent evt)
    {
        evt.Apply(this);
        _eventHistory.Add(evt);
    }

    public void Deposit(decimal amount)
    {
        _balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        _balance -= amount;
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public IEnumerable<IEvent> GetEventHistory()
    {
        return _eventHistory;
    }
}
