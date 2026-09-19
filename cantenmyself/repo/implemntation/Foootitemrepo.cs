using System.ComponentModel.DataAnnotations;
using cantenmyself.Models;
using cantenmyself.Vm;
using Microsoft.EntityFrameworkCore;

namespace cantenmyself.repo.implemntation
{
    public class Foootitemrepo : IFootitem
    {
        public ApppDbContextt _context;
        public Foootitemrepo(ApppDbContextt context)
        {
            _context = context;
        }
        public List<FoodItem> GetAll()
        {
           return _context.FoodItems.Include(c=>c.User).ToList();
        }
        public FoodItem GetId(int id)
        {
            return _context.FoodItems.Include(c => c.User).FirstOrDefault(c=>c.FoodItemId==id);
        }


        public void Create(footitemVm footitemVm)
        {
            var footitem = new FoodItem()
            {


                FoodName = footitemVm.FoodName,
                Price = footitemVm.Price,

                Category = footitemVm.Category,

                UserId = footitemVm.UserId,

            };
            _context.FoodItems.Add(footitem);
            _context.SaveChanges();
        }

     
       

        public List<FoodItem> Search(string? name)
        {
            var query = _context.FoodItems.AsQueryable();
            if (!string.IsNullOrEmpty(name) )
            {
                query= query.Where(c=>c.FoodName.Contains(name));
            }
            return query.ToList();
        }
    }
}
