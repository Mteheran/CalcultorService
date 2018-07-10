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
        //init services
        static ICalculatorServer calculatorServer => new CalculatorServer();

        static string statusApp = string.Empty;
        static OperationType calculatorMethod = OperationType.NONE;

        static void Main(string[] args)
        {

            #region Local Functions

            void PrintResult(double resultValue) => Console.WriteLine($"The result is : {resultValue} ");
            
            List<double> GetListOfNumbers()
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

            SubModel GetNumbersSub()
            {
                var subModel = new SubModel();
                bool Iscomplete = false;
              
                while (!Iscomplete)
                {
                    Console.WriteLine("set the Minuend");
                    string readNumberOrResult = Console.ReadLine();

                    if (double.TryParse(readNumberOrResult, out double Minuend))
                    {
                        subModel.Minuend = Minuend;

                        Console.WriteLine("set the Subtrahend");
                        readNumberOrResult = Console.ReadLine();

                        if (double.TryParse(readNumberOrResult, out double Subtrahend))
                        {
                            subModel.Subtrahend = Subtrahend;
                            Iscomplete = true;
                        }
                        else
                            Console.WriteLine("Invalid Value");

                    }
                    else
                        Console.WriteLine("Invalid Value");                  

                }

                return subModel;
            }

            DivModel GetNumbersDiv()
            {
                var subModel = new DivModel();
                bool Iscomplete = false;

                while (!Iscomplete)
                {
                    Console.WriteLine("set the Dividend");
                    string readNumberOrResult = Console.ReadLine();

                    if (double.TryParse(readNumberOrResult, out double Minuend))
                    {
                        subModel.Dividend = Minuend;

                        Console.WriteLine("set the Divisor");
                        readNumberOrResult = Console.ReadLine();

                        if (double.TryParse(readNumberOrResult, out double Subtrahend))
                        {
                            subModel.Divisor = Subtrahend;
                            Iscomplete = true;
                        }
                        else
                            Console.WriteLine("Invalid Value");

                    }
                    else
                        Console.WriteLine("Invalid Value");                  

                }

                return subModel;
            }

            #endregion                 


            Console.WriteLine("WELCOME TO CALCULATOR APP");

            while (statusApp.ToLower() != "exit")
            {
                Console.WriteLine("choose on opetation (ADD, SUB, MULT, DIV) use \"exit\" to finish ");

                string readMethod = Console.ReadLine();

                if (Enum.TryParse<OperationType>(readMethod, out OperationType ExtractMethod))
                {
                    calculatorMethod = ExtractMethod;
                }

                switch (calculatorMethod)
                {
                    case OperationType.ADD:

                        List<double> listNumbers = GetListOfNumbers();

                        PrintResult(calculatorServer.Add(listNumbers).Result);

                        break;
                    case OperationType.SUB:

                        SubModel subModel = GetNumbersSub();

                        PrintResult(calculatorServer.Sub(subModel).Result);

                        break;
                    case OperationType.MULT:

                        List<double> listNumbersMULT = GetListOfNumbers();

                        PrintResult(calculatorServer.Mult(listNumbersMULT).Result);

                        break;
                    case OperationType.DIV:

                        DivModel divModel = GetNumbersDiv();

                        PrintResult(calculatorServer.Div(divModel).Result);

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
