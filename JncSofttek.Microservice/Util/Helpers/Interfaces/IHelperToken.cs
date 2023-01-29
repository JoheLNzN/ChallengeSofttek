using JncSofttek.Microservice.Repository.Repositories.Dtos.User;

namespace JncSofttek.Microservice.Util.Helpers.Interfaces
{
    public interface IHelperToken
    {
        string GenerateTokenJWTByUserInfo(UserDto user);
    }
}
