using ApiPetShop.Interface;
using ApiPetShop.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _AcRepo;

        public AccountController(IUserRepository repo)
        {
            _AcRepo = repo;
        }
        [HttpPost]
        [Route("seed-roles")]
        public async Task<IActionResult> SeedRoles()
        {
            try
            {
                var seerRoles = await _AcRepo.SeedRolesAsync();

                return Ok(seerRoles);
            }
            catch
            {
                return BadRequest();
                 
            }
           
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] SignUpModel registerDto)
        {
            try
            {
                var registerResult = await _AcRepo.SigUpAsync(registerDto);

                if (registerResult.IsSucceed)
                    return Ok(registerResult);
                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }

            
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] SignInModel loginDto)
        {
            try
            {
                var loginResult = await _AcRepo.SigInAsync(loginDto);

                if (loginResult.IsSucceed)
                    return Ok(loginResult);

                return Unauthorized(loginResult);
            }
            catch 
            {

                return BadRequest();
            }
          
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            try
            {
                return Ok(await _AcRepo.GetAllUser());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetUseByEmail/{email}")]
        public async Task<IActionResult> GetUserByEmail( string email)
        {
            try
            {
                var user = await _AcRepo.GetUserByEmail(email);
                return user == null ? NotFound() : Ok(user);
            }
            catch (Exception)
            {

                return BadRequest();
            }
            
        }
        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById( string id)
        {
            try
            {
                var user = await _AcRepo.GetUserById(id);
                return user == null ? NotFound() : Ok(user);
            }
            catch 
            {

                return BadRequest();
            }
          
        }
        [HttpPost]
        [Route("make-admin")]
        public async Task<IActionResult> MakeAdmin([FromBody] UpdatePermissionModel updatePermissionDto)
        {
            var operationResult = await _AcRepo.MakeAdminAsync(updatePermissionDto);

            if (operationResult.IsSucceed)
                return Ok(operationResult);

            return BadRequest(operationResult);
        }

    }
}
