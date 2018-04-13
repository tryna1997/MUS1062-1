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
        static Repository.IRepository _db;

        static void Main(string[] args)
        {
            List<Object> datas;
            var t = AppDomain.CurrentDomain.BaseDirectory;
            //組員1
            _db = new Repository.OpenDataRepository();
            datas = FindOpenData();
            InsertOpenData(datas);



            Console.ReadKey();
            

        }


        public static List<Object> FindOpenData()
        {
            return _db.Find();
        }

        public static void InsertOpenData(List<Object> datas)
        {
            


            Console.WriteLine(string.Format("新增{0}筆OpenData:開始", datas.Count));
            datas.ForEach(x =>
            {

                _db.Create(x);


            });
            Console.WriteLine(string.Format("新增OpenData:結束"));


        }



    }
}
