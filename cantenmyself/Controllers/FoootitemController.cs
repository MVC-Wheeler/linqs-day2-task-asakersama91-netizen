using cantenmyself.repo;
using cantenmyself.Vm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cantenmyself.Controllers
{
    public class FoootitemController : Controller
    {
        private readonly IUser _userrepo;
        private readonly IFootitem _footitmrepo;

        public FoootitemController(IUser userrepo, IFootitem footitmrepo)
        {
            _userrepo = userrepo;
            _footitmrepo = footitmrepo;
        }


        // GET: FoootitemController
        public ActionResult Index(string ?name)
        {
            var x = _footitmrepo.Search(name);
            return View(x);
        }

        // GET: FoootitemController/Details/5
        public ActionResult Details(int id)
        {
            var x = _footitmrepo.GetId(id);
            return View(x);
        }

        // GET: FoootitemController/Create
        public ActionResult Create()
        {
            var footitem = new footitemVm()
            {
                User = _userrepo.GetAll().Where(c => c.Role == "Admin").ToList(),
            };
            return View(footitem);
        }

        // POST: FoootitemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(footitemVm footitemVm)
        {
            if (footitemVm.Price <= 0)
            {
                ModelState.AddModelError("Price", "must be greater 0");
            }
            if (ModelState.IsValid)
            {
                _footitmrepo.Create(footitemVm);
                return RedirectToAction("Index");
            }
            return View(footitemVm);
            
        }


    }
}

