using System.ComponentModel.DataAnnotations;
using can.Models;
using can.repo.Interface;
using can.VM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace can.Controllers
{
    public class OrderController : Controller
    {
        private readonly Iorder _orderrepo;
     private readonly IUser _userrepo;
        private readonly Istaff _staffrep;
        private readonly Ifootitem _footitemrepo;
        public OrderController (Iorder orderrepo, IUser userrepo, Istaff staffrep, Ifootitem footitemrepo)
        {
            _orderrepo = orderrepo;
            _userrepo = userrepo;
             _footitemrepo = footitemrepo;
            _staffrep = staffrep;
            _userrepo=userrepo;
        }
  // GET: OrderController
  public IActionResult Index(string ? OrderId)
        {
            var x = _orderrepo.GetAll();
            var query = _orderrepo.Search(OrderId);
            return View(query);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            var x=_orderrepo.GitId(id);
            return View(x);
        }
        // GET: OrderController/Create
        public ActionResult Create()
        {
            var order = new OrderVm()
            {
                User = _userrepo.GetAll().Where(c=>c.Role== "Customer").ToList(),
                Staff = _staffrep.GetAll().Where(c => c.Status == "Available").ToList(),
                Fooditem = _footitemrepo.GetAll().ToList    (),
                OrderDateTime = DateTime.Now,
            };
            return View(order);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderVm orderVm)
        {
            if (orderVm.TotalPrice < 0)
            {
                ModelState.AddModelError("TotalPrice", "Must be greater than 0");
            }
            if (ModelState.IsValid)
            {
                _orderrepo.Create(orderVm);
                var staaff = _staffrep.Getid(orderVm.StaffId);
                 if (staaff != null)
                 {
                    staaff.Status = "Busy";
                    _staffrep.Update(staaff);
                }
                   
                
                return RedirectToAction(nameof(Index));
            }

            orderVm.Staff=_staffrep.GetAll();
            orderVm.User=_userrepo.GetAll();
            orderVm.Fooditem=_footitemrepo.GetAll();
            return View(orderVm);
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            var x = _orderrepo.GitId(id);
            var order = new OrderVm()
            {
                OrderId = x.OrderId,
                OrderDateTime = x.OrderDateTime,

                TotalPrice = x.TotalPrice,

                Status = x.Status,
                StaffId = x.StaffId,
                FoodItemId = x.FoodItemId,
                UserId = x.UserId,
                User = _userrepo.GetAll(),
                Staff = _staffrep.GetAll(),
                Fooditem=_footitemrepo .GetAll(),
            };
            return View(order);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderVm orderVm)
        {
            if (orderVm.TotalPrice < 0)
            {
                ModelState.AddModelError("TotalPrice", "Must be greater than 0");
            }
                if (ModelState.IsValid)
                {
                 _orderrepo.Update(orderVm);
                if (orderVm.Status== "Completed" || orderVm.Status== "Cancelled")
                {
                    var staffVm=_staffrep.Getid(orderVm.StaffId);
                    if (staffVm != null)
                    {
                        staffVm.Status = "Available";
                        _staffrep.Update(staffVm);
                    }
                }
                 return RedirectToAction(nameof(Index));
                }
            orderVm.Staff = _staffrep.GetAll();
            orderVm.User = _userrepo.GetAll();
            orderVm.Fooditem = _footitemrepo.GetAll();
            return View(orderVm);
        }
        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            var x = _orderrepo.GitId(id);
            if (x == null)
            {
                return NotFound();
            }
            var order = new OrderVm()
            {
                OrderId = x.OrderId,
                OrderDateTime = x.OrderDateTime,
                TotalPrice = x.TotalPrice,
                Status = x.Status,
                StaffId = x.StaffId,
                FoodItemId = x.FoodItemId,
                UserId = x.UserId,
            };
            return View(order);
        }
        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
                 _orderrepo.Delete(id);
                return RedirectToAction(nameof(Index));
        }
    }
}
