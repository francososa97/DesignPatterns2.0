using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // Mostrar la bienvenida
            ShowWelcomeMessage();

            // Mostrar el menú de selección de patrones
            ShowPatternMenu();

            // Obtener la selección del usuario
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    ExecuteSingletonPattern();
                    break;
                case "2":
                    ExecuteFactoryPattern();
                    break;
                case "3":
                    ExecuteObserverPattern();
                    break;
                // Agrega más casos para otros patrones de diseño
                default:
                    Console.WriteLine("Selección no válida. Intente de nuevo.");
                    break;
            }

            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }

        static void ShowWelcomeMessage()
        {
            Console.WriteLine("====================================");
            Console.WriteLine(" Bienvenido al Repositorio de Patrones de Diseño ");
            Console.WriteLine("====================================");
            Console.WriteLine("Este repositorio tiene como objetivo explicar y demostrar");
            Console.WriteLine("diferentes patrones de diseño mediante ejemplos prácticos.");
            Console.WriteLine("Por favor, selecciona un patrón de diseño para ver un ejemplo:");
            Console.WriteLine();
        }

        static void ShowPatternMenu()
        {
            Console.WriteLine("1. Singleton Pattern");
            Console.WriteLine("2. Factory Pattern");
            Console.WriteLine("3. Observer Pattern");
            // Agrega más opciones para otros patrones de diseño
            Console.WriteLine();
            Console.Write("Por favor, ingrese el número de su selección: ");
        }

        static void ExecuteSingletonPattern()
        {
            Console.WriteLine("Ejecutando el patrón Singleton...");
            // Aquí puedes incluir la lógica o llamar a la clase que demuestra el patrón Singleton
        }

        static void ExecuteFactoryPattern()
        {
            Console.WriteLine("Ejecutando el patrón Factory...");
            // Aquí puedes incluir la lógica o llamar a la clase que demuestra el patrón Factory
        }

        static void ExecuteObserverPattern()
        {
            Console.WriteLine("Ejecutando el patrón Observer...");
            // Aquí puedes incluir la lógica o llamar a la clase que demuestra el patrón Observer
        }

        // Agrega más métodos para otros patrones de diseño
    }
}
