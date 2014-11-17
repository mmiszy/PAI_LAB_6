using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    interface IDataSource
    {
        IList<Model> GetData();
        void SaveData(IList<Model> data);
    }
}
