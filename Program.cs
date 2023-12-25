using SalesManagementSystem.BusinessLogic;
using SalesManagementSystem.Constants;
using SalesManagementSystem.ErrorHandling;
using System;

namespace SalesManagementSystem
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine(ConnectionStrings.SelectOption);
                Console.WriteLine(ConnectionStrings.FirstOption);
                Console.WriteLine(ConnectionStrings.SecondOption);
                // Add more options as needed

                // Get user input
                string userInput = Console.ReadLine();

                // Process user input
                switch (userInput)
                {
                    case "1":
                        SalesDataProcessor dataProcessor = new SalesDataProcessor();
                        dataProcessor.RetrieveAndReplaceMissingData();
                        break;
                    case "2":
                        Console.WriteLine(ConnectionStrings.NoOtherOption);
                        break;
                    default:
                        Console.WriteLine(ConnectionStrings.InvalidMessage);
                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
        }
    }
}
