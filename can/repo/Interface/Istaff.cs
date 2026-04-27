using can.Models;
using can.VM;

namespace can.repo.Interface
{
    public interface Istaff
    {
        public List<Staff> GetAll();
        public List<Staff> Search(string ?Name);

        public Staff Getid(int  id);    

        public void Create(staffVm staffvm);
        public void Update(Staff Staff);
        public void Delete(int id);

    }
}
