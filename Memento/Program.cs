namespace Memento;

public class Program
{
    /// <summary>
    ///  El patrón Memento permite capturar y restaurar el estado interno de un objeto sin violar su encapsulamiento. Es útil para implementar funcionalidades de deshacer y rehacer, aunque puede aumentar el uso de memoria.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        Console.WriteLine("Este ejemplo demuestra el patrón Memento, que permite capturar y restaurar el estado de un objeto para soportar operaciones de deshacer.");
        TextEditor editor = new TextEditor();
        Caretaker caretaker = new Caretaker();

        // Realizar operaciones en el editor
        editor.Content = "Primera versión del texto.";
        caretaker.SaveState(editor.CreateMemento());

        editor.Content = "Segunda versión del texto.";
        caretaker.SaveState(editor.CreateMemento());

        editor.Content = "Tercera versión del texto.";

        Console.WriteLine("Contenido actual: " + editor.Content);

        // Deshacer el último cambio
        editor.RestoreMemento(caretaker.Undo());
        Console.WriteLine("Después de deshacer: " + editor.Content);

        // Deshacer otro cambio
        editor.RestoreMemento(caretaker.Undo());
        Console.WriteLine("Después de deshacer otra vez: " + editor.Content);

        Console.ReadKey();
    }
}

// Clase que representa el Originador
public class TextEditor
{
    public string Content { get; set; }

    // Crear un Memento con el estado actual
    public Memento CreateMemento()
    {
        return new Memento(Content);
    }

    // Restaurar el estado desde un Memento
    public void RestoreMemento(Memento memento)
    {
        Content = memento.Content;
    }
}

// Clase que representa el Memento
public class Memento
{
    public string Content { get; }

    public Memento(string content)
    {
        Content = content;
    }
}

// Clase que representa el Caretaker
public class Caretaker
{
    private Stack<Memento> _mementos = new Stack<Memento>();

    // Guardar el estado actual en la pila
    public void SaveState(Memento memento)
    {
        _mementos.Push(memento);
    }

    // Deshacer el último cambio y devolver el estado anterior
    public Memento Undo()
    {
        if (_mementos.Count > 0)
        {
            return _mementos.Pop();
        }
        else
        {
            return null; // No hay estados para deshacer
        }
    }
}
