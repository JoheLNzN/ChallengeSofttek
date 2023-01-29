using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JncSofttek.Microservice.DataAccess.Models.TableAttributes
{
    public static class ArticleConsts
    {
        public const string SkuType = "VARCHAR(100)";
        public const string NameType = "VARCHAR(50)";
        public const string PriceType = "DECIMAL(19,4)";
        public const string StockType = "INT";
        public const string CreationTimeType = "DATETIME";
    }
}
