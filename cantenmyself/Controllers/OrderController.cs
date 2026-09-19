using cantenmyself.repo;
using cantenmyself.Vm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cantenmyself.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUser _userrepo;
        private readonly IFootitem _footitmrepo;
        private readonly IStaff _staffrepo;
        private readonly IOrder _orderrepo;

        public OrderController(IUser userrepo, IFootitem footitmrepo, IStaff staffrepo, IOrder orderrepo)
        {
            _userrepo = userrepo;
            _footitmrepo = footitmrepo;
            _staffrepo = staffrepo;
            _orderrepo = orderrepo;
        }

        public ActionResult Index()
        {
            var x=_orderrepo.GetAll();
            return View(x);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            var x=_orderrepo.GetById(id);
            return View(id);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            var ordervm = new OrderVm()
            {
                User = _userrepo.GetAll().Where(c => c.Role == "Customer").ToList(),
                Staff = _staffrepo.GetAll().Where(c => c.Status == "Available").ToList(),
                FoodItem=_footitmrepo.GetAll(),
            };
            return View(ordervm);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderVm orderVm)
        {
            if (ModelState.IsValid)
            {
                _orderrepo.create(orderVm);
                if (orderVm.Status== "Completed")
                {
                    var staff= orderVm.Staff.Find(c=>c.StaffId==orderVm.StaffId);

                    if (staff!=null)
                    {
                        staff.Status = "Available";
                    }
                }
                return RedirectToAction(nameof(Index));

            }
            return View(orderVm);

        }

     
    }
}
