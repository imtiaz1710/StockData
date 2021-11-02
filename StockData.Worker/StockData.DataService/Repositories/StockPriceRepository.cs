using StockData.Data;
using StockData.DataService.Contexts;
using StockData.DataService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.DataService.Repositories
{
    public class StockPriceRepository : Repository<StockPrice, int>, 
        IStockPriceRepository
    {

        public StockPriceRepository(DataServiceContext context)
            : base(context)
        {

        }
    }
}
