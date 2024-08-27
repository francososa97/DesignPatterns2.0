using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mvvm;

// Modelo
public class Product : INotifyPropertyChanged
{
    private string _name;
    private double _price;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    public double Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

// ViewModel
public class ProductViewModel : INotifyPropertyChanged
{
    private readonly Product _product;

    public ProductViewModel(Product product)
    {
        _product = product;
        _product.PropertyChanged += (s, e) => OnPropertyChanged(e.PropertyName); // Genera una traza
    }

    public string ProductName
    {
        get => _product.Name;
        set
        {
            _product.Name = value;
            OnPropertyChanged();
        }
    }

    public double ProductPrice
    {
        get => _product.Price;
        set
        {
            _product.Price = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

// Vista
public static class ProductView
{
    public static void Display(ProductViewModel viewModel)
    {
        Console.WriteLine($"Product: {viewModel.ProductName}, Price: {viewModel.ProductPrice:C}");
    }
}

// Aplicación de consola
public class Program
{
    /// <summary>
    /// El patrón MVVM separa la lógica de presentación de la interfaz de usuario del modelo de datos, utilizando una capa intermedia de ViewModel. Es útil en aplicaciones que requieren una separación clara entre la UI y la lógica de negocio.
    /// </summary>
    public static void Main()
    {
        Console.WriteLine("Este ejemplo demuestra el patrón MVVM (Model-View-ViewModel), que separa la lógica de presentación de la interfaz de usuario del modelo de datos.");
        // Crear un modelo
        var product = new Product { Name = "Laptop", Price = 1500.00 };

        // Crear una ViewModel basada en el modelo
        var viewModel = new ProductViewModel(product);

        // Mostrar la vista
        ProductView.Display(viewModel);

        // Cambiar los datos en la ViewModel (que a su vez modifica el Modelo)
        viewModel.ProductName = "Gaming Laptop";
        viewModel.ProductPrice = 2000.00;

        // Mostrar la vista actualizada
        ProductView.Display(viewModel);

        Console.ReadKey();
    }
}
