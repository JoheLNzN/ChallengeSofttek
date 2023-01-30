using AutoMapper;
using JncSofttek.Microservice.Common;
using JncSofttek.Microservice.Common.Classes;
using JncSofttek.Microservice.DataAccess.Models;
using JncSofttek.Microservice.Repository.Repositories.Dtos.Order;
using JncSofttek.Microservice.Repository.Repositories.Interfaces;
using JncSofttek.Microservice.Util.Helpers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JncSofttek.Microservice.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : MyBaseController
    {
        private readonly IHelperToken _token;

        public OrderController(
           IUnitOfWork unitOfWork,
           IMapper mapper,
           IHelperToken token,
           ILogger<MyBaseController> logger) :
           base(unitOfWork, mapper, logger) => _token = token;

        /// <summary>
        /// Muestra las órdenes realizadas, no requiere autenticación (Sólo para visualización)
        /// </summary>
        /// <returns>Status Code &/Or List<Order></returns>
        [HttpGet]
        [Route("getAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var orders = await _unitOfWork.orderRepository.GetAllAsync();
                return Ok(new DefaultResponse<List<OrderDto>>(
                    true, result: _mapper.Map<List<OrderDto>>(orders))
                );
            }
            catch (Exception ex)
            {
                _logger.LogError($"{typeof(OrderController)} | GetAllAsync() ::: {ex.Message}");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new DefaultResponse<IActionResult>(true,
                    errorMessage: AppConsts.STATUS_CODE_500_INTERNAL_SERVER_ERROR));
            }
        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<IActionResult> CreateAsync(OrderCreateInputDto input)
        {
            try
            {
                var userClaim = _token.ValidateAndGetDataFromToken(Request);

                if (userClaim == null)
                    return NotFound(new DefaultResponse<IActionResult>(
                        false, errorMessage: AppConsts.STATUS_CODE_404_NOT_FOUND_USER_TOKEN));

                var user = _unitOfWork.userRepository.GetByEmailAddress(userClaim.EmailAddress);

                if (user == null)
                    return NotFound(new DefaultResponse<IActionResult>(
                        false, errorMessage: AppConsts.STATUS_CODE_404_NOT_FOUND_USER));

                var article = await _unitOfWork.articleRepository.GetBySkuAsync(input.ArticleSku);

                if (article == null)
                    return NotFound(new DefaultResponse<IActionResult>(
                        false, errorMessage: AppConsts.STATUS_CODE_404_NOT_FOUND_ARTICLE));

                if (input.Quantity == 0 || input.Quantity > article.Stock)
                    return BadRequest(new DefaultResponse<IActionResult>(
                        false, errorMessage: AppConsts.STATUS_CODE_400_BAD_REQUEST_ARTICLE_QUANTITY));


                // _unitOfWork.InitTransaction();

                decimal totalAmount = article.Price * input.Quantity;

                await _unitOfWork.orderRepository.CreateAsync(new Order()
                {
                    ArticleId = article.Id,
                    UserId = user.Id,
                    Amount = totalAmount,
                    Key = Guid.NewGuid().ToString(),
                    Quantity = input.Quantity,
                });

                article.Stock -= input.Quantity;

                await _unitOfWork.articleRepository.UpdateAsync(article);
                await _unitOfWork.SaveChangesAsync();

                //await _unitOfWork.SaveChangesAndCommitTransactionAsync();

                return Ok(new DefaultResponse<IActionResult>(true));
            }
            catch (Exception ex)
            {
                _logger.LogError($"{typeof(ArticleController)} | CreateAsync() ::: {ex.Message}");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new DefaultResponse<IActionResult>(true,
                    errorMessage: AppConsts.STATUS_CODE_500_INTERNAL_SERVER_ERROR));
            }
        }
    }
}
