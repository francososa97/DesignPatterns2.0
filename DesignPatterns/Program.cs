namespace DesignPatterns;
public class DesignPatterns
{
    public static void Main(string[] args)
    {
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
            case "13":
                ExecuteObserverPattern();
                break;
            case "14":
                ExecuteStatePattern();
                break;
            case "15":
                ExecuteStrategyPattern();
                break;
            case "16":
                ExecuteTemplateMethodPattern();
                break;
            case "17":
                ExecuteVisitorPattern();
                break;
            case "18":
                ExecuteChainOfResponsibilityPattern();
                break;
            case "19":
                ExecuteCommandPattern();
                break;
            case "20":
                ExecuteInterpreterPattern();
                break;
            case "21":
                ExecuteIteratorPattern();
                break;
            case "22":
                ExecuteMediatorPattern();
                break;
            case "23":
                ExecuteMementoPattern();
                break;
            case "24":
                ExecuteProxyPattern();
                break;
            case "25":
                ExecuteMVVMPattern();
                break;
            case "26":
                ExecuteRepositoryPattern();
                break;
            case "27":
                ExecuteUnitOfWorkPattern();
                break;
            case "28":
                ExecuteDependencyInjectionPattern();
                break;
            case "29":
                ExecuteServiceLocatorPattern();
                break;
            case "30":
                ExecuteEventSourcingPattern();
                break;
            case "31":
                ExecuteCQRSPattern();
                break;
            case "32":
                ExecuteLazyInitializationPattern();
                break;
            case "33":
                ExecuteActiveObjectPattern();
                break;
            case "34":
                ExecuteSchedulerPattern();
                break;
            case "35":
                ExecuteProducerConsumerPattern();
                break;
            case "36":
                ExecuteThreadPoolPattern();
                break;
            case "37":
                ExecuteMonitorObjectPattern();
                break;
            case "38":
                ExecuteMicroservicesPattern();
                break;
            case "39":
                ExecuteSOAPattern();
                break;
            case "40":
                ExecuteEventDrivenArchitecturePattern();
                break;
            case "41":
                ExecuteLayeredArchitecturePattern();
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
            Console.WriteLine("13. Observer");
            Console.WriteLine("14. State");
            Console.WriteLine("15. Strategy");
            Console.WriteLine("16. Template Method");
            Console.WriteLine("17. Visitor");
            Console.WriteLine("18. Chain of Responsibility");
            Console.WriteLine("19. Command");
            Console.WriteLine("20. Interpreter");
            Console.WriteLine("21. Iterator");
            Console.WriteLine("22. Mediator");
            Console.WriteLine("23. Memento");
            Console.WriteLine("24. Proxy");
            Console.WriteLine("25. MVVM");
            Console.WriteLine("26. Repository");
            Console.WriteLine("27. Unit of Work");
            Console.WriteLine("28. Dependency Injection");
            Console.WriteLine("29. Service Locator");
            Console.WriteLine("30. Event Sourcing");
            Console.WriteLine("31. CQRS");
            Console.WriteLine("32. Lazy Initialization");
            Console.WriteLine("33. Active Object");
            Console.WriteLine("34. Scheduler");
            Console.WriteLine("35. Producer-Consumer");
            Console.WriteLine("36. Thread Pool");
            Console.WriteLine("37. Monitor Object");
            Console.WriteLine("38. Microservices");
            Console.WriteLine("39. Service-Oriented Architecture (SOA)");
            Console.WriteLine("40. Event-Driven Architecture");
            Console.WriteLine("41. Layered Architecture");
            Console.WriteLine();
            Console.Write("Por favor, ingrese el número de su selección: ");
        }

        // Métodos para cada patrón de diseño
        void ExecuteAbstractFactoryPattern()
        {
            Console.WriteLine("Ejecutando Abstract Factory...");
            AbstractFactoryPattern.Program.Main(null);
        }

        void ExecuteAdapterPattern()
        {
            Console.WriteLine("Ejecutando Adapter...");
            AdapterPattern.Program.Main(null);
        }

        void ExecuteBridgePattern()
        {
            Console.WriteLine("Ejecutando Bridge...");
            BridgePattern.Program.Main(null);
        }

        void ExecuteBuilderPattern()
        {
            Console.WriteLine("Ejecutando Builder...");
            BuilderPattern.Program.Main(null);
        }

        void ExecuteCompositePattern()
        {
            Console.WriteLine("Ejecutando Composite...");
            CompositePattern.Program.Main(null);
        }

        void ExecuteDecoratorPattern()
        {
            Console.WriteLine("Ejecutando Decorator...");
            DecoratorPattern.Program.Main(null);
        }

        void ExecuteFacadePattern()
        {
            Console.WriteLine("Ejecutando Facade...");
            FacadePattern.Program.Main(null);
        }

        void ExecuteFactoryMethodPattern()
        {
            Console.WriteLine("Ejecutando Factory Method...");
            FactoryMethodPattern.Program.Main(null);
        }

        void ExecuteFlyweightPattern()
        {
            Console.WriteLine("Ejecutando Flyweight...");
            FlyweightPattern.Program.Main(null);
        }

        void ExecuteMVCPattern()
        {
            Console.WriteLine("Ejecutando Model-View-Controller (MVC)...");
            MVCPattern.Program.Main(null);
        }

