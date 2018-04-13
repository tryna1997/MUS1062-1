using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YC.Repository
{
    public interface IRepository
    {
        string XmlPath { get; set; }
        string ConnectionString { get; set; }
        List<Object> Find();
        void Create(Object item);
    }
}
