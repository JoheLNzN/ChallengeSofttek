using JncSofttek.Microservice.DataAccess.Models.TableAttributes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JncSofttek.Microservice.DataAccess.Models
{
    public class Article
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = ArticleConsts.SkuType)]
        public string Sku { get; set; }

        [Column(TypeName = ArticleConsts.NameType)]
        public string Name { get; set; }

        [Column(TypeName = ArticleConsts.PriceType)]
        public decimal Precio { get; set; }

        [Column(TypeName = ArticleConsts.StockType)]
        public int Stock { get; set; }

        [Column(TypeName = ArticleConsts.CreationTimeType)]
        public DateTime CreationTime { get; set; } = DateTime.Now;
    }
}
