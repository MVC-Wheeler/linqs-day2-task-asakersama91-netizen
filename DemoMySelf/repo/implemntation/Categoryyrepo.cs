using DemoMySelf.Models;
using DemoMySelf.repo.Interface;

namespace DemoMySelf.repo.implemntation
{
    public class Categoryyrepo : Icategorycs
    {
        private readonly Apppdbcontext _context;

        public Categoryyrepo(Apppdbcontext context)
        {
            _context = context;
        }
        public List<Categorycs> GitAll()
        {
            return _context.categories.ToList();


        }

        public Categorycs GetId(int id)
        {
            return _context.categories.Find(id);
        }
        public void Create(Categorycs category)
        {
            _context.categories.Add(category);  
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var x= _context.categories.Find(id);
            _context.Remove(x);
            _context.SaveChanges();
        }

        public void Update(Categorycs category)
        {
            _context.categories.Update(category);
            _context.SaveChanges();
        }
    }
}
