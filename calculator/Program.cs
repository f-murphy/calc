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
                Calculation calculation = new Calculation();
                Console.WriteLine(calculation.Calc(Console.ReadLine()));
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