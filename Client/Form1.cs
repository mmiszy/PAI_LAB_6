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
        private int RecordsFrom = 0;

        public Form1()
        {
            InitializeComponent();
            this.ReloadData();            
        }

        private void ReloadData()
        {
            Server.Server server = new Server.Server();
            List<Server.Model> persons = server.GetData(this.RecordsFrom, Form1.DATA_SLICE).ToList();

            BindingList<Server.Model> personsList = new BindingList<Server.Model>(persons);
            this.PersonsList.DataSource = personsList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.RecordsFrom -= Form1.DATA_SLICE;
            if (this.RecordsFrom < 0)
            {
                this.RecordsFrom = 0;
            } 
            else
            {
                this.ReloadData();
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.RecordsFrom += Form1.DATA_SLICE;
            BindingList<Server.Model> personsList = (BindingList<Server.Model>)this.PersonsList.DataSource;
            this.ReloadData();
            if(((BindingList<Server.Model>)this.PersonsList.DataSource).Count == 0)
            {
                this.RecordsFrom -= Form1.DATA_SLICE;
                //rollback, because we probably went too far
                this.PersonsList.DataSource = personsList;
            }
        }
    }
}
