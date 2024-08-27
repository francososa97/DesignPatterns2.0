namespace ObserverPattern;

public class Program
{
    /// <summary>
    ///  El patrón Observer define una dependencia de uno a muchos entre objetos, de manera que cuando un objeto cambia de estado, todos sus dependientes son notificados y actualizados automáticamente. Es útil para implementar eventos o sistemas de notificación.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        Console.WriteLine("Este ejemplo demuestra el patrón Observer, que define una dependencia de uno a muchos entre objetos, notificando automáticamente a sus dependientes de cualquier cambio.");
        // Crear el sujeto
        var subject = new ConcreteSubject();

        // Crear observadores
        var observer1 = new ConcreteObserver("Observer 1");
        var observer2 = new ConcreteObserver("Observer 2");

        // Suscribir observadores al sujeto
        subject.Attach(observer1);
        subject.Attach(observer2);

        // Cambiar el estado del sujeto
        subject.State = "State 1";
        subject.Notify();

        // Cambiar el estado nuevamente
        subject.State = "State 2";
        subject.Notify();

        // Desuscribir un observador y cambiar el estado
        subject.Detach(observer1);
        subject.State = "State 3";
        subject.Notify();

        Console.ReadKey();
    }
}

// Interfaz del sujeto (Subject)
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

// Sujeto concreto
public class ConcreteSubject : ISubject
{
    private readonly List<IObserver> _observers = new List<IObserver>();
    public string State { get; set; }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(State);
        }
    }
}

// Interfaz del observador (Observer)
public interface IObserver
{
    void Update(string state);
}

// Observador concreto
public class ConcreteObserver : IObserver
{
    private readonly string _name;

    public ConcreteObserver(string name)
    {
        _name = name;
    }

    public void Update(string state)
    {
        Console.WriteLine($"{_name} ha recibido una actualización: Nuevo estado del sujeto = {state}");
    }
}
