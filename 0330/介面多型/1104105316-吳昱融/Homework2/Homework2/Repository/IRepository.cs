
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Homework2.Repository
{
    public interface IRepository
    {
        string DataName { get;}       
        List<object> ReadJsonData();

    }
}