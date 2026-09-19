using DemoMySelf.Models;

namespace DemoMySelf.repo.Interface
{
    public interface Icategorycs
    {
        List<Categorycs> GitAll();

        Categorycs GetId(int id);   

        void Create (Categorycs category);  
        void Update (Categorycs category);
        void Delete (int id);


    }
}
