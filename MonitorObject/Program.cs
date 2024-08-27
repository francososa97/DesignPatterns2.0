class Program
{
    static void Main(string[] args)
    {
        MonitorObject monitorObject = new MonitorObject();

        // Crear múltiples hilos que acceden al mismo objeto monitorizado
        Thread thread1 = new Thread(() => monitorObject.SafeIncrement());
        Thread thread2 = new Thread(() => monitorObject.SafeIncrement());
        Thread thread3 = new Thread(() => monitorObject.SafeIncrement());

        thread1.Start();
        thread2.Start();
        thread3.Start();

        thread1.Join();
        thread2.Join();
        thread3.Join();

        Console.WriteLine($"Valor final del contador: {monitorObject.Counter}");
        Console.ReadKey();
    }
}

public class MonitorObject
{
    private readonly object _lockObject = new object();
    public int Counter { get; private set; }

    public void SafeIncrement()
    {
        // Bloquear el objeto monitorizado para garantizar la exclusión mutua
        lock (_lockObject)
        {
            Console.WriteLine($"Hilo {Thread.CurrentThread.ManagedThreadId} está incrementando el contador.");
            int temp = Counter;
            Thread.Sleep(100); // Simula una operación costosa
            Counter = temp + 1;
            Console.WriteLine($"Hilo {Thread.CurrentThread.ManagedThreadId} ha incrementado el contador a {Counter}.");
        }
    }
}
