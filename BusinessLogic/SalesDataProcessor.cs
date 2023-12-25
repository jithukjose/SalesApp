using System.Data;
using System.Data.SqlClient;
using SalesManagementSystem.Constants;
using SalesManagementSystem.DataAccess;
using SalesManagementSystem.ErrorHandling;

namespace SalesManagementSystem.BusinessLogic
{
    public class SalesDataProcessor
    {
        public void RetrieveAndReplaceMissingData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStrings.SalesSysConnectionString))
                {
                    connection.Open();

                    DataTable filteredTable = SalesDataAccess.RetrieveData(connection);
                    ReplaceMissingData(filteredTable);
                    UpdateServer(connection, filteredTable);

                    Console.WriteLine(ConnectionStrings.Successfully);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleError(ex);
            }
        }

        private void ReplaceMissingData(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                if (string.IsNullOrEmpty(row["Territory"].ToString()))
                {
                    // Update only the "Territory" column
                    row.SetField("Territory", row["SalesPerson"]);
                }
            }
        }


        private void UpdateServer(SqlConnection connection, DataTable dataTable)
        {
            try
            {

                foreach (DataRow row in dataTable.Rows)
                {

                    using (SqlCommand command = new SqlCommand("UPDATE SalesRecords SET Territory = @Territory WHERE AccountNo = @AccountNo", connection))
                    {
                        // Assuming 'AccountNo' is the primary key column
                        command.Parameters.AddWithValue("@Territory", row["Territory"]);
                        command.Parameters.AddWithValue("@AccountNo", row["AccountNo"]);

                        command.ExecuteNonQuery();
                    }

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
