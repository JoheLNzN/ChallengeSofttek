using JncSofttek.Microservice.RealTime.Dtos;
using JncSofttek.Microservice.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace JncSofttek.Microservice.RealTime.Hubs
{
    public class DashboardHub : BaseHub
    {
        public DashboardHub(
            IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task SoldArticle()
        {
            var orders = await _unitOfWork.orderRepository.GetAllAsync();
            var countNoStock = await _unitOfWork.articleRepository.CountArticlesNoStockAsync();

            decimal totalSales = 0;
            int articlesSold = 0;

            foreach (var order in orders)
            {
                totalSales += order.Amount;
                articlesSold += order.Quantity;
            }

            var response = new SignalRDashboardResponseDto()
            {
                ArticlesSold = articlesSold,
                NoStockArticles = countNoStock,
                TotalOrders = orders.Count,
                TotalSales = totalSales
            };

            await Clients.All.SendAsync("notifyNewPurchase", response);
        }
    }
}
