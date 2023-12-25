using System.Data;
using System.Data.SqlClient;
using SalesManagementSystem.Constants;
using SalesManagementSystem.ErrorHandling;

namespace SalesManagementSystem.DataAccess
{
    public static class SalesDataAccess
    {
        public static DataTable RetrieveData(SqlConnection connection)
        {
            try
            {
                //SQL query to select all columns from the SalesRecords table
                string query = $"SELECT * FROM {ConnectionStrings.SalesRecords} where Territory = ''";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
                throw; // Re-throw the exception after handling
            }
        }

    }
}
