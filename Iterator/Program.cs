namespace Iterator;

using System;
using System.Collections.Generic;

// Interfaz Iterator
public interface IIterator<T>
{
    T Current { get; }
    bool MoveNext();
    void Reset();
}

// Interfaz Aggregate
public interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}

// Clase ConcreteAggregate
public class NumberCollection : IAggregate<int>
{
    private List<int> _numbers = new List<int>();

    public void AddNumber(int number)
    {
        _numbers.Add(number);
    }

    public IIterator<int> CreateIterator()
    {
        return new NumberIterator(this);
    }

    public int Count => _numbers.Count;

    public int this[int index] => _numbers[index];
}

// Clase ConcreteIterator
public class NumberIterator : IIterator<int>
{
    private NumberCollection _collection;
    private int _currentIndex = -1;

    public NumberIterator(NumberCollection collection)
    {
        _collection = collection;
    }

    public int Current => _collection[_currentIndex];

    public bool MoveNext()
    {
        if (_currentIndex + 1 < _collection.Count)
        {
            _currentIndex++;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        _currentIndex = -1;
    }
}

public class Program
{
/// <summary>
/// El patrón Iterator proporciona una forma de acceder secuencialmente a los elementos de una colección sin exponer su representación subyacente. Es útil para recorrer colecciones sin exponer sus detalles internos.
/// </summary>
/// <param name="args"></param>
public static void Main(string[] args)
    {
        Console.WriteLine("Este ejemplo demuestra el patrón Iterator, que proporciona una forma de acceder secuencialmente a los elementos de una colección sin exponer su representación subyacente.");
        // Crear una colección de números
        var numberCollection = new NumberCollection();
        numberCollection.AddNumber(1);
        numberCollection.AddNumber(2);
        numberCollection.AddNumber(3);
        numberCollection.AddNumber(4);
        numberCollection.AddNumber(5);

        // Crear un iterador para la colección
        var iterator = numberCollection.CreateIterator();

        Console.WriteLine("Iterando sobre la colección de números:");
        while (iterator.MoveNext())
        {
            Console.WriteLine(iterator.Current);
        }

        Console.WriteLine("Fin de la iteración.");
    }
}
