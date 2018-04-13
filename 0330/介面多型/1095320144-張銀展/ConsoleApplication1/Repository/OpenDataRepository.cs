using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace YC.Repository
{
    public class OpenDataRepository : IRepository
    {
        public string XmlPath
        {
            get
            {
                return YC.Shared.Utils.GetDataPath() + @"opendata.xml";
            }
            set => throw new NotImplementedException();
        }
        public string ConnectionString
        {
            get
            {
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + YC.Shared.Utils.GetDataPath() + @"OpenData.mdf;Integrated Security=True";
                //return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ Directory.GetCurrentDirectory() + @"\App_Data\nodeDB.mdf;Integrated Security=True";
            }
            set => throw new NotImplementedException();
        }
        private string getValue(XElement node, string propertyName)
        {
            return node.Element(propertyName)?.Value.Trim();

        }
        public void Create(object item)
        {
            var newItem = item as YC.Models.OpenData;
            var connection = new System.Data.SqlClient.SqlConnection(ConnectionString);
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
            INSERT INTO OpenData(ID, 資料集名稱, 服務分類, 資料集描述, DisplaySqe)
            VALUES              ('{0}',N'{1}',N'{2}',N'{3}','{4}')
            ", newItem.ID, newItem.資料集名稱, newItem.服務分類, newItem.資料集描述, newItem.ID);

            command.ExecuteNonQuery();


            connection.Close();
        }

        public List<Object> Find()
        {
            List<YC.Models.OpenData> nodeList = new List<YC.Models.OpenData>();



            var xml = XElement.Load(XmlPath);
            var nodes = xml.Descendants("node").ToList();

            nodeList = nodes
                .Where(x => !x.IsEmpty).ToList()
                .Select(node =>
                {
                    YC.Models.OpenData item = new YC.Models.OpenData();
                    item.ID = getValue(node, "id");
                    item.資料集名稱 = getValue(node, "資料集名稱");
                    item.服務分類 = getValue(node, "服務分類");
                    item.資料集描述 = getValue(node, "資料集描述");
                    return item;

                }).ToList();
            return nodeList.OfType<Object>().ToList();
        }

    }
}
