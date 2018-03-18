using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace homework
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (StreamReader r = new StreamReader("test.json"))
            {
                string JsonFileData = r.ReadToEnd();
                List<RootObject> items = JsonConvert.DeserializeObject<List<RootObject>>(JsonFileData);
                Console.WriteLine("資料標題:新制勞工退休基金歷年最近月份收益率 \n" + "資料組筆為數 : " + items.Count +"\n");
                            
                foreach(var item in items)
                {                  
                    Console.WriteLine("年月別 :{0} 最近月份收益率(年利率):{1} 公告日期:{2} \n", item.年月別, item.最近月份收益率,item.公告日期);
                }

            }

            /*
            RootObject test = new RootObject
            {
                YearAndMonth = "2015-8",
                rate = "5.132",
                date = "2014-4-23"
            };*/
            //String Jsondata = JsonConvert.SerializeObject(test);
            
            Console.ReadLine();

        }
    }
    
   
    public class RootObject
    {
        public string 年月別 { get; set; }
        public string 最近月份收益率 { get; set; }
        public string 公告日期 { get; set; }
    }
    

}
