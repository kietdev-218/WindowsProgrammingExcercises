using System;

namespace _02_Excercisel2
{
    class Program
    {
        static int Sum(int a, int b)
        {
            return a + b;
        }

        static int Subtract(int a, int b)
        {
            return a - b;
        }

        static int Multiply(int a, int b)
        {
            return a * b;
        }

        static double Divide(int a, int b)
        {
            return (double)a / b;
        }

        static void Main(string[] args)
        {
            int a, b;
            Console.Write("Please enter a = ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter b = ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{a} + {b} = {Sum(a, b)}");
            Console.WriteLine($"{a} - {b} = {Subtract(a, b)}");
            Console.WriteLine($"{a} * {b} = {Multiply(a, b)}");
            Console.WriteLine($"{a} / {b} = {Divide(a, b)}");
        }
    }
}
