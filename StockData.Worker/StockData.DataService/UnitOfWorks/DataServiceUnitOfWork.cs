using Microsoft.EntityFrameworkCore;
using StockData.Data;
using StockData.DataService.Contexts;
using StockData.DataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.DataService.UnitOfWorks
{
    public class DataServiceUnitOfWork : UnitOfWork, IDataServiceUnitOfWork
    {
        public ICompanyRepository Companies { get; private set; }
        public IStockPriceRepository StockPrices { get; private set; }

        public DataServiceUnitOfWork(IDataServiceContext context,
            ICompanyRepository companies,
            IStockPriceRepository stockprices
            ) : base((DbContext)context)
        {
            Companies = companies;
            StockPrices = stockprices;
        }
    }
}
