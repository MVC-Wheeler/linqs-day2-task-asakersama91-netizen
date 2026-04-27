using can.Models;
using can.repo.Interface;
using can.VM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace can.Controllers
{
    public class staffController : Controller
    {
        public readonly Istaff _staffrepo;
        public readonly IUser _user;

        public staffController (Istaff repo, IUser user)
        {
            _staffrepo = repo;
            _user = user;
        }
        // GET: staffController
        public ActionResult Index()
        {
            var x=_staffrepo.GetAll();
            return View(x);
        }
        // GET: staffController/Details/5
        public ActionResult Details(int id)
        {
            var x= _staffrepo.Getid(id);
            return View(x);
        }
        // GET: staffController/Create
        public ActionResult Create()
        {
            var staff = new staffVm()
            {
                User = _user.GetAll().Where(c=>c.Role== "Admin").ToList(),    
            };
            return View(staff);
        }
        // POST: staffController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(staffVm staffVm)
        {
           if (ModelState.IsValid)
           {
                _staffrepo.Create(staffVm);
                return RedirectToAction(nameof(Index));

           }
            staffVm.User=_user.GetAll().Where(c=>c.Role== "Admin").ToList();
           return View(staffVm);
                
           
           
        }
        // GET: staffController/Edit/5
        public ActionResult Edit(int id)
        {
            var x = _staffrepo.Getid(id);
            var staff = new Staff()
            {
                StaffId = x.StaffId,
                StaffName = x.StaffName,
                JobTitle = x.JobTitle,
                phone = x.phone,
                Status = x.Status,
                UserId = x.UserId,
            };
            return View(staff);
        }
        // POST: staffController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Staff staff)
        {
                _staffrepo.Update(staff);
                return RedirectToAction(nameof(Index));
        }
        // GET: staffController/Delete/5
        public IActionResult Delete(int id)
        {
            _staffrepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        // POST: staffController/Delete/5
        public IActionResult Search(string? Name)
        {
           
            return View("Index", _staffrepo.Search(Name));
        }
    }
}
