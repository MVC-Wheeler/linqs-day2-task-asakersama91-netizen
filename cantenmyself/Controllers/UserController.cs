using cantenmyself.Models;
using cantenmyself.repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cantenmyself.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _userepo;
        public UserController(IUser userepo)
        {
            _userepo = userepo;
        }

        // GET: UserController
        public ActionResult Index(string?name)
        {
            var x = _userepo.Search(name);
            return View(x);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            var x=_userepo.GetById(id); 
            return View(x);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
           _userepo.Create(user);
            return RedirectToAction(nameof(Index));
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var x = _userepo.GetById(id);
            if (x== null)
            {
                return NotFound();
            }
            return View(x);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,User user)
        {
            _userepo.Update(user);
            return RedirectToAction(nameof(Index));
         
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var x=_userepo.GetById(id);
            return View(x);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,User user)
        {
            _userepo.Delete(id);
            return RedirectToAction(nameof(Index));
          
        }
        
    }
}
