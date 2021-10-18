using System;
using System.Collections.Generic;

namespace LabWork1
{
    class Program
    {
        //введення входу нейрона
        static int InputX(int? num)
        {
            if(num == null)
                Console.WriteLine($"Input x (only 1 or 0):");
            else
                Console.WriteLine($"Input x{num} (only 1 or 0):");
            int x = Convert.ToInt32(Console.ReadLine());
            if (x > 1)
                InputX(num);
            return x;
        }
        //перетворення з рядка в перечислення назви логічних функцій
        static LogicalFunction GetLogicalFunction(string str)
        {
            if (str == "AND")
                return LogicalFunction.AND;
            else if (str == "OR")
                return LogicalFunction.OR;
            else if (str == "NOT")
                return LogicalFunction.NOT;
            else if (str == "XOR")
                return LogicalFunction.XOR;
            return LogicalFunction.Unknown;
        }
        //введення даних і перевірка правильності введених даних
        static void Input()
        {
            Console.WriteLine("Input logical function (AND, OR, NOT, XOR)");
            string str = Console.ReadLine().ToUpper();

            LogicalFunction logicalFunction = GetLogicalFunction(str);

            if (logicalFunction != LogicalFunction.Unknown)
            {
                ModelingLogicalFunction modeling;
                if (logicalFunction == LogicalFunction.NOT)
                {
                    int x = InputX(null);
                    modeling = new ModelingLogicalFunction(x, logicalFunction);
                }
                else
                {
                    int x1 = InputX(1);
                    int x2 = InputX(2);
                    modeling = new ModelingLogicalFunction(x1, x2, logicalFunction); ;
                }
                List<int> y = modeling.Modeling();
                for (int i = 0; i < y.Count; i++)
                    Console.WriteLine($"Y{i} = {y[i]}");
                Console.WriteLine();
            }
            else
                Console.WriteLine("You do not type AND, OR, NOT, XOR");
            Continue();
        }
        //повторення програми
        static void Continue()
        {
            Console.WriteLine("Do you want to continue (input yes or no)?");
            string str = Console.ReadLine().ToLower();
            Console.WriteLine();
            switch (str)
            {
                case "yes":
                    Input();
                    break;
                case "no":
                    break;
                default:
                    Console.WriteLine("You don`t type yes or no! Try again!");
                    Continue();
                    break;
            }
        }
        //запуск програми
        static void Main(string[] args)
        {
            Input();
        }
    }
}
