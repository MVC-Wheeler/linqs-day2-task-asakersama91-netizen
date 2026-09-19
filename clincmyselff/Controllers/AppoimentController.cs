using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using clincmyselff.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using clincmyselff.viewModel;
namespace clincmyselff.Controllers
{
    public class AppoimentController : Controller
    {
        private readonly AppDbContext _context;

        public AppoimentController(AppDbContext context)
        {
            _context = context;
        }
        // GET: AppoimentController
        public ActionResult Index()
        {
            var appoiment = _context.Appointments
                .Include(a=>a.Doctor)
                .Include(s=>s.Patient)
                .ToList(); 
            
               
            return View();
        }



        // GET: AppoimentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppoimentController/Create
        [HttpPost]
       
        public ActionResult Create(_AappoumentVm model)
        {
            if (ModelState.IsValid)
            {

                _context.Appointments.Add(model.Appointment);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            var viewmodel = new _AappoumentVm()
            {
                Appointment = new Appointment(),
                DoctorList = new SelectList(_context.Doctors, "DoctorId", "Name"),
                PationtList = new SelectList(_context.Patients, "PatientId", "Name")
            };
            return View(viewmodel);
        }
             

    }

    

  

  
    
}
