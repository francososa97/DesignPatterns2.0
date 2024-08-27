namespace ThreadPoolPathern;
public class Program
{
    /// <summary>
    ///  El patrón Thread Pool reutiliza un grupo de hilos para manejar múltiples tareas concurrentes, mejorando la eficiencia y el rendimiento. Limita la sobrecarga de creación y destrucción de hilos, aunque puede introducir latencia si la carga es alta.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        Console.WriteLine("Este ejemplo demuestra el patrón Thread Pool, que mejora la eficiencia mediante la reutilización de un grupo de hilos para tareas concurrentes.");
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
