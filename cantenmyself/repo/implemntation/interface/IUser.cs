using cantenmyself.Models;

namespace cantenmyself.repo
{
    public interface IUser
    {
        public List<User> GetAll();
        public User GetById(int id);

        public void Create (User user);

        public void Update (User user);

        public void Delete (int id);

        public List<User> Search(string ?name);

    }
}
