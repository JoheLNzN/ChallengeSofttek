using JncSofttek.Microservice.Common;
using System.ComponentModel.DataAnnotations;

namespace JncSofttek.Microservice.Repository.Repositories.Dtos.Order
{
    public class OrderCreateInputDto
    {
        [Required(ErrorMessage = AppConsts.VALIDATION_ERROR_REQUIRED)]
        public string ArticleSku { get; set; }

        [Required(ErrorMessage = AppConsts.VALIDATION_ERROR_REQUIRED)]
        public int Quantity { get; set; }
    }
}
