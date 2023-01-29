using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using JncSofttek.Microservice.DataAccess.Models.ModelAttributes;
using JncSofttek.Microservice.DataAccess.Models.TableAttributes;

namespace JncSofttek.Microservice.DataAccess.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column(TypeName = OrderConsts.KeyType)]
        public string Key { get; set; }

        public long ArticleId { get; set; }

        public long UserId { get; set; }

        [Column(TypeName = OrderConsts.QuantityType)]
        public int Quantity { get; set; }

        [Column(TypeName = OrderConsts.AmountType)]
        public decimal Amount { get; set; }

        [Column(TypeName = OrderConsts.CreationTimeType)]
        public DateTime CreationTime { get; set; }
    }
}
