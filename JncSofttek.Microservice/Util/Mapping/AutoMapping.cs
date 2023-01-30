using AutoMapper;
using JncSofttek.Microservice.DataAccess.Models;
using JncSofttek.Microservice.Repository.Repositories.Dtos.Article;
using JncSofttek.Microservice.Repository.Repositories.Dtos.User;

namespace JncSofttek.Microservice.Util.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserDto>();
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleCreateInputDto, Article>();
        }
    }
}
