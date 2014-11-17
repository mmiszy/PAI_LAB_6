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
        private Server.Server server;

        public Form1()
        {
            InitializeComponent();
            this.ReloadData();            
        }

        private void ReloadData()
        {
            this.server = new Server.Server();
            List<Server.Model> persons = this.server.GetData(this.RecordsFrom, Form1.DATA_SLICE).ToList();

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
                //rollback, because we probably went too far
                this.RecordsFrom -= Form1.DATA_SLICE;
                this.PersonsList.DataSource = personsList;
            }
        }

        private void PersonsList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }

            Server.Model transferObject = ((BindingList<Server.Model>)this.PersonsList.DataSource)[e.RowIndex];
            this.server.SaveData(transferObject);
            this.ReloadData();
        }
    }
}
