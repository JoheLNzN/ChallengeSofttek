using JncSofttek.Microservice.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace JncSofttek.Microservice.RealTime.Hubs
{
    public class BaseHub : Hub
    {
        public readonly IUnitOfWork _unitOfWork;
        public BaseHub(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    }
}
