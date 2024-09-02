using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
    public static int EvaluateFormula(string formula, Stack<int> numbers, Stack<char> operands)
    {
        foreach (char currentSymbol in formula)
        { 
            if (currentSymbol == ')')
            {
                int num2 = numbers.Pop();
                int num1 = numbers.Pop();
                char func = operands.Pop();
                int result = func == 'M' ? Math.Max(num1, num2) : Math.Min(num1, num2);
                numbers.Push(result);
            }
            else
            {
                if (char.IsDigit(currentSymbol))
                {
                    numbers.Push(currentSymbol - '0');
                }
                else
                {
                    if (currentSymbol == 'M' || currentSymbol == 'N')
                    {
                        operands.Push(currentSymbol);
                    }
                }
            }
        }
        return numbers.Pop();
    }
    public static void Main()
    {
        
        string formula = File.ReadAllText("C:/Users/Polya/Desktop/формула.txt");
        Console.WriteLine("{0}", formula);

        Stack<char> operands = new();
        Stack<int> numbers = new();

        int result = EvaluateFormula(formula, numbers, operands);
        Console.WriteLine("Значение формулы: {0}", result);

    }

}