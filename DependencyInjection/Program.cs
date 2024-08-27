using System;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjectionPattern;

class Program
{
    static void Main(string[] args)
    {
        // Configurar el contenedor de inyección de dependencias
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IMessageService, ConsoleMessageService>()
            .AddSingleton<NotificationService>()
            .BuildServiceProvider();

        // Resolver la dependencia
        var notificationService = serviceProvider.GetService<NotificationService>();

        // Usar el servicio de notificación
        notificationService.Send("Hola, Inyección de Dependencias en .NET!");

        Console.ReadKey();
    }
}

// Servicio de mensaje
public interface IMessageService
{
    void SendMessage(string message);
}

// Implementación concreta del servicio de mensaje
public class ConsoleMessageService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Mensaje enviado: {message}");
    }
}

// Servicio de notificación que depende de IMessageService
public class NotificationService
{
    private readonly IMessageService _messageService;

    // Constructor con inyección de dependencia
    public NotificationService(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Send(string message)
    {
        _messageService.SendMessage(message);
    }
}
