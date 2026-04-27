using can.Models;
using can.repo.Interface;

namespace can.repo.impelemtation
{
    public class Userrepo : IUser
    {
        private readonly AppDbContextt _context;
        public Userrepo (AppDbContextt context)
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
           var x= _context.Users.Find(id);
            if (x!= null)
            {
                _context.Remove(x); 
                _context.SaveChanges() ;
            }
        }

        public void Update(User user)
        {
           _context.Update(user);
            _context.SaveChanges();
        }

        public List<User> Search(string? name)
        {
            var query = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query= query.Where(c=>c.UserName.Contains(name));   
            }
            return query.ToList();  
        }
    }
}
