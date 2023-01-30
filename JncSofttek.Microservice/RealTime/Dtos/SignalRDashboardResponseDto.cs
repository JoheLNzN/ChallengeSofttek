namespace JncSofttek.Microservice.RealTime.Dtos
{
    public class SignalRDashboardResponseDto
    {
        public decimal TotalSales { get; set; }
        public int TotalOrders { get; set; }
        public int ArticlesSold { get; set; }
        public int NoStockArticles { get; set; }
    }
}
