using ApiPetShop.Interface;
using ApiPetShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Service_CartController : ControllerBase
    {
        private readonly IService_CartRepository _bookRepo;
        private readonly IUserRepository _acRepo;
        private readonly IServiceRepository _serviceRepository;

        public Service_CartController(IService_CartRepository bookRepo,  
            IUserRepository acRepo, IServiceRepository serviceRepository)
        {
            _bookRepo = bookRepo;
            _acRepo = acRepo;
            _serviceRepository = serviceRepository;
        }

        [HttpGet]
        [Route("GetAllService_Cart")]
        public async Task<IActionResult> GetAllService_Cart()
        {
            try
            {
                var data = await _bookRepo.GetAllService_Cart();

                return Ok(data);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{IdUser}")]
        public async Task<IActionResult> GetService_CartById(string IdUser)
        {
            var Service_Cart = await _bookRepo.GetService_CartlByIdUser(IdUser);
            return Service_Cart == null ? NotFound() : Ok(Service_Cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewService_Cart(Service_CartModel Service_CartModel)
        {
            try
            {
                var newService_Cart = await _bookRepo.AddService_Cart(Service_CartModel);
                var service = await _serviceRepository.GetServiceAsync(Service_CartModel.IdServie);
                var user = await _acRepo.GetUserById(Service_CartModel.IdUser);
                
                

                return newService_Cart == null ? NotFound() : Ok(newService_Cart);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("/api/ApplicationUser/{IdUser}/Services/{idService}")]
        public async Task<IActionResult> UpdateService_Cart([FromRoute] string IdUser, [FromRoute] int idService,
            [FromBody] Service_CartModel Service_CartModel)
        {
            try
            {
                await _bookRepo.UpdateService_Cart(IdUser, idService, Service_CartModel);
                return Ok(true);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{IdUser}")]
        public async Task<IActionResult> DeleteService_Cart([FromRoute] string IdUser)
        {
            try
            {
                await _bookRepo.DeleteService_Cart(IdUser);
                return Ok(true);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}