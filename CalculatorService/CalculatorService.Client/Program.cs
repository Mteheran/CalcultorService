namespace CalculatorService.Client
{
    using CalculatorService.Client.Services;
    using CalculatorService.Client.Services.Contracts;
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {

            #region Local Functions

            void PrintResult(double resultValue) => Console.WriteLine($"The result is : {resultValue} ");
            
            List<double> GetNumbers()
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

            #endregion


            //init services
            ICalculatorServer calculatorServer = new CalculatorServer();

            string statusApp = string.Empty;
            string calculatorMethod = string.Empty;


            Console.WriteLine("WELCOME TO CALCULATOR APP");

            while (statusApp.ToLower() != "exit")
            {
                Console.WriteLine("choose on opetation (add, sub, sqt) use \"exit\" to finish ");

                string readMethod = Console.ReadLine();

                if (readMethod.Equals("add") || 
                    readMethod.Equals("sub") || 
                    readMethod.Equals("sqt"))
                {
                    calculatorMethod = readMethod;
                }
                             

                switch (calculatorMethod)
                {
                    case "add":
                        List<double> listNumbers = GetNumbers();

                        PrintResult(calculatorServer.Add(listNumbers).Result);

                        break;
                    case "sub":
                        break;
                    case "sqt":
                        break;
                }
            }

           

            Console.ReadLine();
        }
    }
}
