using JncSofttek.Microservice.Common;
using System.ComponentModel.DataAnnotations;

namespace JncSofttek.Microservice.Repository.Repositories.Dtos.Article
{
    public class ArticleCreateInputDto
    {
        [Required(ErrorMessage = AppConsts.VALIDATION_ERROR_REQUIRED)]
        [StringLength(40, ErrorMessage = AppConsts.VALIDATION_ERROR_INVALID_LENGTH)]
        public string Name { get; set; }

        [Required(ErrorMessage = AppConsts.VALIDATION_ERROR_REQUIRED)]
        [Range(1, (double)decimal.MaxValue, ErrorMessage = AppConsts.VALIDATION_ERROR_INVALID_RANGE_PRICE)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = AppConsts.VALIDATION_ERROR_REQUIRED)]
        [Range(1, 10, ErrorMessage = AppConsts.VALIDATION_ERROR_INVALID_RANGE_STOCK)]
        public int Stock { get; set; }
    }
}
