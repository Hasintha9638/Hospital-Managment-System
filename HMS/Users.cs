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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }
        db c = new db();
        static string key = ""; 

        private void button1_Click(object sender, EventArgs e)
        {
            key = "students";
            string sql2 = "SELECT * FROM students";
            detailsTable.DataSource = c.select(sql2);
            btnDelete.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            key = "doctor";
            string sql2 = "SELECT * FROM doctor";
            detailsTable.DataSource = c.select(sql2);
            btnDelete.Enabled = true;
        }

        private void Users_Load(object sender, EventArgs e)
        {
            radioButton2.Text = "ID";
            radioButton3.Text = "Name";
            btnDelete.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            key = "pharmasist";
            string sql2 = "SELECT * FROM pharmasist";
            detailsTable.DataSource = c.select(sql2);
            btnDelete.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            key = "admin";
            string sql2 = "SELECT * FROM admin";
            detailsTable.DataSource = c.select(sql2);
            //btnDelete.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txtItemNo.Enabled = false;
            txtItemName.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtItemNo.Enabled = true;
            txtItemName.Enabled = false;
        }
        int rowIndex = -1;
        private void detailsTable_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
             rowIndex= e.RowIndex;
            txtItemNo.Text = detailsTable.Rows[rowIndex].Cells[0].Value.ToString();
            txtItemName.Text = detailsTable.Rows[rowIndex].Cells[1].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String search = txtItemName.Text;
            String search2 = txtItemNo.Text;
        
            if (radioButton3.Checked == true)
            {
                string sql = "SELECT * FROM "+key+ " where first_name LIKE '" + search + "%' ";
                detailsTable.DataSource = c.select(sql);
                txtItemNo.Text = "";
               
            }
            if (radioButton2.Checked == true)
            {
                string sql = "SELECT * FROM " + key + " where id LIKE '" + search2 + "%' ";
                detailsTable.DataSource = c.select(sql);
                txtItemName.Text = "";
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (rowIndex>=0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to permanently delete this?", "Delete Appoinment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    String search2 = txtItemNo.Text;
                    string sql = "DELETE FROM " + key + " where id= '" + search2 + "' ";
                    detailsTable.DataSource = c.delete(sql);
                    rowIndex = -1;
                    txtItemName.Text = "";
                    txtItemNo.Text = "";

                    string sql2 = "SELECT * FROM " + key;
                    detailsTable.DataSource = c.select(sql2);
                }
                else
                {
                    // Do something  
                }
            }
           
            
            

        }
    }
}
