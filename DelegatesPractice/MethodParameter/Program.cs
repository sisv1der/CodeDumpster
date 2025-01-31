namespace MethodParameter
{
    internal class Program
    {
        delegate double MathOperation(double a, double b);

        static void DelegateReceiver(MathOperation method, double a, double b)
        {
            Console.WriteLine(method(a,b));
        }

        static double Sum(double a, double b)
        {
            return a + b;
        }

        static double Substract(double a, double b)
        {
            return a - b;
        }

        static double Multiply(double a, double b)
        {
            return a * b;
        }

        static double Divide(double a, double b)
        {
            return a / b;
        }
        static void Main(string[] args)
        {
            // Передача методов в качестве параметров
            // Создай метод, который принимает делегат и два числа,
            // а затем вызывает переданный метод.
            // Используй этот метод для выполнения различных математических операций.

            double a = 7.6;
            double b = 9.2;

            MathOperation math = Sum;
            DelegateReceiver(math, a, b); // 16,799999999999997

            math = Substract;
            DelegateReceiver(math, a, b); // -1,5999999999999996

            math = Multiply;
            DelegateReceiver(math, a, b); // 69,91999999999999

            math = Divide;
            DelegateReceiver(math, a, b); // 0,8260869565217391 

            Console.ReadLine();
        }
    }
}
