using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodes = FindStations();

            ShowStation(nodes);

            Console.WriteLine("按下任一鍵進行新增資料庫");
            Console.ReadKey();
            //InsertStation(stations);

        }


        public static List<OpenData> FindStations()
        {
            List<OpenData> nodeList = new List<OpenData>();



            var xml = XElement.Load(@"C:\Users\user\Downloads\datagovtw_dataset_20180316 (1).xml");


            //XNamespace gml = @"http://www.opengis.net/gml/3.2";
            //XNamespace twed = @"http://twed.wra.gov.tw/twedml/opendata";
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
            return nodeList;

        }
        private static string getValue(XElement node,string propertyName)
        {
            return node.Element(propertyName)?.Value.Trim();

        }

        public static void ShowStation(List<OpenData> nodes)
        {

            Console.WriteLine(string.Format("共收到{0}筆的資料", nodes.Count));
            nodes.GroupBy(node => node.服務分類).ToList()
                .ForEach(group =>
                {

                    var key = group.Key;
                    var groupDatas = group.ToList();
                    var message = $"服務分類:{key},共有{groupDatas.Count()}筆資料";
                    Console.WriteLine(message);
                });


        }


        //public static void InsertStation(List<Station> stations)
        //{
        //    Repository.DatabaseRepository db = new Repository.DatabaseRepository();


        //    Console.WriteLine(string.Format("新增{0}筆監測站的資料開始", stations.Count));
        //    stations.ForEach(x =>
        //    {

        //        db.CreateStation(x);


        //    });
        //    Console.WriteLine(string.Format("新增監測站的資料結束"));


        //}
    }
}
