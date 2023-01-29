using JncSofttek.Microservice.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JncSofttek.Microservice.Controllers
{
    [ApiController]
    public class MyBaseController : ControllerBase
    {
        public readonly IUnitOfWork _unitOfWork;

        public MyBaseController(
          IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    }
}
