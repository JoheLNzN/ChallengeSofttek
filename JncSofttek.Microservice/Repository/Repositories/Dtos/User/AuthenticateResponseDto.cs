using JncSofttek.Microservice.Common.Enums;

namespace JncSofttek.Microservice.Repository.Repositories.Dtos.User
{
    public class AuthenticateResponseDto
    {
        public string Token { get; set; }
        public UserRoleType Role { get; set; }
    }
}
