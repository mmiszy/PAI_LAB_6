using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server
{
    public class ValueListHandler
    {
        private DAO Dao = new DAO();
        private IList<Model> Data;

        public ValueListHandler()
        {
            this.Data = this.Dao.GetData();
        }

        public IList<Model> GetData(int from = 0, int slice = 1)
        {
            IList<Model> dataSlice = this.Data.Skip(from).Take(slice).ToList();
            return dataSlice;
        }
    }
}