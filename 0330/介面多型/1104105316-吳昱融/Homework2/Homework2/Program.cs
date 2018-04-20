using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Program
    {
        static Homework2.Repository.IRepository _rep;

        static void Main(string[] args)
        {
            //--------------組員1--------------
            _rep = new Homework2.Repository.OpenDataRepository();
            List<object> datas = _rep.ReadJsonData();



            Console.WriteLine("資料標題:新制勞工退休基金歷年最近月份收益率 \n" + "資料組筆為數 : " + datas.Count + "\n");
            foreach (Models.OpenData item in datas) {
                Console.WriteLine("年月別 :{0} 最近月份收益率(年利率):{1} 公告日期:{2} \n", item.年月別, item.最近月份收益率, item.公告日期);
            }           
            Console.WriteLine("\n----------------我是分隔線----------------\n");
            //--------------組員1--------------








            Console.ReadLine();
        }
    }
}
