using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class Object
    {
        public string Name { get; set; }
        public string Religion { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Manager { get; set; }
        public string Tel { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader x = new StreamReader("20180318.json"))
            {
                string Datas = x.ReadToEnd();
                List<Object> content = JsonConvert.DeserializeObject<List<Object>>(Datas);

                foreach (var tag in content)
                {
                    Console.WriteLine("宗教場域名稱 :{0} \n宗教別 :{1} \n宗教場域地址 :{2}{3} \n管理人員 :{4} \n電話 :{5} \n\n", tag.Name, tag.Religion, tag.District, tag.Address, tag.Manager, tag.Tel);
                }
             }
            Console.ReadLine();
        }
    }
}
