using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using clincmyselff.Models;

namespace clincmyselff.Controllers
{
    public class DoctorController : Controller
    {

        private readonly AppDbContext _context;

        public DoctorController(AppDbContext context)
        {
            _context = context;
        }


        // GET: DoctorController
        public ActionResult Index()
        {
            var doctor= _context.Doctors.ToList();
            return View(doctor);
        }

     


        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorController/Create
        [HttpPost]
     
        public ActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
         return View(doctor);
        }

        // GET: DoctorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DoctorController/Edit/5
        [HttpPost ("{id}")]
     
        public ActionResult Edit(int id, Doctor doctor)
        {
           if (ModelState.IsValid)
            {
                var x = _context.Doctors.Find(id);
                if (x == null)
                {
                    return NotFound();
                }
               x.Name= doctor.Name;
               x.Specialty= doctor.Specialty;
                _context.Update(x); 
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
           return View(doctor);
        }

    }
}
