﻿namespace Service_Locator;

// Interfaz de Servicio
public interface ILogger
{
    void Log(string message);
}

// Implementación de un servicio concreto
public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[ConsoleLogger] {message}");
    }
}

// Service Locator
public class ServiceLocator
{
    private readonly Dictionary<Type, object> _services = new();

    // Registrar un servicio en el localizador
    public void RegisterService<T>(T service)
    {
        var type = typeof(T);
        if (!_services.ContainsKey(type))
        {
            _services.Add(type, service);
        }
    }

    // Obtener un servicio del localizador
    public T GetService<T>()
    {
        var type = typeof(T);
        if (_services.TryGetValue(type, out var service))
        {
            return (T)service;
        }
        throw new Exception($"Service of type {type.Name} not found.");
    }
}

// Aplicación de consola
class Program
{
    static void Main(string[] args)
    {
        // Crear el Service Locator
        var serviceLocator = new ServiceLocator();

        // Registrar un servicio en el localizador
        serviceLocator.RegisterService<ILogger>(new ConsoleLogger());

        // Obtener el servicio y utilizarlo
        var logger = serviceLocator.GetService<ILogger>();
        logger.Log("Hello from Service Locator!");

        Console.ReadKey();
    }
}