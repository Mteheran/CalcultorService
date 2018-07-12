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
                        Console.WriteLine("enter a number to add on the list or \"result\" to complete the operation");
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
                    Console.WriteLine("enter the Minuend");
                    string readNumberOrResult = Console.ReadLine();

                    if (double.TryParse(readNumberOrResult, out double Minuend))
                    {
                        subModel.Minuend = Minuend;

                        Console.WriteLine("enter the Subtrahend");
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
                    Console.WriteLine("enter the Dividend");
                    string readNumberOrResult = Console.ReadLine();

                    if (double.TryParse(readNumberOrResult, out double Minuend))
                    {
                        subModel.Dividend = Minuend;

                        Console.WriteLine("enter the Divisor");
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

            double GetNumberSqrt()
            {
                var subModel = new DivModel();
               
                while (true)
                {
                    Console.WriteLine("enter the number");
                    string readNumberOrResult = Console.ReadLine();

                    if (double.TryParse(readNumberOrResult, out double numberSqrt))
                    {
                        return numberSqrt;

                    }
                    else
                        Console.WriteLine("Invalid Value");

                }
            }

            void GetTrackingId()
            {
                    Console.WriteLine("Enter the TrackingId");
                    string trackingId = Console.ReadLine();

                    calculatorServer.TrackingID = trackingId;
            }


            #endregion                 


            Console.WriteLine("WELCOME TO CALCULATOR APP");

            while (statusApp.ToLower() != "exit")
            {
                Console.WriteLine("choose on opetation (ADD, SUB, MULT, DIV, SQRT) use \"exit\" to finish ");

                string readMethod = Console.ReadLine();

                if (Enum.TryParse<OperationType>(readMethod, out OperationType ExtractMethod))
                {
                    calculatorMethod = ExtractMethod;
                }

                switch (calculatorMethod)
                {
                    case OperationType.ADD:

                        GetTrackingId();

                        List<double> listNumbers = GetListOfNumbers();

                        PrintResult(calculatorServer.Add(listNumbers).Result);

                        break;
                    case OperationType.SUB:

                        GetTrackingId();

                        SubModel subModel = GetNumbersSub();

                        PrintResult(calculatorServer.Sub(subModel).Result);

                        break;
                    case OperationType.MULT:

                        GetTrackingId();

                        List<double> listNumbersMULT = GetListOfNumbers();

                        PrintResult(calculatorServer.Mult(listNumbersMULT).Result);

                        break;
                    case OperationType.DIV:

                        GetTrackingId();

                        DivModel divModel = GetNumbersDiv();

                        PrintResult(calculatorServer.Div(divModel).Result);

                        break;
                    case OperationType.SQRT:

                        GetTrackingId();

                        var numbersqr = GetNumberSqrt();

                        PrintResult(calculatorServer.Sqrt(numbersqr).Result);

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