        void ExecutePrototypePattern()
        {
            Console.WriteLine("Ejecutando Prototype...");
            PrototypePattern.Program.Main(null);
        }

        void ExecuteSingletonPattern()
        {
            Console.WriteLine("Ejecutando Singleton...");
            SingletonPattern.Program.Main(null);
        }

        void ExecuteObserverPattern()
        {
            Console.WriteLine("Ejecutando Observer...");
            ObserverPattern.Program.Main(null);
        }

        void ExecuteStatePattern()
        {
            Console.WriteLine("Ejecutando State...");
            StatePattern.Program.Main(null);
        }

        void ExecuteStrategyPattern()
        {
            Console.WriteLine("Ejecutando Strategy...");
            StrategyPattern.Program.Main(null);
        }

        void ExecuteTemplateMethodPattern()
        {
            Console.WriteLine("Ejecutando Template Method...");
            Template_Method__Método_Plantilla_.Program.Main(null);
        }

        void ExecuteVisitorPattern()
        {
            Console.WriteLine("Ejecutando Visitor...");
            Visitor.Program.Main(null);
        }

        void ExecuteChainOfResponsibilityPattern()
        {
            Console.WriteLine("Ejecutando Chain of Responsibility...");
            ChainOfResponsibilityPattern.Program.Main(null);
        }

        void ExecuteCommandPattern()
        {
            Console.WriteLine("Ejecutando Command...");
            CommandPattern.Program.Main(null);
        }

        void ExecuteInterpreterPattern()
        {
            Console.WriteLine("Ejecutando Interpreter...");
            Interpreter.Program.Main(null);
        }

        void ExecuteIteratorPattern()
        {
            Console.WriteLine("Ejecutando Iterator...");
            Iterator.Program.Main(null);
        }

        void ExecuteMediatorPattern()
        {
            Console.WriteLine("Ejecutando Mediator...");
            MediatorPattern.Program.Main(null);
        }

        void ExecuteMementoPattern()
        {
            Console.WriteLine("Ejecutando Memento...");
            Memento.Program.Main(null);
        }

        void ExecuteProxyPattern()
        {
            Console.WriteLine("Ejecutando Proxy...");
            Proxy.Program.Main(null);
        }

        void ExecuteMVVMPattern()
        {
            Console.WriteLine("Ejecutando Model-View-ViewModel (MVVM)...");
            Mvvm.Program.Main();
        }

        void ExecuteRepositoryPattern()
        {
            Console.WriteLine("Ejecutando Repository...");
            RepositoryPattern.Program.Main(null);
        }

        void ExecuteUnitOfWorkPattern()
        {
            Console.WriteLine("Ejecutando Unit of Work...");
            UnitOfWorkPattern.Program.Main(null);
        }

        void ExecuteDependencyInjectionPattern()
        {
            Console.WriteLine("Ejecutando Dependency Injection...");
            DependencyInjectionPattern.Program.Main(null);
        }

        void ExecuteServiceLocatorPattern()
        {
            Console.WriteLine("Ejecutando Service Locator...");
            Service_Locator.Program.Main(null);
        }

        void ExecuteEventSourcingPattern()
        {
            Console.WriteLine("Ejecutando Event Sourcing...");
            EventSourcingPattern.Program.Main(null);
        }

        void ExecuteCQRSPattern()
        {
            Console.WriteLine("Ejecutando CQRS...");
            CQRS.Program.Main(null);
        }

        void ExecuteLazyInitializationPattern()
        {
            Console.WriteLine("Ejecutando Lazy Initialization...");
            Lazy.Program.Main(null);
        }

        void ExecuteActiveObjectPattern()
        {
            Console.WriteLine("Ejecutando Active Object...");
            ActiveObject.Program.Main(null);
        }

        void ExecuteSchedulerPattern()
        {
            Console.WriteLine("Ejecutando Scheduler...");
            Scheduler.Program.Main(null);
        }

        void ExecuteProducerConsumerPattern()
        {
            Console.WriteLine("Ejecutando Producer-Consumer...");
            Producer_Consumer__Productor_Consumidor_.Program.Main(null);
        }

        void ExecuteThreadPoolPattern()
        {
            Console.WriteLine("Ejecutando Thread Pool...");
            ThreadPoolPathern.Program.Main(null);
        }

        void ExecuteMonitorObjectPattern()
        {
            Console.WriteLine("Ejecutando Monitor Object...");
            MonitorObject.Program.Main(null);
        }

        void ExecuteMicroservicesPattern()
        {
            Console.WriteLine("Ejecutando Microservices...");
            var controller = new Microservices.InventoryController();
            controller.Get(1);
        }

        void ExecuteSOAPattern()
        {
            Console.WriteLine("Ejecutando Service-Oriented Architecture (SOA)...");
            ServiceOrientedArchitecture.Program.Main(null);
        }

        void ExecuteEventDrivenArchitecturePattern()
        {
            Console.WriteLine("Ejecutando Event-Driven Architecture...");
            EventDrivenConsoleApp.Program.Main(null);
        }

        void ExecuteLayeredArchitecturePattern()
        {
            Console.WriteLine("Ejecutando Layered Architecture...");
            LayeredArchitecture.Program.Main(null);
        }

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
    }
}
