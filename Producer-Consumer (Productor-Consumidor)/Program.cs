using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Producer_Consumer__Productor_Consumidor_;

class Program
{
    static void Main(string[] args)
    {
        // Crear una cola bloqueante para almacenar los datos producidos
        BlockingCollection<int> blockingCollection = new BlockingCollection<int>(boundedCapacity: 5);

        // Crear y lanzar el productor
        Task producerTask = Task.Run(() => Producer(blockingCollection));

        // Crear y lanzar el consumidor
        Task consumerTask = Task.Run(() => Consumer(blockingCollection));

        // Esperar a que las tareas terminen
        Task.WaitAll(producerTask, consumerTask);

        Console.WriteLine("Proceso de producción y consumo completado.");
        Console.ReadKey();
    }

    static void Producer(BlockingCollection<int> blockingCollection)
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Produciendo: {i}");
            blockingCollection.Add(i);
            Thread.Sleep(100); // Simula el tiempo de producción
        }
        blockingCollection.CompleteAdding(); // Indica que no habrá más elementos añadidos
    }

    static void Consumer(BlockingCollection<int> blockingCollection)
    {
        foreach (var item in blockingCollection.GetConsumingEnumerable())
        {
            Console.WriteLine($"Consumiendo: {item}");
            Thread.Sleep(150); // Simula el tiempo de consumo
        }
    }
}
