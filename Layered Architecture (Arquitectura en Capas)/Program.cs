namespace LayeredArchitecture.ConsoleApp;

// Domain Layer
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

// Data Access Layer
public class PersonRepository
{
    private static List<Person> _persons = new();

    public List<Person> GetAll()
    {
        return _persons;
    }

    public void Add(Person person)
    {
        person.Id = _persons.Count + 1;
        _persons.Add(person);
    }
}

// Business Logic Layer
public class PersonService
{
    private readonly PersonRepository _repository;

    public PersonService()
    {
        _repository = new PersonRepository();
    }

    public List<Person> GetAllPersons()
    {
        return _repository.GetAll();
    }

    public void CreatePerson(string firstName, string lastName)
    {
        var person = new Person
        {
            FirstName = firstName,
            LastName = lastName
        };
        _repository.Add(person);
    }
}

// Presentation Layer
class Program
{
    static void Main(string[] args)
    {
        var personService = new PersonService();

        personService.CreatePerson("John", "Doe");
        personService.CreatePerson("Jane", "Smith");

        var persons = personService.GetAllPersons();

        foreach (var person in persons)
        {
            Console.WriteLine($"{person.Id}: {person.FirstName} {person.LastName}");
        }
    }
}

