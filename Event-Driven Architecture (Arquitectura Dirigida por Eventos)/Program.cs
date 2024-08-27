namespace EventDrivenConsoleApp;

public class Program
{
    /// <summary>
    /// El patrón Event-Driven Architecture organiza la comunicación entre componentes mediante eventos, permitiendo que los componentes reaccionen a cambios de estado de manera desacoplada. Es útil para sistemas que requieren alta escalabilidad y flexibilidad.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        Console.WriteLine("Este ejemplo demuestra el patrón Event-Driven Architecture, que organiza la comunicación entre componentes mediante eventos, mejorando la escalabilidad y flexibilidad.");
        // Crear un evento y suscribirse a él
        var eventPublisher = new EventPublisher();
        var eventSubscriber = new EventSubscriber(eventPublisher);

        // Publicar un evento
        eventPublisher.Publish("Evento disparado!");

        Console.ReadKey();
    }
}

// Publicador del evento
public class EventPublisher
{
    // Definición del evento
    public event EventHandler<string> OnEventPublished;

    public void Publish(string message)
    {
        Console.WriteLine("[Publisher] Publicando evento...");
        OnEventPublished?.Invoke(this, message);
    }
}

// Suscriptor del evento
public class EventSubscriber
{
    public EventSubscriber(EventPublisher publisher)
    {
        // Suscribirse al evento
        publisher.OnEventPublished += HandleEvent;
    }

    private void HandleEvent(object sender, string message)
    {
        Console.WriteLine($"[Subscriber] Evento recibido: {message}");
    }
}
