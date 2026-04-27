using can.Models;
using can.repo.Interface;
using can.VM;
using Microsoft.EntityFrameworkCore;

namespace can.repo.impelemtation
{
    public class staffrepo : Istaff
    {
        private readonly AppDbContextt _context;
        public staffrepo(AppDbContextt context)
        {
            _context = context;
        }
        public List<Staff> GetAll()
        {
           return _context.staffs.Include(c=>c.User).ToList();
        }
        public Staff Getid(int id)
        {
            return _context.staffs.Include(c => c.User).FirstOrDefault(c => c.StaffId == id);
        }
     

        public void Delete(int id)
        {
          var x=_context.staffs.Find(id);
            if (x != null)
            {
                _context.staffs.Remove(x);
                _context.SaveChanges();
            }
        }

        public void Create(staffVm staffvm)
        {
            var staff = new Staff()
            {
                   StaffId = staffvm.StaffId,
                  StaffName = staffvm.StaffName,
                   JobTitle = staffvm.JobTitle,
                    phone= staffvm.phone,
                   Status = staffvm.Status,
                  UserId = staffvm.UserId,


            };
            _context.staffs.Add(staff);
            _context.SaveChanges();
        }

        public void Update( Staff staffVm)
        {
            var x = _context.staffs.Find(staffVm.StaffId);

            if (x!=null)
            {
              
                x.StaffName = staffVm.StaffName;
                x.JobTitle = staffVm.JobTitle;
                x.phone = staffVm.phone;
               x. Status = staffVm.Status;
               x. UserId =  staffVm.UserId;
                _context.SaveChanges();
            }
        }

        public List<Staff> Search(string? Name)
        {
            var query = _context.staffs.AsQueryable();

            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(c => c.StaffName.Contains(Name));
            }
            return query.ToList();

        }
    }
}
