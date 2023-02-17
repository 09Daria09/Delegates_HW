using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_HW
{
    class Program
    {
        delegate bool ArithmDeleg(int num);
        struct Arithmetic
        {
            public bool Parity(int num)
            {
                Console.Write($"Parity |{num}| -> ");
                if (num % 2 == 0)
                {
                    return true;
                }
                return false;
            }
            public bool Odd(int num)
            {
                Console.Write($"Odd |{num}| -> ");
                if (num % 2 == 0)
                {
                    return false;
                }
                return true;
            }
            public bool Simple(int num)
            {
                Console.Write($"Simple |{num}| -> ");
                if (num <= 1)
                {
                    return false;
                }

                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                    {
                        return false;
                    }
                }

                return true;
            }
            public bool Fibanachi(int num)
            {
                Console.Write($"Fibanachi |{num}| -> ");
                if (num == 0 || num == 1)
                    return true;

                int fib1 = 0;
                int fib2 = 1;
                int Sum = 0;

                while (Sum < num)
                {
                    Sum = fib1 + fib2;
                    fib1 = fib2;
                    fib2 = Sum;
                }

                return Sum == num;
            }
        }

        delegate void DateDeleg();
        delegate double SquareDeleg(int a, int b, int c);

        struct DateAndSquare
        {
            public void TimeNow()
            {
                DateTime time = DateTime.Now;
                Console.WriteLine("Текущее время: " + time.ToString("HH:mm:ss"));
            }
            public void DateNow()
            {
                DateTime time = DateTime.Now;
                Console.WriteLine("Текущая дата: " + time.ToShortDateString());
            }
            public void WeekNow()
            {
                DateTime time = new DateTime();
                Console.WriteLine("Текущий день недели: " + time.ToString("dddd"));
            }
            public double SquareTriangle(int a, int b, int c)
            {
                double p = (a + b + c) / 2.0;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            public double SquareRectangle(int a, int b, int c = 0)
            {
                return a*b; 
            }

        }
        static void Main(string[] args)
        {
            //1
            Arithmetic arithmetic = new Arithmetic();
            ArithmDeleg deleg = new ArithmDeleg(arithmetic.Parity);

            deleg += arithmetic.Odd;
            deleg += arithmetic.Simple;
            deleg += arithmetic.Fibanachi;

            foreach (ArithmDeleg item in deleg.GetInvocationList())
            {
                Console.WriteLine("{0}", item.Invoke(13));
            }
            //2

            DateAndSquare date = new DateAndSquare();
            DateDeleg dateDeleg = new DateDeleg(date.TimeNow);

            dateDeleg();
            dateDeleg = date.WeekNow;
            dateDeleg();
            dateDeleg = date.DateNow;
            dateDeleg();

            DateAndSquare square = new DateAndSquare();
            SquareDeleg[] squareDeleg = { square.SquareTriangle, square.SquareRectangle };

            Console.WriteLine($"Пощадь треугольника -> {squareDeleg[0](5, 6, 7)}");
            Console.WriteLine($"Пощадь прямоугольника -> {squareDeleg[1](7, 43, 8)}");
        }
    }
}
