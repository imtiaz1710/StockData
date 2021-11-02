using StockData.Data;
using StockData.DataService.Repositories;

namespace StockData.DataService.UnitOfWorks
{
    public interface IDataServiceUnitOfWork : IUnitOfWork
    {
        ICompanyRepository Companies { get; }
        IStockPriceRepository  StockPrices { get; }
    }
}