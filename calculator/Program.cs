using System;

class Program
{
    static void Main(string[] args)
    {
        do
        {
            try
            {
                Console.Write("Введите выражение: ");
                Console.WriteLine(Calculation.Calc(Console.ReadLine()));
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Проверьте правильность вводимых данных.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Используйте вместо точки - запятую");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Делить на ноль нельзя");
            }
        } while (true);
    }
}