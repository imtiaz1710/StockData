namespace StockData.Worker.Model
{
    public interface IExtractTableModel
    {
        void ExtractTable(ICreateStockModel createStockModel);
    }
}