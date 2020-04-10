using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validate_Arithmetic_Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            // http://stackoverflow.com/questions/856845/how-to-best-way-to-draw-table-in-console-app-c
            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/254ac452-83bd-489d-8ce2-462a2c9acabc/create-a-table-by-c-console-application?forum=csharpgeneral

            string s = Console.ReadLine();
            s = s.Replace(" ", string.Empty).Replace("\t\t","\t0\t");
            Console.WriteLine("Exp : " + s);
            Console.WriteLine(Validate(s) == true ? "true" : "false");
            Console.WriteLine("Res : " + new DataTable().Compute(s, ""));
            Console.Read();
        }


        public static bool Validate(string expression)
        {
            int previous = 0;
            int previous1 = 0;
            string expEvaluated = string.Empty;
            int operatorOperand = 1;
            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                if (c == ')')
                {
                }
                else if (c == '(')
                {
                    int j = expression.IndexOf(')', i);
                    if (j == -1)
                        return false;
                    string substring = expression.Substring(i + 1, j - i - 1);
                    while (getcharactercount(substring, '(') != getcharactercount(substring, ')'))
                    {
                        if (j < expression.Length - 1)
                            j = expression.IndexOf(')', j + 1);
                        else
                            break;
                        substring = expression.Substring(i + 1, j - i - 1);
                    } i = j - 1;

                    if (Validate(substring) == true)
                    {
                        if (previous != 0 && previous1 != 0 && previous > previous1)
                        {
                            previous1 = operatorOperand;
                            operatorOperand++;
                            previous = 0;
                        }
                        else if (previous != 0 && previous1 != 0 && previous <= previous1)
                        {
                            return false;
                        }
                        else if (previous1 != 0)
                        {
                            return false;
                        }
                        else
                        {
                            previous1 = operatorOperand;
                            operatorOperand++;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    if (previous != 0)
                    {
                        return false;
                    }
                    previous = operatorOperand;
                    operatorOperand++;
                }
                else
                {
                    if (previous != 0 && previous1 != 0 && previous > previous1)
                    {
                        previous1 = operatorOperand;
                        operatorOperand++;
                        previous = 0;
                    }
                    else if (previous != 0 && previous1 != 0 && previous <= previous1)
                    {
                        return false;
                    }
                    else if (previous1 != 0)
                    {
                        return false;
                    }
                    else
                    {
                        previous1 = operatorOperand;
                        operatorOperand++;
                    }
                }
            }
            if (previous != 0)
                return false;
            return true;
        }


        public static int getcharactercount(string exp, char _c)
        {
            int count = 0;
            foreach (char c in exp)
            {
                if (c == _c)
                    count++;
            }
            return count;
        }
    }
}
