﻿namespace RepositoryPattern;

public class Program
{
    /// <summary>
    /// El patrón Repository abstrae la lógica de acceso a datos, proporcionando una interfaz más limpia y clara para realizar operaciones CRUD. Es útil para desacoplar la lógica de negocio de la lógica de persistencia.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        Console.WriteLine("Este ejemplo demuestra el patrón Repository, que abstrae la lógica de acceso a datos y proporciona una interfaz para realizar operaciones CRUD.");
        // Crear el repositorio de usuarios
        IUserRepository userRepository = new UserRepository();

        // Agregar usuarios al repositorio
        userRepository.Add(new User { Id = 1, Name = "Alice" });
        userRepository.Add(new User { Id = 2, Name = "Bob" });

        // Obtener y mostrar todos los usuarios
        var users = userRepository.GetAll();
        Console.WriteLine("Usuarios en el repositorio:");
        foreach (var user in users)
        {
            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}");
        }

        // Buscar un usuario por Id
        var userById = userRepository.GetById(1);
        Console.WriteLine($"\nUsuario encontrado por Id 1: Name: {userById.Name}");

        Console.ReadKey();
    }
}

// Entidad de usuario
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}

// Interfaz del repositorio de usuarios
public interface IUserRepository
{
    void Add(User user);
    User GetById(int id);
    IEnumerable<User> GetAll();
}

// Implementación del repositorio de usuarios
public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new List<User>();

    public void Add(User user)
    {
        _users.Add(user);
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
