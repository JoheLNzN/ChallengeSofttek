using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JncSofttek.Microservice.DataAccess.Models.ModelAttributes
{
    public static class UserConsts
    {
        public const string EmailAddressType = "VARCHAR(20)";
        public const string PasswordType = "NVARCHAR(10)";
        public const string RoleType = "TINYINT";
        public const string CreationTimeType = "DATETIME";
    }
}
