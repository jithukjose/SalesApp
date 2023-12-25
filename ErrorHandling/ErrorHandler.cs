
namespace SalesManagementSystem.ErrorHandling
{
    public static class ErrorHandler
    {
        public static void HandleError(Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
