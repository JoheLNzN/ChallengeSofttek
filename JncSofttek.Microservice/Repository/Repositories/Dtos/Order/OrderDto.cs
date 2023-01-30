using JncSofttek.Microservice.DataAccess.Models.TableAttributes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JncSofttek.Microservice.Repository.Repositories.Dtos.Order
{
    public class OrderDto
    {
        public string Key { get; set; }
        public long ArticleId { get; set; }
        public long UserId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
