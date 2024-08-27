// Interfaz común para el sujeto real y el proxy
public interface IExpensiveService
{
    void ProcessData();
}

// Sujeto real que realiza una operación costosa
public class ExpensiveService : IExpensiveService
{
    public ExpensiveService()
    {
        Console.WriteLine("ExpensiveService: Inicializando un servicio costoso...");
        // Simular un tiempo de inicialización largo
        System.Threading.Thread.Sleep(2000);
    }

    public void ProcessData()
    {
        Console.WriteLine("ExpensiveService: Procesando datos...");
    }
}

// Proxy que controla el acceso al ExpensiveService
public class ExpensiveServiceProxy : IExpensiveService
{
    private ExpensiveService _expensiveService;

    public void ProcessData()
    {
        // Creación perezosa del servicio costoso
        if (_expensiveService == null)
        {
            Console.WriteLine("ExpensiveServiceProxy: Creando el servicio costoso bajo demanda...");
            _expensiveService = new ExpensiveService();
        }
        _expensiveService.ProcessData();
    }
}

// Aplicación de consola
class Program
{
    static void Main(string[] args)
    {
        // Uso del proxy en lugar del servicio directo
        IExpensiveService service = new ExpensiveServiceProxy();

        Console.WriteLine("Realizando la primera llamada al servicio...");
        service.ProcessData();

        Console.WriteLine("Realizando la segunda llamada al servicio...");
        service.ProcessData();

        Console.ReadKey();
    }
}
