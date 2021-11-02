using Autofac;
using StockData.DataService.BusinessObjects;
using StockData.DataService.Services;
using System.Collections.Generic;

namespace StockData.Worker.Model
{
    public class CreateStockModel : ICreateStockModel
    {
        public List<object> TableData { get; set; } = new List<object>();
        public IStockService StockService { get; set; }
        private string _tableStatus { get; set; }

        public CreateStockModel(IStockService stockService)
        {
            StockService = stockService;
        }

        public CreateStockModel()
        {
            StockService = Worker.AutofacContainer.Resolve<IStockService>();
        }

        public void LoadTableData()
        {
            var tableModel = new ExtractTableModel();
            tableModel.ExtractTable(this);
            _tableStatus = tableModel.TableStatus;
        }

        public void Create()
        {
            if(_tableStatus != "Closed")
            {
                for (int i = 0; i < TableData.Count; i += 11)
                {
                    var company = new Company();
                    if(i + 1 == 1)
                    {
                        var str = (string)TableData[i + 1];
                        str = str.Split('>', '<')[2].Trim();
                        company.TradeCode = str;
                    }
                    else
                    {
                        company.TradeCode = (string)TableData[i + 1];
                    }

                    var stockPrice = new StockPrice();
                    stockPrice.LastTradingPrice = (string)TableData[i + 2];
                    stockPrice.High = (string)TableData[i + 3];
                    stockPrice.Low = (string)TableData[i + 4];
                    stockPrice.ClosePrice = (string)TableData[i + 5];
                    stockPrice.YesterdayClosePrice = (string)TableData[i + 6];
                    stockPrice.Change = (string)TableData[i + 7];
                    stockPrice.Trade = (string)TableData[i + 8];
                    stockPrice.Value = (string)TableData[i + 9];
                    stockPrice.Volume = (string)TableData[i + 10];

                    StockService.CreateStock(company, stockPrice);
                }
            }
        }
    }
}
