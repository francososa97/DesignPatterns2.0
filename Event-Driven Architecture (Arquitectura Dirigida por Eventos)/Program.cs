namespace EventDrivenConsoleApp;

class Program
{
    static void Main(string[] args)
    {
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
