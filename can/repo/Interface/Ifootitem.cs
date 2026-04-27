using can.Models;
using can.VM;

namespace can.repo.Interface
{
    public interface Ifootitem
    {
        public List<Fooditem> GetAll();

        public Fooditem GetById(int id);

        public void Create (fooditemVm fooditemVm);

        public void Update (fooditemVm fooditemVm);

        public void Delete(int id);


    }
}
