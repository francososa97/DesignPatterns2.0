namespace UnitOfWorkPattern;

public class Program
{
    /// <summary>
    ///  El patrón Unit of Work coordina las operaciones de un grupo de repositorios, asegurando que todas las modificaciones a los datos sean realizadas en una transacción única. Es útil para manejar transacciones de manera eficiente.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        Console.WriteLine("Este ejemplo demuestra el patrón Unit of Work, que coordina las operaciones de un grupo de repositorios en una única transacción.");
        using (var unitOfWork = new UnitOfWork())
        {
            // Operaciones de inserción
            unitOfWork.Users.Add(new User { Id = 1, Name = "Alice" });
            unitOfWork.Users.Add(new User { Id = 2, Name = "Bob" });

            // Operación de actualización
            var user = unitOfWork.Users.GetById(1);
            if (user != null)
            {
                user.Name = "Alice Updated";
                unitOfWork.Users.Update(user);
            }

            // Confirmar todos los cambios como una única transacción
            unitOfWork.Commit();

            // Mostrar todos los usuarios
            Console.WriteLine("Usuarios después del Commit:");
            foreach (var u in unitOfWork.Users.GetAll())
            {
                Console.WriteLine($"Id: {u.Id}, Name: {u.Name}");
            }
        }

        Console.ReadKey();
    }
}

// Entidad de usuario
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}

// Interfaz del repositorio genérico
public interface IRepository<T> where T : class
{
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    T GetById(int id);
    IEnumerable<T> GetAll();
}

// Implementación del repositorio de usuarios en memoria
public class UserRepository : IRepository<User>
{
    private readonly List<User> _users = new List<User>();

    public void Add(User entity)
    {
        _users.Add(entity);
    }

    public void Update(User entity)
    {
        var user = GetById(entity.Id);
        if (user != null)
        {
            user.Name = entity.Name;
        }
    }

    public void Remove(User entity)
    {
        _users.Remove(entity);
    }

    public User GetById(int id)
    {
        return _users.Find(user => user.Id == id);
    }

    public IEnumerable<User> GetAll()
    {
        return _users;
    }
}

// Interfaz Unit of Work
public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get; }
    void Commit();
}

// Implementación de Unit of Work
public class UnitOfWork : IUnitOfWork
{
    private readonly UserRepository _userRepository = new UserRepository();
    private bool _disposed = false;

    public IRepository<User> Users => _userRepository;

    public void Commit()
    {
        // Aquí es donde se confirmaría la transacción a la base de datos real.
        Console.WriteLine("Transacción confirmada.");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Liberar recursos gestionados si es necesario.
            }

            _disposed = true;
        }
    }
}
