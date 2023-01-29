using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using JncSofttek.Microservice.DataAccess.Models.ModelAttributes;
using JncSofttek.Microservice.Common.Enums;

namespace JncSofttek.Microservice.DataAccess.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = UserConsts.EmailAddressType)]
        public string EmailAddress { get; set; }

        [Column(TypeName = UserConsts.PasswordType)]
        public string Password { get; set; }

        [Column(TypeName = UserConsts.RoleType)]
        public UserRoleType Role { get; set; }

        [Column(TypeName = UserConsts.CreationTimeType)]
        public DateTime CreationTime { get; set; }
    }
}
