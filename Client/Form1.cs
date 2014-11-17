using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private const int DATA_SLICE = 10;

        public Form1()
        {
            InitializeComponent();

            Server.Server server = new Server.Server();
            List<Server.Model> persons = server.GetData(0, Form1.DATA_SLICE).ToList();

            BindingList<Server.Model> personsList = new BindingList<Server.Model>(persons);
            this.PersonsList.DataSource = personsList;
        }
    }
}
