using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Inicio de la aplicación");

        // Enviar varias tareas al ThreadPool
        for (int i = 1; i <= 5; i++)
        {
            int taskId = i;
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork), taskId);
        }

        Console.WriteLine("Todas las tareas han sido encoladas.");
        Console.ReadKey();
    }

    // Método que será ejecutado por hilos en el ThreadPool
    static void DoWork(object taskId)
    {
        Console.WriteLine($"Task {taskId} está siendo ejecutada en el hilo {Thread.CurrentThread.ManagedThreadId}.");
        Thread.Sleep(1000); // Simular trabajo
        Console.WriteLine($"Task {taskId} ha terminado.");
    }
}
