namespace DemoMySelf.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; } 
        public string MenuItemName { get; set; } = string.Empty;

        public int Price { get; set; }  

        public int CategoryId { get; set; } 

        public Categorycs Category { get; set; }  
        
        List<Order> orders { get; set; }    






    }
}
