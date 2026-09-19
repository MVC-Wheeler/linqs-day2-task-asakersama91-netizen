using System.ComponentModel.DataAnnotations;
using cantenmyself.Models;
using cantenmyself.Vm;
using Microsoft.EntityFrameworkCore;

namespace cantenmyself.repo.implemntation
{
    public class Orderrepo : IOrder
    {
        public ApppDbContextt _context;
        public Orderrepo(ApppDbContextt context)
        {
            _context = context;
        }
        public List<Order> GetAll()
        {
            return _context.Orders.Include(f=>f.User).Include(u=>u.FoodItem).Include(a=>a.Staff).ToList();
        }
        public Order GetById(int id)
        {
            return _context.Orders.Include(f => f.User).Include(u => u.FoodItem).Include(a => a.Staff).FirstOrDefault(c=>c.OrderId==id);
        }
        public void create(OrderVm orderVm)
        {
            var order = new Order()
            {
                OrderId = orderVm.OrderId,


                OrderDateTime = DateTime.Now,


                Status = orderVm.Status,

                StaffId = orderVm.StaffId,
                FoodItemId = orderVm.FoodItemId,

                UserId = orderVm.UserId

            };

            var staff = orderVm.Staff.Find(c => c.StaffId == orderVm.StaffId);

            if (staff != null)
            {
                staff.Status = "Busy";
            }
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

      

       
    }
}
