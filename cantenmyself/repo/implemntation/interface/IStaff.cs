using cantenmyself.Models;
using cantenmyself.Vm;

namespace cantenmyself.repo
{
    
    
        public interface IStaff
        {
            public List<Staff> GetAll();

            public Staff GetId(int id);

            public void Create(StaffVm staffVm);
        }
    
}
