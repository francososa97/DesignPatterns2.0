class Program
{
    static void Main(string[] args)
    {
        // Crear instancias de los servicios
        UserService userService = new UserService();
        OrderService orderService = new OrderService(userService);

        // Agregar un usuario
        userService.AddUser(new User { UserId = 1, Name = "Franco Sosa" });

        // Crear un pedido para el usuario
        orderService.CreateOrder(1, "Producto 1");
        orderService.CreateOrder(1, "Producto 2");

        // Mostrar los pedidos del usuario
        var orders = orderService.GetOrdersByUserId(1);
        foreach (var order in orders)
        {
            Console.WriteLine($"Pedido: {order.OrderId}, Producto: {order.Product}, Usuario: {order.User.Name}");
        }

        Console.ReadKey();
    }
}

// Servicio de Usuario
public class UserService
{
    private readonly Dictionary<int, User> _users = new Dictionary<int, User>();

    public void AddUser(User user)
    {
        _users[user.UserId] = user;
        Console.WriteLine($"Usuario {user.Name} añadido.");
    }

    public User GetUserById(int userId)
    {
        _users.TryGetValue(userId, out var user);
        return user;
    }
}

// Servicio de Pedidos
public class OrderService
{
    private readonly List<Order> _orders = new List<Order>();
    private readonly UserService _userService;

    public OrderService(UserService userService)
    {
        _userService = userService;
    }

    public void CreateOrder(int userId, string product)
    {
        var user = _userService.GetUserById(userId);
        if (user == null)
        {
            Console.WriteLine("Usuario no encontrado, no se puede crear el pedido.");
            return;
        }

        var order = new Order
        {
            OrderId = _orders.Count + 1,
            Product = product,
            User = user
        };
        _orders.Add(order);
        Console.WriteLine($"Pedido {order.OrderId} para {product} creado para el usuario {user.Name}.");
    }

    public List<Order> GetOrdersByUserId(int userId)
    {
        return _orders.FindAll(o => o.User.UserId == userId);
    }
}

// Modelo de Usuario
public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
}

// Modelo de Pedido
public class Order
{
    public int OrderId { get; set; }
    public string Product { get; set; }
    public User User { get; set; }
}

