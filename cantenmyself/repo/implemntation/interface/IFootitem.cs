using cantenmyself.Models;
using cantenmyself.Vm;

namespace cantenmyself.repo
{
    public interface IFootitem
    {
        public List<FoodItem> GetAll();

        public FoodItem GetId(int id);

        public void Create(footitemVm footitemVm);

        public List<FoodItem> Search(string ?name);

    }
}
