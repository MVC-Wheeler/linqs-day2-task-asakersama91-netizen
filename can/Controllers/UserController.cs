using can.Models;
using can.repo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace can.Controllers
{
    public class UserController : Controller
    {
        public readonly IUser _userrepo;
        public UserController (IUser userrepo)
        {
            _userrepo = userrepo;
        }
        public ActionResult Index(string ?name)
        {
            var x = _userrepo.GetAll();
            return View(x);
        }
        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            var x= _userrepo.GetById(id);
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
            _userrepo.Create(user);
            return RedirectToAction(nameof(Index));
        }
        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var x=_userrepo.GetById(id);
            if (x==null)
            {
                return NotFound();
            }
           return View(id);
        }
        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            _userrepo.Update(user);
            return RedirectToAction(nameof(Index));
        }
        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _userrepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Search(string? name)
        {
            return View("Index", _userrepo.Search(name));
        }

    }
}
