using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            try
            {
                Console.Write("Введите выражение: ");
                Console.WriteLine(Calculation.Calculate(Console.ReadLine()));
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Проверьте правильность вводимых данных.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Используйте вместо точки - запятую");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Делить на ноль нельзя");
            }
        }
    }
}