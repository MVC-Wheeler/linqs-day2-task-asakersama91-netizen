using can.Models;
using System.ComponentModel.DataAnnotations;

namespace can.VM
{
    public class fooditemVm
    {
        
        public int FoodItemId { get; set; }
       
        public string FoodName { get; set; }

        public int Price { get; set; }

      
        public string Category { get; set; }

        public int UserId { get; set; }
        public List<User> User { get; set; }=new List<User>();
    }
}
