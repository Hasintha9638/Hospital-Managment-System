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
    public partial class feefback : Form
    {
        public feefback()
        {
            InitializeComponent();
        }
        db c = new db();
        int row=-1;
        public void fromPharmisit()
        {
            btnDelete.Visible = false;
        }
        private void feefback_Load(object sender, EventArgs e)
        {
            string sql = "SELECT id,std_id,message from feedback";
            tablefeedback.DataSource = c.select(sql);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (row>=0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to permanently delete this?", "Delete Appoinment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string sql2 = "DELETE FROM  feedback where std_id='" + tablefeedback.Rows[row].Cells[1].Value.ToString() + "'";
                    bool isSuccess = c.delete(sql2);
                    if (isSuccess == true)
                    {
                        row = -1;

                    }
                    else
                    {
                        MessageBox.Show("Faild! Occure something wrong Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Do something  
                }
            }
           

           
            string sql = "SELECT id,std_id,message from feedback";
            tablefeedback.DataSource = c.select(sql);
        }

        private void tablefeedback_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            row = e.RowIndex;

        }
    }
}
