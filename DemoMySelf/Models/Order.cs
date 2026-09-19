namespace DemoMySelf.Models
{
    public class Order
    {
        public int OrderId { get; set; }    
        public string Quantity { get; set; }      = string.Empty;   

        public DateTime OrderDate { get; set; } 

        public int MenuItemId { get; set; } 

        public MenuItem MenuItem { get; set; }

    }
}
