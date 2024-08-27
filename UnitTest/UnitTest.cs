namespace UnitTest;

public class PatternTests
{
    private StringWriter _consoleOutput;
    private StringReader _consoleInput;

    [SetUp]
    public void Setup()
    {
        // Redirigir la salida de la consola para capturarla
        _consoleOutput = new StringWriter();
        Console.SetOut(_consoleOutput);
    }

    [TearDown]
    public void TearDown()
    {
        // Restaurar la salida de la consola
        _consoleOutput.Dispose();
        Console.SetOut(Console.Out);
    }

    [TestCase("1", "Ejecutando Abstract Factory...")]
    [TestCase("2", "Ejecutando Adapter...")]
    [TestCase("3", "Ejecutando Bridge...")]
    [TestCase("4", "Ejecutando Builder...")]
    [TestCase("5", "Ejecutando Composite...")]
    [TestCase("6", "Ejecutando Decorator...")]
    [TestCase("7", "Ejecutando Facade...")]
    [TestCase("8", "Ejecutando Factory Method...")]
    [TestCase("9", "Ejecutando Flyweight...")]
    [TestCase("10", "Ejecutando Model-View-Controller (MVC)...")]
    [TestCase("11", "Ejecutando Prototype...")]
    [TestCase("12", "Ejecutando Singleton...")]
    [TestCase("13", "Ejecutando Observer...")]
    [TestCase("14", "Ejecutando State...")]
    [TestCase("15", "Ejecutando Strategy...")]
    [TestCase("16", "Ejecutando Template Method...")]
    [TestCase("17", "Ejecutando Visitor...")]
    [TestCase("18", "Ejecutando Chain of Responsibility...")]
    [TestCase("19", "Ejecutando Command...")]
    [TestCase("20", "Ejecutando Interpreter...")]
    [TestCase("21", "Ejecutando Iterator...")]
    [TestCase("22", "Ejecutando Mediator...")]
    [TestCase("23", "Ejecutando Memento...")]
    [TestCase("24", "Ejecutando Proxy...")]
    [TestCase("25", "Ejecutando Model-View-ViewModel (MVVM)...")]
    [TestCase("26", "Ejecutando Repository...")]
    [TestCase("27", "Ejecutando Unit of Work...")]
    [TestCase("28", "Ejecutando Dependency Injection...")]
    [TestCase("29", "Ejecutando Service Locator...")]
    [TestCase("30", "Ejecutando Event Sourcing...")]
    [TestCase("31", "Ejecutando CQRS...")]
    [TestCase("32", "Ejecutando Lazy Initialization...")]
    [TestCase("33", "Ejecutando Active Object...")]
    [TestCase("34", "Ejecutando Scheduler...")]
    [TestCase("35", "Ejecutando Producer-Consumer...")]
    [TestCase("36", "Ejecutando Thread Pool...")]
    [TestCase("37", "Ejecutando Monitor Object...")]
    [TestCase("38", "Ejecutando Microservices...")]
    [TestCase("39", "Ejecutando Service-Oriented Architecture (SOA)...")]
    [TestCase("40", "Ejecutando Event-Driven Architecture...")]
    [TestCase("41", "Ejecutando Layered Architecture...")]
    public void TestPatterns(string input, string expectedOutput)
    {
        // Simular la entrada de consola
        _consoleInput = new StringReader(input);
        Console.SetIn(_consoleInput);
        // Ejecutar el método Main de tu programa
        DesignPatterns.Program.Main(new string[0]);

        // Capturar la salida de la consola
        string consoleOutput = _consoleOutput.ToString();

        // Verificar que la salida contiene el texto esperado
        Assert.IsTrue(consoleOutput.Contains(expectedOutput));
    }
}
