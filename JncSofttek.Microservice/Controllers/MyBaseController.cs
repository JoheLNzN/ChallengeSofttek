using AutoMapper;
using JncSofttek.Microservice.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JncSofttek.Microservice.Controllers
{
    [ApiController]
    public class MyBaseController : ControllerBase
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public readonly ILogger<MyBaseController> _logger;

        public MyBaseController(
          IUnitOfWork unitOfWork,
          IMapper mapper,
          ILogger<MyBaseController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
    }
}
