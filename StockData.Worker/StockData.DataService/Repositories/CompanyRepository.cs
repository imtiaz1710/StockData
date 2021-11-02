using Microsoft.EntityFrameworkCore;
using StockData.Data;
using StockData.DataService.Entities;
using StockData.DataService.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.DataService.Repositories
{
    public class CompanyRepository : Repository<Company, int>, 
        ICompanyRepository
    {
        public CompanyRepository(IDataServiceContext context)
            : base((DbContext)context)
        {
        }
    }
}
