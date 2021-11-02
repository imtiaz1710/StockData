using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker.Model
{
    public class ExtractTableModel : IExtractTableModel
    {
        public string TableStatus { get; set; }

        public void ExtractTable(ICreateStockModel model)
        {
            var url = "https://www.dse.com.bd/latest_share_price_scroll_l.php";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            TableStatus = doc.DocumentNode.SelectSingleNode(
                "//div[@class='HeaderTop']/span[@class='time']/span[@class='green']/b").InnerHtml;

            var tbody = doc.DocumentNode.SelectSingleNode(
                "//table[@class='table table-bordered background-white shares-table fixedHeader']/thead");

            tbody = tbody.NextSibling;

            do
            {
                if (tbody.NodeType == HtmlNodeType.Element)
                {
                    var tr = tbody.ChildNodes;
                    foreach (var trow in tr)
                    {
                        if (trow.NodeType == HtmlNodeType.Element)
                        {
                            bool flag = true;
                            if (trow.HasChildNodes)
                            {
                                var tdata = trow.ChildNodes;
                                foreach (var data in tdata)
                                {
                                    if (data.NodeType == HtmlNodeType.Element)
                                    {
                                        model.TableData.Add(data.InnerHtml.Trim());
                                        flag = false;
                                    }
                                }
                            }
                            if (flag == true)
                                model.TableData.Add(trow.InnerHtml.Trim());
                        }
                    }
                }
                tbody = tbody.NextSibling;
            } while (tbody != null);
        }
    }
}
