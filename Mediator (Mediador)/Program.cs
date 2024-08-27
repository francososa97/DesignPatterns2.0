namespace MediatorPattern;

class Program
{
    static void Main(string[] args)
    {
        // Crear el mediador
        var chatRoom = new ChatRoomMediator();

        // Crear participantes y registrarlos en el mediador
        var user1 = new User("Alice", chatRoom);
        var user2 = new User("Bob", chatRoom);
        var user3 = new User("Charlie", chatRoom);

        // Enviar mensajes entre los participantes a través del mediador
        user1.Send("Hola a todos!");
        user2.Send("Hola Alice!");
        user3.Send("Hola a ambos!");

        Console.ReadKey();
    }
}

// Interfaz Mediator
public interface IChatRoomMediator
{
    void ShowMessage(User user, string message);
    void Register(User user);
}

// Mediador concreto
public class ChatRoomMediator : IChatRoomMediator
{
    private readonly List<User> _participants = new List<User>();

    public void Register(User user)
    {
        if (!_participants.Contains(user))
        {
            _participants.Add(user);
        }
    }

    public void ShowMessage(User user, string message)
    {
        var time = DateTime.Now.ToString("HH:mm");
        Console.WriteLine($"{time} [{user.Name}]: {message}");
    }
}

// Clase User que interactúa a través del mediador
public class User
{
    public string Name { get; }
    private IChatRoomMediator _chatRoomMediator;

    public User(string name, IChatRoomMediator chatRoomMediator)
    {
        Name = name;
        _chatRoomMediator = chatRoomMediator;
        _chatRoomMediator.Register(this);
    }

    public void Send(string message)
    {
        _chatRoomMediator.ShowMessage(this, message);
    }
}
