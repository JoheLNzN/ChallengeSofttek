using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JncSofttek.Microservice.DataAccess.Models.TableAttributes
{
    public static class OrderConsts
    {
        public const string QuantityType = "INT";
        public const string AmountType = "DECIMAL(19,4)";
        public const string CreationTimeType = "DATETIME";
    }
}
