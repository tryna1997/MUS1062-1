using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Repository
{

    public interface IRepository
    {
        string XmlPath { get; set; }
        string ConnectionString { get; set; }
        List<Object> Find();
        void Create(Object item);
    }

    public class OpenDataRepository : IRepository
    {
        public string XmlPath
        {
            get
            {
                return Directory.GetCurrentDirectory() + @"\App_Data\opendata.xml";
            }
            set => throw new NotImplementedException();
        }
        public string ConnectionString
        {
            get
            {
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Github\MUS1062\0330\介面多型\1095320144-張銀展\ConsoleApplication1\App_Data\nodeDB.mdf;Integrated Security=True";
                //return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ Directory.GetCurrentDirectory() + @"\App_Data\nodeDB.mdf;Integrated Security=True";
            }
            set => throw new NotImplementedException();
        }
        private static int count = 0;
        private string getValue(XElement node, string propertyName)
        {
            return node.Element(propertyName)?.Value.Trim();

        }
        public void Create(object item)
        {
            var newItem= item as OpenData;
            count += 1;
            var connection = new System.Data.SqlClient.SqlConnection(ConnectionString);
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
            INSERT INTO OpenData(ID, 資料集名稱, 服務分類, 資料集描述, DisplaySqe)
            VALUES              ('{0}',N'{1}',N'{2}',N'{3}','{4}')
            ", count, newItem.資料集名稱, newItem.服務分類,newItem.資料集描述, count);

            command.ExecuteNonQuery();


            connection.Close();
        }

        public List<Object> Find()
        {
            List<OpenData> nodeList = new List<OpenData>();



            var xml = XElement.Load(XmlPath);
            var nodes = xml.Descendants("node").ToList();

            nodeList = nodes
                .Where(x => !x.IsEmpty).ToList()
                .Select(node =>
                {
                    OpenData item = new OpenData();
                    item.ID = getValue(node, "ID");
                    item.資料集名稱 = getValue(node, "資料集名稱");
                    item.服務分類 = getValue(node, "服務分類");
                    item.資料集描述 = getValue(node, "資料集描述");
                    return item;

                }).ToList();
            return nodeList.OfType<Object>().ToList();
        }
        
    }


    public class StationRepository : IRepository
    {
        public string XmlPath
        {
            get
            {
                return Directory.GetCurrentDirectory() +@"\App_Data\opendata.xml";
            }
            set => throw new NotImplementedException();
        }
        public string ConnectionString
        {
            get
            {
                return @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=nodeDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            }
            set => throw new NotImplementedException();
        }
        private static int count = 0;
        private string getValue(XElement node, string propertyName)
        {
            return node.Element(propertyName)?.Value.Trim();

        }
        public void Create(Object item)
        {
        }

        public List<Object> Find()
        {
            return null;
 
        }

    }





    
}
