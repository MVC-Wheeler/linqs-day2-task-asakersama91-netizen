using clincmyselff.Models;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace clincmyselff.viewModel
{
    public class _AappoumentVm
    {
        public Appointment Appointment { get; set; }

        public SelectList DoctorList { get; set; }  

        public SelectList PationtList { get; set; } 
         


    }
}
