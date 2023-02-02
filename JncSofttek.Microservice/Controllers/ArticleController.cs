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
using System.Collections;

namespace JncSofttek.Microservice.Controllers
{
    [Authorize]
    [Route("api/articles")]
    [ApiController]
    public class ArticleController : MyBaseController
    {
        public ArticleController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<MyBaseController> logger) :
            base(unitOfWork, mapper, logger)
        { }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var articles = await _unitOfWork.articleRepository.GetAllAsync();
            return Ok(new DefaultResponse<List<ArticleDto>>(
                true, result: _mapper.Map<List<ArticleDto>>(articles))
            );
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync(ArticleCreateInputDto input)
        {
            var article = _mapper.Map<Article>(input);
            article.Sku = Guid.NewGuid().ToString();

            await _unitOfWork.articleRepository.CreateAsync(article);
            return Ok(new DefaultResponse<IActionResult>(true));
        }
    }
}
