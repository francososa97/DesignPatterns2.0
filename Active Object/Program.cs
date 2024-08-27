using System.Collections.Concurrent;

namespace ActiveObject;
public class Program
{
    /// <summary>
    /// El patrón Active Object separa la invocación de un método de su ejecución, permitiendo que los métodos se ejecuten de forma asíncrona. Esto mejora la concurrencia y la capacidad de respuesta, aunque añade complejidad en la gestión de hilos.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Este ejemplo demuestra el patrón Active Object, que permite ejecutar métodos de forma asíncrona para mejorar la concurrencia.");
        // Crear el Active Object
        ActiveObject activeObject = new ActiveObject();

        // Invocar métodos de forma asíncrona
        Task<int> task1 = activeObject.DoWorkAsync(5);
        Task<int> task2 = activeObject.DoWorkAsync(10);

        Console.WriteLine("Las tareas se están ejecutando en segundo plano...");

        // Obtener los resultados
        int result1 = await task1;
        int result2 = await task2;

        Console.WriteLine($"Resultado de la tarea 1: {result1}");
        Console.WriteLine($"Resultado de la tarea 2: {result2}");

        // Finalizar el Active Object
        activeObject.Shutdown();

        Console.WriteLine("Active Object ha finalizado.");
        Console.ReadKey();
    }
}

// Clase que representa el Active Object
public class ActiveObject
{
    private readonly BlockingCollection<MethodRequest<int>> _requests = new BlockingCollection<MethodRequest<int>>();
    private readonly Task _worker;
    private readonly CancellationTokenSource _cts = new CancellationTokenSource();

    public ActiveObject()
    {
        // Hilo de trabajo que procesa las solicitudes
        _worker = Task.Run(() => ProcessRequests(_cts.Token));
    }

    // Método que se invoca de manera asíncrona
    public Task<int> DoWorkAsync(int input)
    {
        var request = new MethodRequest<int>(() => DoWork(input));
        _requests.Add(request);
        return request.Task;
    }

    // Método de negocio que se ejecuta en el hilo del Active Object
    private int DoWork(int input)
    {
        Console.WriteLine($"Procesando {input} en el hilo {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(2000); // Simular una operación costosa
        return input * 2;
    }

    // Procesar las solicitudes en segundo plano
    private void ProcessRequests(CancellationToken token)
    {
        foreach (var request in _requests.GetConsumingEnumerable())
        {
            if (token.IsCancellationRequested)
                break;

            request.Execute();
        }
    }

    // Finalizar el Active Object
    public void Shutdown()
    {
        _requests.CompleteAdding();
        _cts.Cancel();
        _worker.Wait();
    }
}

// Clase que representa una solicitud de método (Method Request)
public class MethodRequest<T>
{
    private readonly Func<T> _method;
    private readonly TaskCompletionSource<T> _tcs = new TaskCompletionSource<T>();

    public MethodRequest(Func<T> method)
    {
        _method = method;
    }

    public Task<T> Task => _tcs.Task;

    public void Execute()
    {
        try
        {
            var result = _method();
            _tcs.SetResult(result);
        }
        catch (Exception ex)
        {
            _tcs.SetException(ex);
        }
    }
}
