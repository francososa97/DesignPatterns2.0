namespace MVCPattern;

class Program
{
    static void Main(string[] args)
    {
        // Crear el modelo
        var model = new PersonModel("John Doe", 30);

        // Crear la vista
        var view = new PersonView();

        // Crear el controlador
        var controller = new PersonController(model, view);

        // Actualizar la vista inicialmente
        controller.UpdateView();

        // Simular un cambio en el modelo a través del controlador
        controller.SetPersonName("Jane Doe");
        controller.SetPersonAge(25);

        // Volver a actualizar la vista
        controller.UpdateView();

        Console.ReadKey();
    }
}

// Modelo
public class PersonModel
{
    public string Name { get; set; }
    public int Age { get; set; }

    public PersonModel(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

// Vista
public class PersonView
{
    public void PrintPersonDetails(string personName, int personAge)
    {
        Console.WriteLine($"Person: {personName}, Age: {personAge}");
    }
}

// Controlador
public class PersonController
{
    private readonly PersonModel _model;
    private readonly PersonView _view;

    public PersonController(PersonModel model, PersonView view)
    {
        _model = model;
        _view = view;
    }

    public void SetPersonName(string name)
    {
        _model.Name = name;
    }

    public string GetPersonName()
    {
        return _model.Name;
    }

    public void SetPersonAge(int age)
    {
        _model.Age = age;
    }

    public int GetPersonAge()
    {
        return _model.Age;
    }

    public void UpdateView()
    {
        _view.PrintPersonDetails(_model.Name, _model.Age);
    }
}
