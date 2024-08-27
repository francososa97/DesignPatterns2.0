using System;
namespace Interpreter;


class Program
{
    static void Main(string[] args)
    {
        // Contexto para almacenar variables (en este caso, vacío)
        var context = new Context();

        // Expresión a interpretar: 5 + 3 - 2
        IExpression expression = new SubtractExpression(
            new AddExpression(
                new NumberExpression(5),
                new NumberExpression(3)
            ),
            new NumberExpression(2)
        );

        // Interpretar la expresión
        int result = expression.Interpret(context);
        Console.WriteLine($"El resultado de la expresión es: {result}");

        Console.ReadKey();
    }
}

// Interfaz de expresión abstracta
public interface IExpression
{
    int Interpret(Context context);
}

// Expresión terminal que representa un número
public class NumberExpression : IExpression
{
    private readonly int _number;

    public NumberExpression(int number)
    {
        _number = number;
    }

    public int Interpret(Context context)
    {
        return _number;
    }
}

// Expresión no terminal que representa una adición
public class AddExpression : IExpression
{
    private readonly IExpression _leftExpression;
    private readonly IExpression _rightExpression;

    public AddExpression(IExpression leftExpression, IExpression rightExpression)
    {
        _leftExpression = leftExpression;
        _rightExpression = rightExpression;
    }

    public int Interpret(Context context)
    {
        return _leftExpression.Interpret(context) + _rightExpression.Interpret(context);
    }
}

// Expresión no terminal que representa una sustracción
public class SubtractExpression : IExpression
{
    private readonly IExpression _leftExpression;
    private readonly IExpression _rightExpression;

    public SubtractExpression(IExpression leftExpression, IExpression rightExpression)
    {
        _leftExpression = leftExpression;
        _rightExpression = rightExpression;
    }

    public int Interpret(Context context)
    {
        return _leftExpression.Interpret(context) - _rightExpression.Interpret(context);
    }
}

// Contexto compartido (puede almacenar variables o información adicional)
public class Context
{
    // En este ejemplo, el contexto está vacío, pero puede ser extendido para soportar variables u otros datos.
}
