using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Server
{
    /// <summary>
    /// Summary description for Server
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Server : System.Web.Services.WebService
    {
        [WebMethod]
        public List<Model> GetData(int from = 0, int slice = 1)
        {
            ValueListHandler VLHandler = new ValueListHandler();
            return VLHandler.GetData(from, slice).ToList();
        }

        [WebMethod]
        public void SaveData(Model transferObject)
        {
            DAO Dao = new DAO(DAO.DAOType.JSON);
            Dao.SavePerson(transferObject);
        }
    }
}
