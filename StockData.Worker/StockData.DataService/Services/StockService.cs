using AutoMapper;
using StockData.DataService.BusinessObjects;
using StockData.DataService.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.DataService.Services
{
    public class StockService : IStockService
    {
        private readonly IDataServiceUnitOfWork _dataServiceUnitOfWork;
        private readonly IMapper _mapper;

        public StockService(IDataServiceUnitOfWork dataServiceUnitOfWork,
            IMapper mapper)
        {
            _dataServiceUnitOfWork = dataServiceUnitOfWork;
            _mapper = mapper;
        }

        public void CreateStock(Company company, StockPrice stockPrice)
        {
            if ((company == null) || (stockPrice == null))
                throw new NullReferenceException("Stock was not provided");

            var entityCompany = _mapper.Map<Entities.Company>(company);

            entityCompany.StockPrice = _mapper.Map<Entities.StockPrice>(stockPrice);

            _dataServiceUnitOfWork.Companies.Add(entityCompany);

            _dataServiceUnitOfWork.Save();
        }
    }
}
