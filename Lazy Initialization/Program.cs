﻿namespace Lazy;

public class Program
{
    /// <summary>
    /// El patrón Lazy Initialization retrasa la creación de un objeto hasta que se necesite por primera vez, mejorando el rendimiento y optimizando el uso de recursos. Es útil en situaciones donde un objeto puede no ser necesario durante la ejecución del programa.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        Console.WriteLine("Este ejemplo demuestra el patrón Lazy Initialization, que retrasa la creación de un objeto hasta que se necesite por primera vez, optimizando el uso de recursos.");
        Console.WriteLine("Inicio de la aplicación.");

        // Uso de Lazy<T> para inicialización perezosa
        Lazy<ExpensiveObject> lazyExpensiveObject = new Lazy<ExpensiveObject>(() => new ExpensiveObject());

        Console.WriteLine("El objeto aún no ha sido inicializado.");

        // Acceso al objeto por primera vez, lo que desencadena su inicialización
        Console.WriteLine("Accediendo al objeto...");
        ExpensiveObject obj = lazyExpensiveObject.Value;

        Console.WriteLine("El objeto ha sido inicializado y utilizado.");

        // El objeto ya está inicializado, se puede volver a utilizar sin inicialización adicional
        obj.PerformAction();

        Console.ReadKey();
    }
}

public class ExpensiveObject
{
    public ExpensiveObject()
    {
        Console.WriteLine("ExpensiveObject: Inicializando el objeto costoso...");
        // Simula una operación costosa
        System.Threading.Thread.Sleep(2000);
        Console.WriteLine("ExpensiveObject: Inicialización completa.");
    }

    public void PerformAction()
    {
        Console.WriteLine("ExpensiveObject: Realizando una acción.");
    }
}
