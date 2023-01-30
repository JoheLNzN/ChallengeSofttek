using JncSofttek.Microservice.DataAccess.Models.TableAttributes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JncSofttek.Microservice.Repository.Repositories.Dtos.Article
{
    public class ArticleDto
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
