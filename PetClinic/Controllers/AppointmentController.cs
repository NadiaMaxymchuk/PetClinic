
using BLL.Interfaces;
using BLL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PetClinic.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController: ControllerBase
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        
        [HttpGet]
        [Route("appointment/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = appointmentService.GetById(Id);
            return Ok(result);
        }

        [Authorize(Roles = "Moderator, Admin")]
        [HttpGet]
        [Route("appointments")]
        public async Task<IActionResult> GetAll()
        {
            var result = appointmentService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public void AddPet(AppointmentViewModel appointment)
        {
            appointmentService.AddAppointment(appointment);
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpDelete]
        [Route("delete")]
        public void DeletePet(int Id)
        {
            appointmentService.DeleteAppointment(Id);
        }

    }
}
