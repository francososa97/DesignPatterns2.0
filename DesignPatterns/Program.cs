ShowWelcomeMessage();
ShowPatternMenu();

string selection = Console.ReadLine();
switch (selection)
{
    case "1":
        ExecuteAbstractFactoryPattern();
        break;
    case "2":
        ExecuteAdapterPattern();
        break;
    case "3":
        ExecuteBridgePattern();
        break;
    case "4":
        ExecuteBuilderPattern();
        break;
    case "5":
        ExecuteCompositePattern();
        break;
    case "6":
        ExecuteDecoratorPattern();
        break;
    case "7":
        ExecuteFacadePattern();
        break;
    case "8":
        ExecuteFactoryMethodPattern();
        break;
    case "9":
        ExecuteFlyweightPattern();
        break;
    case "10":
        ExecuteMVCPattern();
        break;
    case "11":
        ExecutePrototypePattern();
        break;
    case "12":
        ExecuteSingletonPattern();
        break;
    default:
        Console.WriteLine("Selección no válida. Intente de nuevo.");
        break;
}

Console.WriteLine("Presiona cualquier tecla para salir...");
Console.ReadKey();

void ShowPatternMenu()
{
    Console.WriteLine("1. Abstract Factory");
    Console.WriteLine("2. Adapter");
    Console.WriteLine("3. Bridge");
    Console.WriteLine("4. Builder");
    Console.WriteLine("5. Composite");
    Console.WriteLine("6. Decorator");
    Console.WriteLine("7. Facade");
    Console.WriteLine("8. Factory Method");
    Console.WriteLine("9. Flyweight");
    Console.WriteLine("10. Model-View-Controller (MVC)");
    Console.WriteLine("11. Prototype");
    Console.WriteLine("12. Singleton");
    Console.WriteLine();
    Console.Write("Por favor, ingrese el número de su selección: ");
}

// Métodos para cada patrón de diseño
void ExecuteAbstractFactoryPattern() { Console.WriteLine("Ejecutando Abstract Factory..."); }
void ExecuteAdapterPattern() { Console.WriteLine("Ejecutando Adapter..."); }
void ExecuteBridgePattern() { Console.WriteLine("Ejecutando Bridge..."); }
void ExecuteBuilderPattern() { Console.WriteLine("Ejecutando Builder..."); }
void ExecuteCompositePattern() { Console.WriteLine("Ejecutando Composite..."); }
void ExecuteDecoratorPattern() { Console.WriteLine("Ejecutando Decorator..."); }
void ExecuteFacadePattern() { Console.WriteLine("Ejecutando Facade..."); }
void ExecuteFactoryMethodPattern() { Console.WriteLine("Ejecutando Factory Method..."); }
void ExecuteFlyweightPattern() { Console.WriteLine("Ejecutando Flyweight..."); }
void ExecuteMVCPattern() { Console.WriteLine("Ejecutando Model-View-Controller (MVC)..."); }
void ExecutePrototypePattern() { Console.WriteLine("Ejecutando Prototype..."); }
void ExecuteSingletonPattern() { Console.WriteLine("Ejecutando Singleton..."); }


void ShowWelcomeMessage()
{
    Console.WriteLine("====================================");
    Console.WriteLine(" Bienvenido al Repositorio de Patrones de Diseño ");
    Console.WriteLine("====================================");
    Console.WriteLine("Este repositorio tiene como objetivo explicar y demostrar");
    Console.WriteLine("diferentes patrones de diseño mediante ejemplos prácticos.");
    Console.WriteLine("Por favor, selecciona un patrón de diseño para ver un ejemplo:");
    Console.WriteLine();
}

void ExecuteFactoryPattern()
{
    Console.WriteLine("Ejecutando el patrón Factory...");
    // Aquí puedes incluir la lógica o llamar a la clase que demuestra el patrón Factory
}

void ExecuteObserverPattern()
{
    Console.WriteLine("Ejecutando el patrón Observer...");
    // Aquí puedes incluir la lógica o llamar a la clase que demuestra el patrón Observer
}
