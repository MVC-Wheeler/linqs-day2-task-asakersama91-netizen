using System.ComponentModel.DataAnnotations;
using cantenmyself.Models;
using cantenmyself.Vm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace cantenmyself.repo.implemntation
{
    public class Staffrepo : IStaff
    {
        public ApppDbContextt _context;
        public Staffrepo (ApppDbContextt context)
        {
            _context = context;
        }
        public List<Staff> GetAll()
        {
             return _context.Staffs.Include(c=>c.User).ToList();
        }
        public Staff GetId(int id)
        {
            return _context.Staffs.Include(a => a.User).FirstOrDefault(f => f.StaffId == id);
        }

        public void Create(StaffVm staffVm)
        {
            var staff = new Staff()
            {

               


                StaffName = staffVm.StaffName,




                phone = staffVm.phone,



                Status = staffVm.Status,
                UserId = staffVm.UserId,


            };
            _context.Staffs.Add(staff);
            _context.SaveChanges();

        }

       
    }
}
