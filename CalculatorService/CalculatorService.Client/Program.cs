namespace CalculatorService.Client
{
    using CalculatorService.Client.Enums;
    using CalculatorService.Client.Services;
    using CalculatorService.Client.Services.Contracts;
    using CalculatorService.Models;
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {

            #region Local Functions

            void PrintResult(double resultValue) => Console.WriteLine($"The result is : {resultValue} ");
            
            List<double> GetNumbersSum()
            {
                List<double> listNumbers = new List<double>();

                string result = string.Empty;

                    while (result == string.Empty)
                    {
                        Console.WriteLine("Write a number to add on the list or \"result\" to complete the operation");
                        string readNumberOrResult = Console.ReadLine();

                    if (double.TryParse(readNumberOrResult, out double Number))
                        listNumbers.Add(Number);
                    else if (readNumberOrResult == "result")
                        result = readNumberOrResult;
                    else
                        Console.WriteLine("Invalid Value");

                    }

                    return listNumbers;
             }

            SubEntity GetNumbersSub()
            {
                var subModel = new SubEntity();
                bool Iscomplete = false;
              
                while (!Iscomplete)
                {
                    Console.WriteLine("Write the Minuend");
                    string readNumberOrResult = Console.ReadLine();

                    if (double.TryParse(readNumberOrResult, out double Minuend))
                        subModel.Minuend = Minuend;
                    else
                        Console.WriteLine("Invalid Value");

                    Console.WriteLine("Write the Subtrahend");
                    readNumberOrResult = Console.ReadLine();

                    if (double.TryParse(readNumberOrResult, out double Subtrahend))
                    {
                        subModel.Subtrahend = Subtrahend;
                        Iscomplete = true;
                    }
                    else
                        Console.WriteLine("Invalid Value");

                }

                return subModel;
            }


            #endregion


            //init services
            ICalculatorServer calculatorServer = new CalculatorServer();

            string statusApp = string.Empty;
            OperationType calculatorMethod = OperationType.NONE;


            Console.WriteLine("WELCOME TO CALCULATOR APP");

            while (statusApp.ToLower() != "exit")
            {
                Console.WriteLine("choose on opetation (ADD, SUB, MULT) use \"exit\" to finish ");

                string readMethod = Console.ReadLine();

                if (Enum.TryParse<OperationType>(readMethod, out OperationType ExtractMethod))
                {
                    calculatorMethod = ExtractMethod;
                }

                switch (calculatorMethod)
                {
                    case OperationType.ADD:

                        List<double> listNumbers = GetNumbersSum();

                        PrintResult(calculatorServer.Add(listNumbers).Result);

                        break;
                    case OperationType.SUB:

                        SubEntity subModel = GetNumbersSub();

                        PrintResult(calculatorServer.Sub(subModel).Result);

                        break;
                    case OperationType.MULT:
                        break;
                    case OperationType.DIV:
                        break;
                    case OperationType.SQRT:
                        break;
                    case OperationType.NONE:
                    default:
                        break;
                }                             

            }

           

            Console.ReadLine();
        }
    }
}
