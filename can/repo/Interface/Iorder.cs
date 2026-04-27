using can.Models;
using can.VM;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace can.repo.Interface
{
    public interface Iorder
    {
        public List<Order> GetAll();
        public Order GitId (int id);

        public void Create (OrderVm orderVm); 
        public void Update (OrderVm orderVm);
        public List<Order> Search(string ? OrderId);

        public void Delete(int id);


    }
}
