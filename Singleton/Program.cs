namespace SingletonPattern;

class Program
{
    /// <summary>
    /// El patrón Singleton es un patrón de diseño creacional que asegura que una clase tenga una única instancia y proporciona un punto de acceso global a esa instancia. Es útil en situaciones donde tener múltiples instancias de una clase podría causar problemas, como en el caso de manejo de conexiones de base de datos, logs o configuraciones globales.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        // Ejemplo de uso del Singleton
        var singleton1 = Singleton.Instance;
        var singleton2 = Singleton.Instance;

        if (singleton1 == singleton2)
        {
            Console.WriteLine("Ambas variables contienen la misma instancia.");
        }
        else
        {
            Console.WriteLine("Las variables contienen instancias diferentes.");
        }

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
/// <summary>
/// Constructor Privado: El constructor está marcado como privado para evitar que otras clases creen instancias directamente.
//Propiedad Instance: Esta propiedad verifica si _instance es null. Si lo es, crea una nueva instancia de Singleton; de lo contrario, devuelve la instancia existente.
/// </summary>
public class Singleton
{
    // Campo privado para almacenar la única instancia
    private static Singleton _instance;

    // Constructor privado para evitar la creación directa
    private Singleton()
    {
        Console.WriteLine("Singleton instance created.");
    }

    // Propiedad pública para acceder a la instancia
    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }
}
