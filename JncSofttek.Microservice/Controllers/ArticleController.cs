using AutoMapper;
using JncSofttek.Microservice.Common.Classes;
using JncSofttek.Microservice.Common;
using JncSofttek.Microservice.Repository.Repositories.Dtos.User;
using JncSofttek.Microservice.Repository.Repositories.Interfaces;
using JncSofttek.Microservice.Util.Helpers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JncSofttek.Microservice.Repository.Repositories.Dtos.Article;
using JncSofttek.Microservice.DataAccess.Models;

namespace JncSofttek.Microservice.Controllers
{
    [Authorize]
    [Route("api/articles")]
    [ApiController]
    public class ArticleController : MyBaseController
    {
        private readonly IHelperToken _token;

        public ArticleController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHelperToken token,
            ILogger<MyBaseController> logger) :
            base(unitOfWork, mapper, logger) => _token = token;

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var articles = await _unitOfWork.articleRepository.GetAllAsync();
                return Ok(new DefaultResponse<List<ArticleDto>>(
                    true, result: _mapper.Map<List<ArticleDto>>(articles))
                );
            }
            catch (Exception ex)
            {
                _logger.LogError($"{typeof(ArticleController)} | GetAllAsync() ::: {ex.Message}");
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new DefaultResponse<IActionResult>(true,
                    errorMessage: AppConsts.STATUS_CODE_500_INTERNAL_SERVER_ERROR));
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync(ArticleCreateInputDto input)
        {
            try
            {
                var article = _mapper.Map<Article>(input);
                article.Sku = Guid.NewGuid().ToString();

                await _unitOfWork.articleRepository.CreateAsync(article);
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
