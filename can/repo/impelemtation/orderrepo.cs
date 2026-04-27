using can.Models;
using can.repo.Interface;
using can.VM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace can.repo.impelemtation
{
    public class orderrepo : Iorder
    {
        private readonly AppDbContextt _context;
        public orderrepo(AppDbContextt context)
        {
            _context = context;
        }
        public List<Order> GetAll()
        {
            return _context.orders.Include(c=>c.Staff).Include(c=>c.User).Include(c=>c.Fooditem).ToList();  
        }
        public Order GitId(int id)
        {
            return _context.orders.Include(c => c.Staff).Include(c => c.User).Include(c => c.Fooditem).FirstOrDefault(c=>c.OrderId==id);
        }
        public void Create(OrderVm orderVm)
        {
            var order = new Order()
            {
                OrderId = orderVm.OrderId,
                OrderDateTime = orderVm.OrderDateTime,
                TotalPrice = orderVm.TotalPrice,
                Status = orderVm.Status,
                StaffId = orderVm.StaffId,
                FoodItemId = orderVm.FoodItemId,
                UserId = orderVm.UserId,
            };
            _context.orders.Add(order);
            _context.SaveChanges();
        }
        public void Update(OrderVm orderVm)
        {
            var x = _context.orders.Find(orderVm.OrderId);
            if (x!= null)
            {
               x. OrderDateTime = orderVm.OrderDateTime;
                x.TotalPrice = orderVm.TotalPrice;
               x. Status = orderVm.Status;
               x. StaffId = orderVm.StaffId;
               x. FoodItemId = orderVm.FoodItemId;
               x. UserId = orderVm.UserId;
                _context.Update(x);
                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var x=_context.orders.Find(id);
            if (x != null)
            {
                _context.Remove(x);
                _context.SaveChanges();
            }
        }
        public List<Order> Search(string? OrderId)
        {
             var query=_context.orders.AsQueryable();
            if (!string.IsNullOrEmpty(OrderId))
            {
                query = query.Where(c => c.OrderId.ToString().Contains(OrderId));
            }
            return query.ToList();
        }
    }
}
