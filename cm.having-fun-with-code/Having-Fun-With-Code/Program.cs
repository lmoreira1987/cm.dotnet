using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Task: Spread sheet

Need to implement a console application which calculates the formulas in spread sheet. The application should simulate the behavior of the Excel in simplified way.
As the inputs the application accepts paths to input and output files. 
Input file contains "cells" with the formulas. 
The cell position can be references as <Letter><Number> where <Letter> - is a column name (A,B,C...) and <Number> is a row number (1,2,3,..11,12,...) - like in regular Excel spreadsheet
Input file has following format:

1st line: M N - (integer values - numbers of rows and "cells" in each row)
2nd line and up to (M-1)th: Expression1 Expression2 ... ExpressionN - tab-separated list of expressions, one expression per cell

Expressions could contain basic mathematical operations - +,-,*,/ - and braces. An expression's operands could be integer values (both positive and negative) as well as references to another "cells" in the spreadsheet.
Here are some examples:
1
-16
5/6
1+2*3
(9-3)/1
A1+B2*4-B3
If an expression is an empty string - it's treated as a zero value.

Input file example:
input.txt --------------------------------------------------------------------
3 3
1	2	A1+B1
B2-C2*C1	4	A3
-5	-1	B3
------------------------------------------------------------------------------

An output file should contain the resulted spreadsheet with values in the cells calculated.
Example:
output.txt -------------------------------------------------------------------
1 2 3
19 4 -5
-5 -1 -1
------------------------------------------------------------------------------

If there are any errors in file data, format, expressions etc. - an application should print a meaningful error messages about each of such cases.
Example of file with errors:
input.txt --------------------------------------------------------------------
2 2
6*	1
2	3-
------------------------------------------------------------------------------

output.txt -------------------------------------------------------------------
*6	1
2	3-
Error in expression at A1 - missing first operand
Error in expression at B2 - missing second operand
------------------------------------------------------------------------------

It is expected that the code will show a good design approach, algorithm implementation is effective and some basic test coverage is provided.

Please send the result in form of MS Visual Studio solution.
 * 
 * */

namespace HFWC_Luxoft_Spreadsheet
{
    public class Program
    {
        public static int Rows { get; set; }
        public static int Columns { get; set; }

        static void Main(string[] args)
        {
            /*
             * 1. The application doesn't handle input parameters as requested by the task - input path is hard-coded (DONE)
             * 2. Output is printed on screen while it was expected to have it in file specified as application argument
             * 3. The file format is incorrect - according to task the first line in the file holds dimensions
             * 4. Overall design is poor - everything is in the single class, solution not extensible.
             * 5. According to conditions all errors in formulas should be processed by the app and presented in the meaningful way (examples were specified in the tasks description)- instead it prints a raw exception on the first error and exits
             * 6. The size of spreadsheet is not variable and hard-coded 5 * 5 - there was no limitation on the size in the task
             * 7. Some coding approaches (like the big case with letters) is questionable - this could be easily done in more elegant fashion. Also this case shows that up to 26 columns were expected but as mentioned in item 7 data structure allows only 5 rows and 5 columns.
             */

            TaskSpreadsheet();
        }

        /// <summary>
        /// This method has the whole logic that was made to this task
        /// </summary>
        private static void TaskSpreadsheet()
        {
            string input = Input();

            string[,] matrix = InitializeMatrix(input);

            int count = 0;
            int rows = 0;
            int columns = 0;

            do
            {
                if (input[count] == '\t' || input[count] == '\r')
                {
                    int index = 0;

                    if (input[count] == '\t')
                    {
                        index = input.IndexOf('\t');
                        matrix[rows, columns] = input.Substring(0, index);
                        input = input.Substring(index + 1, input.Length - (index + 1));
                        columns++;

                    }
                    else
                    {
                        index = input.IndexOf('\r');
                        matrix[rows, columns] = input.Substring(0, index);
                        input = input.Substring(index + 2, input.Length - (index + 2));
                        rows++;
                        columns = 0;
                    }

                    count = -1;
                }

                count++;

                if (input.Length == count)
                {
                    matrix[rows, columns] = input;
                    input = null;
                }

            } while (!string.IsNullOrEmpty(input));

            Output(matrix);

            Console.Read();
        }

        /// <summary>
        /// This method is to retrieve the values from a file, print in the screen and return values to manipulation
        /// </summary>
        private static string Input()
        {
            Console.WriteLine("----- Input -----");
            string input = System.IO.File.ReadAllText(@"..\..\input\input_1.txt");
            Console.WriteLine(input);

            return input;
        }

        /// <summary>
        /// This method will show the value in command
        /// </summary>
        /// <param name="matrix">Matrix manipulated</param>
        private static void Output(string[,] matrix)
        {
            Console.WriteLine("----- Output -----");

            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    matrix[r, c] = ChangeExpressionToValues(matrix[r, c], matrix);
                    matrix[r, c] = new DataTable().Compute(ChangeExpressionToValues(matrix[r, c], matrix), "").ToString();
                    Console.Write(matrix[r, c] == "0" ? String.Empty : matrix[r, c] + "\t");
                }

