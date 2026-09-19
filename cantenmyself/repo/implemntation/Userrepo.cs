using cantenmyself.Models;

namespace cantenmyself.repo.implemntation
{
    public class Userrepo : IUser
    {
        public ApppDbContextt _context;
        public Userrepo (ApppDbContextt context)
        {
            _context = context; 
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
        public User GetById(int id)
        {
           return _context.Users.Find(id);  
        }
        public void Create(User user)
        {
           _context.Users.Add(user);    
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var x=_context.Users.Find(id);
            if (x != null)
            {
                _context.Users.Remove(x);
                _context.SaveChanges();
            }
        }

        public List<User> Search(string? name)
        {
            var quer=_context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(name) )
            {
                quer= quer.Where(c=>c.UserName.Contains(name));
            }
            return quer.ToList();
        }

        public void Update(User user)
        {
           _context.Update(user);
            _context.SaveChanges();
        }
    }
}
