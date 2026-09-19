using clincmyselff.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clincmyselff.Controllers
{
    public class PatientsController : Controller
    {
        private readonly AppDbContext _context;

        public PatientsController (AppDbContext context)
        {
            _context = context;
        }

        // GET: PatientsController
        public IActionResult Index()
        {
            var pationt= _context.Patients.ToList();

            return View(pationt);
        }

     

        // GET: PatientsController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientsController/Create
        [HttpPost]
  
        public ActionResult Create(Patient patient)
        {
          if(ModelState.IsValid)
            {
                _context.Patients.Add(patient);
                _context.SaveChanges(); 
                return RedirectToAction("Index");


            }
          return View(patient);
        }

     



  
    }
}
