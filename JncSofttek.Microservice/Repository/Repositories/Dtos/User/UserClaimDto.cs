using JncSofttek.Microservice.Common.Enums;

namespace JncSofttek.Microservice.Repository.Repositories.Dtos.User
{
    public class UserClaimDto
    {
        public string EmailAddress { get; set; }
        public UserRoleType Role { get; set; }
    }
}
