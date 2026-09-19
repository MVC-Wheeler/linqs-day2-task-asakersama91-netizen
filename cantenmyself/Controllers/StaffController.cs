using cantenmyself.repo;
using cantenmyself.Vm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cantenmyself.Controllers
{
    public class StaffController : Controller
    {
        private readonly IUser _userrepo;
        private readonly IStaff _staffrepo;

        public StaffController (IUser userrepo, IStaff staffrepo)
        {
            _userrepo = userrepo;
            _staffrepo = staffrepo;
        }


        // GET: StaffController
        public ActionResult Index()
        {
            var x=_staffrepo.GetAll();  
            return View(x);
        }

        // GET: StaffController/Details/5
        public ActionResult Details(int id)
        {
            var x=_staffrepo.GetId(id);
            return View(x);
        }

        // GET: StaffController/Create
        public ActionResult Create()
        {
            var t = new StaffVm()
            {
                User=_userrepo.GetAll().Where(j=>j.Role=="Admin").ToList(),
            };
            return View(t);
        }

        // POST: StaffController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StaffVm staffVm)
        {
            if(ModelState.IsValid)
            {
                _staffrepo.Create(staffVm);
                return RedirectToAction(nameof(Index));
            }
            return View(staffVm);

        
        }

        // GET: StaffController/Edit/5
     
    }
}
