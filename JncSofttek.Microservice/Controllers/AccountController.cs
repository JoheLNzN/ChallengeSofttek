using JncSofttek.Microservice.Common.Classes;
using JncSofttek.Microservice.DataAccess.Models;
using JncSofttek.Microservice.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JncSofttek.Microservice.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class AccountController : MyBaseController
    {
        public AccountController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        [HttpGet]
        [AllowAnonymous]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            return Ok(new DefaultResponse<List<User>>(true, result: users));
        }
    }
}
