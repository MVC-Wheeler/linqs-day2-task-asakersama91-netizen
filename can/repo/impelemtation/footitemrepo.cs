using can.Models;
using can.repo.Interface;
using can.VM;
using Microsoft.EntityFrameworkCore;

namespace can.repo.impelemtation
{
    public class footitemrepo:Ifootitem
    {
        private readonly AppDbContextt _context;
        public footitemrepo(AppDbContextt context)
        {
            _context = context;
        }
        public List<Fooditem> GetAll()
        {
           return _context.Fooditems.Include(c=>c.User).ToList();
        }
        public Fooditem GetById(int id)
        {
            return _context.Fooditems.Include(c => c.User).FirstOrDefault(c=>c.FoodItemId==id);
        }

        public void Create(fooditemVm fooditemVm)
        {
            var fooditem = new Fooditem()
            {
                FoodItemId = fooditemVm.FoodItemId,

                FoodName = fooditemVm.FoodName,



                Price = fooditemVm.Price,


                Category = fooditemVm.Category,

                UserId = fooditemVm.UserId,
            };
            _context.Fooditems.Add(fooditem);
            _context.SaveChanges();
            
        }
        public void Update(fooditemVm fooditemVm)
        {
            var x = _context.Fooditems.Find(fooditemVm.FoodItemId);
            if (x != null)
            {

             

                x.FoodName = fooditemVm.FoodName;

                x.Price = fooditemVm.Price;

                x.Category = fooditemVm.Category;

               x. UserId = fooditemVm.UserId;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var x = _context.Fooditems.Find(id);
            if (x != null)
            {
                _context.Remove(x);
                _context.SaveChanges(); 
            }
        }

      
    }
}
