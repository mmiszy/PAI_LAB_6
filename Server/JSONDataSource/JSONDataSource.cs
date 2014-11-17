using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Server.JSONDataSource
{
    public class JSONDataSource : IDataSource
    {
        private JavaScriptSerializer Serializer = new JavaScriptSerializer();

        public IList<Model> GetData()
        {
            IList<Model> persons;
            try
            {
                string data = File.ReadAllText("data.json");
                persons = this.Serializer.Deserialize<IList<Model>>(data);
            }
            catch (Exception e)
            {
                persons = new List<Model>();
            }
            
            return persons;
        }

        public void SaveData(IList<Model> data)
        {
            string serialized = this.Serializer.Serialize(data);
            File.WriteAllText("data.json", serialized);
        }
    }
}