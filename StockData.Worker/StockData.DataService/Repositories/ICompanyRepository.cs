using StockData.Data;
using StockData.DataService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.DataService.Repositories
{
    public interface ICompanyRepository : IRepository<Company, int>
    {
    }
}
