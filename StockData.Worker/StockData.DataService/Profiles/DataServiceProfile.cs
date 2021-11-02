using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = StockData.DataService.Entities;
using BO = StockData.DataService.BusinessObjects;

namespace StockData.DataService.Profiles
{
    public class DataServiceProfile : Profile
    {
        public DataServiceProfile()
        {
            CreateMap<EO.Company, BO.Company>().ReverseMap();
            CreateMap<EO.StockPrice, BO.StockPrice>().ReverseMap();
        }
    }
}
