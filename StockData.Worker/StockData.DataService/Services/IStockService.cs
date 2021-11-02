using StockData.DataService.BusinessObjects;

namespace StockData.DataService.Services
{
    public interface IStockService
    {
        void CreateStock(Company company, StockPrice stockPrice);
    }
}