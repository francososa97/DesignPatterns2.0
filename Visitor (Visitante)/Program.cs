using System;
using System.Collections.Generic;

namespace Visitor;
// Interfaz Element que acepta un Visitor
public interface IElement
{
    void Accept(IVisitor visitor);
}

// Elemento Concreto A
public class ConcreteElementA : IElement
{
    public string ElementAProperty { get; set; } = "Elemento A";

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

// Elemento Concreto B
public class ConcreteElementB : IElement
{
    public int ElementBProperty { get; set; } = 42;

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

// Interfaz Visitor
public interface IVisitor
{
    void Visit(ConcreteElementA elementA);
    void Visit(ConcreteElementB elementB);
}

// Visitor Concreto que realiza una operación específica
public class ConcreteVisitor : IVisitor
{
    public void Visit(ConcreteElementA elementA)
    {
        Console.WriteLine($"Visitando {elementA.ElementAProperty}");
    }

    public void Visit(ConcreteElementB elementB)
    {
        Console.WriteLine($"Visitando elemento con valor: {elementB.ElementBProperty}");
    }
}

// Aplicación de consola
public class Program
{
    /// <summary>
    /// El patrón Visitor permite definir una nueva operación sin cambiar las clases de los elementos sobre los que opera. Es útil cuando necesitas realizar operaciones sobre una estructura de objetos sin modificar sus clases.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        Console.WriteLine("Este ejemplo demuestra el patrón Visitor, que permite definir nuevas operaciones sin cambiar las clases de los elementos sobre los que opera.");
        // Crear elementos
        var elements = new List<IElement>
        {
            new ConcreteElementA(),
            new ConcreteElementB()
        };

        // Crear un visitor
        var visitor = new ConcreteVisitor();

        // Pasar el visitor a cada elemento
        foreach (var element in elements)
        {
            element.Accept(visitor);
        }

        Console.ReadKey();
    }
}
