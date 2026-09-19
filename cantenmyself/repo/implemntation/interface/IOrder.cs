using cantenmyself.Models;
using cantenmyself.Vm;

namespace cantenmyself.repo
{
    public interface IOrder
    {
        public List<Order> GetAll();

        public Order GetById(int id);

        public void create (OrderVm  orderVm);
    }
}
