
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;


namespace Homework2.Repository
{
    class OpenDataRepository : IRepository
    {
        public string DataName {
            get {
                return Homework2.Shared.member1.GetDataName();
            }
        }

        public List<object> ReadJsonData() {
            StreamReader r = new StreamReader(DataName);
            string JsonFileData = r.ReadToEnd();
            List<Homework2.Models.OpenData> JsonData;

            JsonData = JsonConvert.DeserializeObject<List<Homework2.Models.OpenData>>(JsonFileData);
            return JsonData.OfType<Object>().ToList();

        }



    }
}