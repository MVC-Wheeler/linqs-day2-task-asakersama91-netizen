using DemoMySelf.Models;
using DemoMySelf.repo.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoMySelf.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Icategorycs _Categoryyrepo;

        public CategoryController (Icategorycs categoryyrepo)
        {
            _Categoryyrepo = categoryyrepo;
        }
        public ActionResult Index()
        {
            var x = _Categoryyrepo.GitAll();
            return View(x);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var x= _Categoryyrepo.GetId(id);
            return View(x);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categorycs categorycs)
        {
            _Categoryyrepo.Create(categorycs);
           return RedirectToAction ("Index");   

        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Categorycs categorycs)
        {
            _Categoryyrepo.Update(categorycs);
            return RedirectToAction("Index");


        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Categorycs categorycs)
        {
            var x = _Categoryyrepo.GetId(id);
            return View(x);
        }
    }
}
