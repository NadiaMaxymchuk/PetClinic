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
    public class PetController: ControllerBase
    {
        private readonly IPetService petService;
        public PetController(IPetService petService)
        {
            this.petService = petService;
        }
        [Authorize]
        [HttpPost]
        [Route("create")]
        public void AddPet(PetViewModel pet)
        {
            petService.AddPet(pet);
        }

        [HttpGet]
        [Route("pet/{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {

            var result = petService.GetById(Id);
            return Ok(result);
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpDelete]
        [Route("delete")]
        public void DeletePet(int Id)
        {
            petService.DeletePet(Id);
        }

    }
}
