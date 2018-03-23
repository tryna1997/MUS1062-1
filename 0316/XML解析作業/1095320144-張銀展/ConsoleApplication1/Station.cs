using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class OpenData
    {
        private string _id;

        public string ID
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        public string 資料集名稱 { get; set; }
        public string 服務分類 { get; set; }
        public string 資料集描述 { get; set; }

        public void SetID(string value)
        {
            this._id = value;
        }
        public string GetID()
        {
            return this._id;
        }
        //public string locationAddress;

        //public string LocationAddress
        //{
        //    get
        //    {
        //        return locationAddress;
        //    }
        //    set
        //    {
        //        if (value.Length < 10)
        //            locationAddress = value;
        //        else
        //            locationAddress = "";
        //    }
        //}


    }
}
