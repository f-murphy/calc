using System.Collections.Generic;

class Calculation
{
    static private bool CheckedDelimeter(char c)
    {
        if ((" =".IndexOf(c) != -1))
            return true;
        return false;
    }

    static private bool CheckedOperator(char c)
    {
        if (("+-/*^()".IndexOf(c) != -1))
            return true;
        return false;
    }

    static private byte CheckedPriority(char s)
    {
        switch (s)
        {
            case '(':
                return 0;
            case ')':
                return 1;
            case '+':
                return 2;
            case '-':
                return 3;
            case '*':
                return 4;
            case '/':
                return 4;
            case '^':
                return 5;
            default:
                return 6;
        }
    }

    static public double Calculate(string input)
    {
        string output = GetExpression(input);
        double result = Counting(output);
        return result;
    }

    static public string GetExpression(string input)
    {
        string output = string.Empty;
        Stack<char> operStack = new Stack<char>();
        foreach (int i in input)
        {
            if (CheckedDelimeter(input(i)))
                continue;

            if (char.IsDigit(input(i)))
            {
                while (!CheckedDelimeter(input(i)) && !CheckedDelimeter(input(i)))
                {
                    output += input[i];
                    i++;
                    if (i == input.Length) break;
                }
                output += " ";
                i--;
            }

            if (CheckedOperator(input[i]))
            {

                if (input[i] == '(')
                    operStack.Push(input[i]);

                else if (input[i] == ')')
                {
                    char s = operStack.Pop();

                    while (s != '(')
                    {
                        output += s.ToString() + ' ';
                        s = operStack.Pop();
                    }
                }

                else

                {
                    if (operStack.Count > 0)

                        if (CheckedPriority(input[i]) <= CheckedPriority(operStack.Peek()))
                            output += operStack.Pop().ToString() + ' ';

                    operStack.Push(char.Parse(input[i].ToString()));
                }
            }

        }

        while (operStack.Count > 0)
            output += operStack.Pop().ToString() + ' ';

        return output;
    }

    static private double Counting(string input)
    {
        double result = 0;
        Stack<double> temp = new Stack<double>();

        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsDigit(input[i]))
            {
                string a = string.Empty;

                while (!CheckedDelimeter(input[i]) && !CheckedOperator(input[i]))
                {
                    a += input[i];
                    i++;
                    if (i == input.Length) break;
                }
                temp.Push(double.Parse(a));
                i--;
            }
            else if (CheckedOperator(input[i]))
            {
                double a = temp.Pop();
                double b = temp.Pop();

                switch (input[i])
                {
                    case '+':
                        result = b + a;
                        break;
                    case '-':
                        result = b - a;
                        break;
                    case '*':
                        result = b * a;
                        break;
                    case '/':
                        result = b / a;
                        break;
                    case '^':
                        result = double.Parse(System.Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString());
                        break;
                }
                temp.Push(result);
            }
        }
        return temp.Peek();
    }
}