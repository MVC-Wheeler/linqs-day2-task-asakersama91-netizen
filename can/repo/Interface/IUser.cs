using can.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace can.repo.Interface
{
    public interface IUser
    {
        public List<User> GetAll();

        public User GetById(int id);

        public void  Create (User user);
        public void Update (User user);
        public void Delete (int id);

        public List<User> Search(string ?name);

    }
}
