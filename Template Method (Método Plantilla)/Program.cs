namespace Template_Method__Método_Plantilla_;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Preparing Coffee...");
        Beverage coffee = new Coffee();
        coffee.Prepare();

        Console.WriteLine("\nPreparing Tea...");
        Beverage tea = new Tea();
        tea.Prepare();

        Console.ReadKey();
    }
}

// Clase abstracta que define el Template Method
public abstract class Beverage
{
    // Template Method
    public void Prepare()
    {
        BoilWater();
        Brew();
        PourInCup();
        if (WantsCondiments())
        {
            AddCondiments();
        }
    }

    // Pasos del algoritmo
    protected abstract void Brew(); // Método abstracto a ser implementado por subclases
    protected abstract void AddCondiments(); // Método abstracto a ser implementado por subclases

    // Método concreto común para todas las bebidas
    private void BoilWater()
    {
        Console.WriteLine("Boiling water");
    }

    // Método concreto común para todas las bebidas
    private void PourInCup()
    {
        Console.WriteLine("Pouring into cup");
    }

    // Hook method (puede ser sobrescrito por subclases si es necesario)
    protected virtual bool WantsCondiments()
    {
        return true; // Por defecto, se añaden condimentos
    }
}

// Subclase concreta para preparar café
public class Coffee : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Brewing coffee");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Adding sugar and milk to coffee");
    }

    // No sobrescribe WantsCondiments, por lo tanto usa la implementación por defecto
}

// Subclase concreta para preparar té
public class Tea : Beverage
{
    protected override void Brew()
    {
        Console.WriteLine("Steeping the tea");
    }

    protected override void AddCondiments()
    {
        Console.WriteLine("Adding lemon to tea");
    }

    protected override bool WantsCondiments()
    {
        // Supongamos que el té se toma sin condimentos en este caso
        return false; // No añadir condimentos
    }
}
