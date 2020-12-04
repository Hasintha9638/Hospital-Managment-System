using HMS.NewFolder1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HMS
{
    public partial class warnings : Form
    {
        public warnings()
        {
            InitializeComponent();
        }
        db c = new db();

        private void warnings_Load(object sender, EventArgs e)
        {
            
            string sql = "SELECT * FROM drug where qty<='"+100+"' ";
            tableLess20.DataSource = c.select(sql);


            string sql2 = "SELECT * FROM drug where exp<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' ";
            tableExp.DataSource = c.select(sql2);
        }
    }
}
