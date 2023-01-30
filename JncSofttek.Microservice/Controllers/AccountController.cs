using AutoMapper;
using JncSofttek.Microservice.Common;
using JncSofttek.Microservice.Common.Classes;
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
            try
            {
                var users = await _unitOfWork.userRepository.GetAllAsync();
                return Ok(new DefaultResponse<List<UserDto>>(
                    true, result: _mapper.Map<List<UserDto>>(users))
                );
            }
            catch (Exception ex)
            {
                _logger.LogError($"{typeof(AccountController)} | GetAllAsync() ::: {ex.Message}");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new DefaultResponse<List<UserDto>>(true,
                    errorMessage: AppConsts.STATUS_CODE_500_INTERNAL_SERVER_ERROR));
            }
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateInputDto input)
        {
            try
            {
                var user = await _unitOfWork.userRepository.GetByEmailAddressAndPasswordAsync(
                    input.EmailAddress, input.Password
                );

                if (user == null) return BadRequest(new DefaultResponse<AuthenticateResponseDto>(
                    false, errorMessage: AppConsts.STATUS_CODE_400_BAD_REQUEST));

                var userDto = _mapper.Map<UserDto>(user);

                var token = _token.GenerateTokenJWTByUserInfo(_mapper.Map<UserDto>(userDto));

                if (string.IsNullOrEmpty(token)) throw new Exception(AppConsts.EXCEPTION_TOKEN_INVALID);

                return Ok(new DefaultResponse<AuthenticateResponseDto>(true,
                          new AuthenticateResponseDto()
                          {
                              Role = userDto.Role,
                              Token = token
                          }));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{typeof(AccountController)} | Authenticate() ::: {ex.Message}");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new DefaultResponse<AuthenticateResponseDto>(true,
                    errorMessage: AppConsts.STATUS_CODE_500_INTERNAL_SERVER_ERROR));
            }
        }
    }
}
