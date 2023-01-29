using JncSofttek.Microservice.Common;
using System.ComponentModel.DataAnnotations;

namespace JncSofttek.Microservice.Repository.Repositories.Dtos.User
{
    public class AuthenticateInputDto
    {
        [Required(ErrorMessage = AppConsts.VALIDATION_ERROR_REQUIRED)]
        [StringLength(20, ErrorMessage = AppConsts.VALIDATION_ERROR_INVALID_LENGTH)]
        [EmailAddress(ErrorMessage = AppConsts.VALIDATION_ERROR_INVALID_EMAIL)]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = AppConsts.VALIDATION_ERROR_REQUIRED)]
        [StringLength(10, ErrorMessage = AppConsts.VALIDATION_ERROR_INVALID_LENGTH)]
        public string Password { get; set; }
    }
}