                Console.Write("\r\n");
            }
        }

        /// <summary>
        /// Initialize a matrix with the size of rows and columns; and put 0 as start value to all cells.
        /// </summary>
        /// <param name="matriz">Matrix that we are using</param>
        private static string[,] InitializeMatrix(string input)
        {
            string[,] matrix = null;

            if (string.IsNullOrEmpty(input)) return matrix;

            FirstLine();
            OtherLines();

            int columnsAux = 0;
            Rows = input.Contains('\t') ? 0 : 1;
            Columns = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\t')
                    columnsAux++;
                else if (input.Length - 1 == i || input[i] == '\r')
                {
                    columnsAux++;

                    if (columnsAux > Columns) Columns = columnsAux;

                    columnsAux = 0;
                    Rows++;
                }
            }

            matrix = new string[Rows, Columns];

            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    matrix[r, c] = "0";
                }
            }

            return matrix;
        }

        private static void OtherLines()
        {
            throw new NotImplementedException();
        }

        private static void FirstLine()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Retrieve in the following format X,X
        /// </summary>
        /// <param name="item"></param>
        /// <returns>string</returns>
        private static string ReplaceValue(string item)
        {
            string res = "";
            string valueColumn = "";
            for (int i = 0; i < item.Length; i++)
            {
                if (item[i] == ',') continue;

                if (item[i] == '+' || item[i] == '-' || item[i] == '*' || item[i] == '/')
                {
                    res = "";
                    valueColumn = "";
                    continue;
                }

                if (res == "")
                {
                    valueColumn = ReturnValue(item[i].ToString());
                    if (valueColumn != item[i].ToString())
                    {
                        res = "column";
                        item = InsertRemove(item, i, valueColumn);
                    }
                }
                else
                {
                    if (res == "column")
                    {
                        item = InsertRemove(item, i, (Convert.ToInt32(item[i].ToString()) - 1).ToString());
                    }
                }
            }

            return item;
        }

        /// <summary>
        /// Mapped values are returned
        /// </summary>
        /// <param name="item">item to be validated</param>
        /// <returns>the correct value</returns>
        private static string ReturnValue(string item)
        {
            switch (item.ToUpper())
            {
                case "A": item = item.Replace("A", "0,"); break;
                case "B": item = item.Replace("B", "1,"); break;
                case "C": item = item.Replace("C", "2,"); break;
                case "D": item = item.Replace("D", "3,"); break;
                case "E": item = item.Replace("E", "4,"); break;
                case "F": item = item.Replace("F", "5,"); break;
                case "G": item = item.Replace("G", "6,"); break;
                case "H": item = item.Replace("H", "7,"); break;
                case "I": item = item.Replace("I", "8,"); break;
                case "J": item = item.Replace("J", "9,"); break;
                case "K": item = item.Replace("K", "10,"); break;
                case "L": item = item.Replace("L", "11,"); break;
                case "M": item = item.Replace("M", "12,"); break;
                case "N": item = item.Replace("N", "13,"); break;
                case "O": item = item.Replace("O", "14,"); break;
                case "P": item = item.Replace("P", "15,"); break;
                case "Q": item = item.Replace("Q", "16,"); break;
                case "R": item = item.Replace("R", "17,"); break;
                case "S": item = item.Replace("S", "18,"); break;
                case "T": item = item.Replace("T", "19,"); break;
                case "U": item = item.Replace("U", "20,"); break;
                case "V": item = item.Replace("V", "21,"); break;
                case "W": item = item.Replace("W", "22,"); break;
                case "X": item = item.Replace("X", "23,"); break;
                case "Y": item = item.Replace("Y", "24,"); break;
                case "Z": item = item.Replace("Z", "25,"); break;
                default:
                    break;
            }

            return item;
        }

        /// <summary>
        /// Use the getvalue to put the correct value in the expression
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static string ChangeExpressionToValues(string expression, string[,] matrix)
        {
            expression = ReplaceValue(expression);
            return ReplaceMatrixGetValue(expression, matrix);
        }

        /// <summary>
        /// Insert and Remove
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="index"></param>
        /// <param name="replaceBy"></param>
        /// <returns></returns>
        public static string InsertRemove(string actual, int index, string replaceBy)
        {
            int plus = replaceBy.Contains(',') ? 2 : 1;
            actual = actual.Insert(index, replaceBy);
            actual = actual.Remove(index + plus, 1);

            return actual;
        }

        /// <summary>
        /// Insert and Remove between comma
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="index"></param>
        /// <param name="replaceBy"></param>
        /// <returns></returns>
        private static string InsertRemoveComma(string actual, int index, string replaceBy)
        {
            actual = actual.Remove(index - 1, 3);
            actual = actual.Insert(index - 1, replaceBy);

            return actual;
        }

        /// <summary>
        /// Replace the matrix with the getvalue
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static string ReplaceMatrixGetValue(string actual, string[,] matrix)
        {
            for (int i = 0; i < actual.Length; i++)
            {
                if (actual[i] == ',')
                {
                    int previews = Convert.ToInt32(actual[i - 1].ToString());
                    int next = Convert.ToInt32(actual[i + 1].ToString());

                    string value = matrix.GetValue(next, previews).ToString();

                    actual = InsertRemoveComma(actual, i, value).Replace("--", "+").Replace("++", "+").Replace("**", "*").Replace("//", "/");
                    i = -1;
                }
            }

            return actual;
        }
    }
}
