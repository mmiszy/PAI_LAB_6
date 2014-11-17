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
        private JSONDataSource.JSONDataSource DataSource;
        private IList<Model> Data;

        public DAO()
        {
            this.DataSource = new JSONDataSource.JSONDataSource();
            this.Data = this.DataSource.GetData();
        }

        public IList<Model> GetData()
        {
            return this.Data;
        }

        public Model GetPersonById(int id)
        {
            return this.Data.Where((person) =>
                person.Id.Equals(id)).First();
        }

        public void SavePerson(Model person)
        {
            this.Data[person.Id] = person;
            this.DataSource.SaveData(this.Data);   
        }
    }
}