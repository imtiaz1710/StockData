using System.Collections;
using System.Collections.Generic;

namespace StockData.Worker.Model
{
    public interface ICreateStockModel
    {
        public List<object> TableData { get; set; }
    }
}