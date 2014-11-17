using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Server
{
    public class DAO
    {
        private JSONDataSource.JSONDataSource DataSource = new JSONDataSource.JSONDataSource();
        private IList<Model> Data;

        public DAO ()
        {
            this.Data = this.DataSource.GetData();
        }

        public Model GetPersonById (int id)
        {
            return this.Data.Where((person) =>
                person.Id.Equals(id)).First();
        }

        public void SavePerson (Model person)
        {
            this.Data[person.Id] = person;
        }
    }
}