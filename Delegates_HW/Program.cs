using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Создайте набор методов:
■ Метод для отображения текущего времени;
■ Метод для отображения текущей даты;
■ Метод для отображения текущего дня недели;
■ Метод для подсчёта площади треугольника;
■ Метод для подсчёта площади прямоугольника.
Для реализации проекта используйте делегаты Action,
Predicate, Func.*/

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

            date.TimeNow();
            date.DateNow();
        }
    }
}
