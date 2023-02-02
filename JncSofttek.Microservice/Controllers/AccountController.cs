using AutoMapper;
using JncSofttek.Microservice.Common;
using JncSofttek.Microservice.Common.Classes;
using JncSofttek.Microservice.Common.Enums;
using JncSofttek.Microservice.DataAccess.Models;
using JncSofttek.Microservice.Repository.Repositories.Dtos.User;
using JncSofttek.Microservice.Repository.Repositories.Interfaces;
using JncSofttek.Microservice.Util.Helpers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JncSofttek.Microservice.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class AccountController : MyBaseController
    {
        private readonly IHelperToken _token;
        public AccountController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHelperToken token,
            ILogger<MyBaseController> logger) :
            base(unitOfWork, mapper, logger) => _token = token;

        [HttpGet]
        [AllowAnonymous]
        [Route("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            //try
            //{
            var users = await _unitOfWork.userRepository.GetAllAsync();
            return Ok(new DefaultResponse<List<UserDto>>(
                true, result: _mapper.Map<List<UserDto>>(users))
            );
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateInputDto input)
        {
            var user = await _unitOfWork.userRepository.GetByEmailAddressAndPasswordAsync(
                input.EmailAddress, input.Password
            );

            if (user == null) return BadRequest(new DefaultResponse<AuthenticateResponseDto>(
                false, errorMessage: AppConsts.STATUS_CODE_400_BAD_REQUEST_INCORRECT_CREDENTIALS));

            var userDto = _mapper.Map<UserDto>(user);

            var token = _token.GenerateTokenJWTByUserInfo(userDto);

            return Ok(new DefaultResponse<AuthenticateResponseDto>(true,
                      new AuthenticateResponseDto()
                      {
                          Role = userDto.Role,
                          Token = token,
                          RedirectTo = userDto.Role == UserRoleType.DEFAULT ? "catalog/index" : "dashboard/index"
                      }));
        }
    }
}
