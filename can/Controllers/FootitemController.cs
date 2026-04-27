using can.Models;
using System.ComponentModel.DataAnnotations;
using can.repo.Interface;
using can.VM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace can.Controllers
{
    public class FootitemController : Controller
    {
        private readonly Ifootitem _foootrepo;
        public readonly IUser _userrepo;

        public FootitemController(Ifootitem foootrepo, IUser userrepo)
        {
            _foootrepo = foootrepo;
            _userrepo = userrepo;
        }
        public ActionResult Index()
        {
            var x = _foootrepo.GetAll();
            return View(x);
        }
        // GET: FootitemController/Details/5
        public ActionResult Details(int id)
        {
            var x=_foootrepo.GetById(id);
            return View(x);
        }
        // GET: FootitemController/Create
        public ActionResult Create()
        {
            var footitem = new fooditemVm()
            {
                User=_userrepo.GetAll().Where(c=>c.Role== "Admin").ToList(),
            };
            return View(footitem);
        }
        // POST: FootitemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(fooditemVm fooditemVm)
        {
            if (fooditemVm.Price <= 0)
            {
                ModelState.AddModelError("Price", "Must be greater than 0");
            }
            if (ModelState.IsValid)
            {
                _foootrepo.Create(fooditemVm);
                return RedirectToAction(nameof(Index));
            }
              return View(fooditemVm);  
        }
        // GET: FootitemController/Edit/5
        public ActionResult Edit(int id)
        {
            var x = _foootrepo.GetById(id);
            if (x== null)
            {
                return NotFound();
            }
            var footitem = new fooditemVm()
            {
                FoodItemId = x.FoodItemId,
                FoodName = x.FoodName,
                Price = x.Price,
                Category = x.Category,
                UserId = x.UserId,
                User = _userrepo.GetAll(),
            };
            return View(footitem);
        }
        // POST: FootitemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,fooditemVm fooditemVm)
        {
            if (fooditemVm.Price < 0)
            {
                ModelState.AddModelError("Price", "Must be greater than 0");
            }
            if (ModelState.IsValid)
            {
                _foootrepo.Update(fooditemVm);
                return RedirectToAction(nameof(Index));
            }
            return View(fooditemVm);
        }
        // GET: FootitemController/Delete/5
        public ActionResult Delete(int id)
        {
            var x = _foootrepo.GetById(id);
            if (x == null)
            {
                return NotFound();
            }
            var footitem = new fooditemVm()
            {
                FoodItemId = x.FoodItemId,
                FoodName = x.FoodName,
                Price = x.Price,
                Category = x.Category,
                UserId = x.UserId,
            };
            return View(footitem);
        }

        // POST: FootitemController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
             _userrepo.Delete(id);
                return RedirectToAction(nameof(Index));
            
        }
    }
}
