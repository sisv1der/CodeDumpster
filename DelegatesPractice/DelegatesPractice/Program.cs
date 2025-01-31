using System.Diagnostics;

namespace DelegatesPractice
{
    internal class Program
    {
        delegate void MathOperation(double a, double b);

        static void Sum(double a, double b)
        {
            Console.WriteLine(a + b);
        }

        static void Substract(double a, double b)
        {
            Console.WriteLine(a - b);
        }

        static void Multiply(double a, double b)
        {
            Console.WriteLine(a * b);
        }

        static void Divide(double a, double b)
        {
            Console.WriteLine(a / b);
        }
        static void Main(string[] args)
        {
            // Простые делегаты
            // Создай делегат, который принимает два числа и возвращает их сумму.
            // Напиши методы для сложения, вычитания, умножения и деления,
            // а затем используй делегат для вызова этих методов.

            double a = 5.4;
            double b = 4.3;

            MathOperation math = Sum;
            math(a, b); // 9,7

            math = Substract;
            math(a,b); // 1,1000000000000005

            math = Multiply;
            math(a,b); // 23,22

            math = Divide;
            math(a,b); // 1,2558139534883723

            Console.WriteLine();

            math += Multiply;
            math += Substract;
            math += Sum;

            math(a,b); // same
            Console.ReadLine();
        }
    }
}
