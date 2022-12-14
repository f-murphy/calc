using System.Collections.Generic;

class Calculation
{
    private bool CheckDelimeter(char c)
    {
        if ((" =".IndexOf(c) != -1))
            return true;
        return false;
    }

    private bool CheckOperator(char c)
    {
        if (("+-/*^()".IndexOf(c) != -1))
            return true;
        return false;
    }

    private byte CheckPriority(char s)
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

    public double Calc(string input)
    {
        string output = RepresPostfixForm(input);
        double result = CalculatePostfixForm(output);
        return result;
    }

    private string RepresPostfixForm(string input)
    {
        string output = string.Empty;
        Stack<char> operStack = new Stack<char>();

        for (int i = 0; i < input.Length; i++)
        {
            if (CheckDelimeter(input[i]))
                 continue;
            if (Char.IsDigit(input[i]))
            {
                 while (!CheckDelimeter(input[i]) && !CheckOperator(input[i]))
                 {
                     output += input[i];
                     i++;

                     if (i == input.Length) 
                        break;
                 }
                 output += " "; 
                 i--; 
            }
            if (CheckOperator(input[i]))
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
                        if (CheckPriority(input[i]) <= CheckPriority(operStack.Peek()))
                            output += operStack.Pop().ToString() + " ";
                    operStack.Push(char.Parse(input[i].ToString()));
                }
            }
        }
        while (operStack.Count > 0)
            output += operStack.Pop() + " ";

        return output;
    }

    private double CalculatePostfixForm(string input)
    {
        double result = 0;
        Stack<double> temp = new Stack<double>();

        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsDigit(input[i]))
            {
                string a = string.Empty;

                while (!CheckDelimeter(input[i]) && !CheckOperator(input[i]))
                {
                    a += input[i];
                    i++;
                    if (i == input.Length) break;
                }
                temp.Push(double.Parse(a));
                i--;
            }
            else if (CheckOperator(input[i]))
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