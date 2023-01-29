using JncSofttek.Microservice.Common.Enums;
using JncSofttek.Microservice.DataAccess.Models.ModelAttributes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JncSofttek.Microservice.Repository.Repositories.Dtos.User
{
    public class UserDto
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public UserRoleType Role { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
