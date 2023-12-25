 
namespace SalesManagementSystem.Models
{
    public class SalesRecord
    {
        public int AccountNo { get; set; }
        public string AccountCustomer { get; set; }
        public string Territory { get; set; }
        public string ProductDisplayCode { get; set; }
        public string ProductGroup { get; set; }
        public int Quantity { get; set; }
        public decimal LineValue { get; set; }
        public string SalesPerson { get; set; }
    }
}
