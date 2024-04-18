using ApiPetShop.Interface;
using ApiPetShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillRepository _bookRepo;

        public BillController(IBillRepository repository)
        {
            _bookRepo = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBill()
        {
            try
            {
                return Ok(await _bookRepo.GetAllBillAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBillById(int id)
        {
            var Bill = await _bookRepo.GetBillAsync(id);
            return Bill == null ? NotFound() : Ok(Bill);
        }
        [HttpGet("GetByPrice/{price}")]
        public async Task<IActionResult> GetBillByEmail(double price)
        {
            var Bill = await _bookRepo.GetBillAsyncByEmail(price);
            return Bill == null ? NotFound() : Ok(Bill);
        }
        [HttpGet("GetListBill/{IdUser}")]
        public async Task<IActionResult> GetBillByEmail(string IdUser)
        {
            var Bill = await _bookRepo.GetAllBillById(IdUser);
            return Bill == null ? NotFound() : Ok(Bill);
        }
        [HttpPost]
         

        public async Task<IActionResult> AddNewBill(BillModel BillModel)
        {
            try
            {
                var newBookId = await _bookRepo.AddBillAsync(BillModel);
                var Bill = await _bookRepo.GetBillAsync(newBookId);
                return Bill == null ? NotFound() : Ok(Bill);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("{id}")]
         

        public async Task<IActionResult> UpdateBill([FromRoute] int id, [FromBody] BillModel BillModel)
        {
            try
            {
                await _bookRepo.UpdateBillAsync(id, BillModel);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpDelete("{id}")]
         

        public async Task<IActionResult> DeleteBill([FromRoute] int id)
        {
            try
            {
                await _bookRepo.DeleteBillAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
