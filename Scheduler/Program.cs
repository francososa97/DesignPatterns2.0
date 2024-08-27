namespace Scheduler;

public class Program
{
    /// <summary>
    /// El patrón Scheduler gestiona la ejecución de tareas distribuyéndolas de manera eficiente entre los recursos disponibles. Controla el orden y la prioridad de ejecución, mejorando la utilización de recursos, aunque puede ser complejo de implementar.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        Console.WriteLine("Este ejemplo demuestra el patrón Scheduler, que gestiona la ejecución de tareas distribuyéndolas de manera eficiente según su prioridad.");
        Scheduler scheduler = new Scheduler();

        // Añadir tareas al planificador con diferentes prioridades
        scheduler.ScheduleTask(new ScheduledTask(1, "Tarea 1 - Baja Prioridad"));
        scheduler.ScheduleTask(new ScheduledTask(3, "Tarea 2 - Alta Prioridad"));
        scheduler.ScheduleTask(new ScheduledTask(2, "Tarea 3 - Prioridad Media"));

        // Ejecutar las tareas programadas
        scheduler.Run();

        Console.WriteLine("Todas las tareas han sido ejecutadas.");
        Console.ReadKey();
    }
}

// Clase que representa una tarea programada
public class ScheduledTask : IComparable<ScheduledTask>
{
    public int Priority { get; }
    public string Name { get; }

    public ScheduledTask(int priority, string name)
    {
        Priority = priority;
        Name = name;
    }

    // Método que define cómo se ejecutará la tarea
    public void Execute()
    {
        Console.WriteLine($"{Name} está siendo ejecutada en el hilo {Thread.CurrentThread.ManagedThreadId} con prioridad {Priority}.");
        Thread.Sleep(1000); // Simula trabajo
        Console.WriteLine($"{Name} ha terminado.");
    }

    // Implementación de IComparable para ordenar las tareas por prioridad
    public int CompareTo(ScheduledTask other)
    {
        return other.Priority.CompareTo(Priority); // Prioridad más alta se ejecuta primero
    }
}

// Clase que gestiona el planificador
public class Scheduler
{
    private readonly SortedSet<ScheduledTask> _taskQueue = new SortedSet<ScheduledTask>();

    // Método para añadir una tarea al planificador
    public void ScheduleTask(ScheduledTask task)
    {
        _taskQueue.Add(task);
    }

    // Método para ejecutar todas las tareas programadas
    public void Run()
    {
        foreach (var task in _taskQueue)
        {
            Task.Run(() => task.Execute()).Wait(); // Ejecutar cada tarea en un hilo separado
        }
    }
}
