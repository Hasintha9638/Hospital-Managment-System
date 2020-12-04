using HMS.NewFolder1;
using MySql.Data.MySqlClient;
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
    public partial class drugIssued : Form
    {
        public drugIssued()
        {
            InitializeComponent();
        }
        db c = new db();
        MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=hospital;password=;");
        private void drugIssued_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM drug_issue";
            tableIssued.DataSource = c.select(sql);
            txtRegNo.Enabled = false;
            dtpDate.Enabled = false;
            radioAll.Checked = true;
        }

        private void radioDate_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM drug_issue";
            tableIssued.DataSource = c.select(sql);
            txtRegNo.Enabled = false;
            dtpDate.Enabled = true;
        }

        private void radioId_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM drug_issue";
            tableIssued.DataSource = c.select(sql);
            txtRegNo.Enabled = true;
            dtpDate.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String search = txtRegNo.Text;
            String search2 = dtpDate.Value.Date.ToString("yyyy-MM-dd");
            if (radioDate.Checked == true)
            {
                string sql = "SELECT * FROM drug_issue where date LIKE  '" + search2 + "%' ";
                tableIssued.DataSource = c.select(sql);
                txtRegNo.Text = "";
                dtpDate.ResetText();
            }
            if (radioId.Checked == true)
            {
                string sql = "SELECT * FROM drug_issue where std_id LIKE  '" + search + "%' ";
                tableIssued.DataSource = c.select(sql);
                txtRegNo.Text = "";
                dtpDate.ResetText();
            }

        }
        int row = -1;

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (row>=0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to permanently delete this?", "Delete Appoinment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string sql = "DELETE FROM drug_issue where std_id='" + txtRegNo.Text + "'";
                    bool isSuccess = c.delete(sql);
                    if (isSuccess == true)
                    {
                        row = -1;
                        txtRegNo.Text = "";
                        dtpDate.ResetText();

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
           
            

            string sql2 = "SELECT * FROM drug_issue";
            tableIssued.DataSource = c.select(sql2);
        }

        private void tableIssued_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            row = e.RowIndex;
            txtRegNo.Text = tableIssued.Rows[row].Cells[1].Value.ToString();
            dtpDate.Text = tableIssued.Rows[row].Cells[2].Value.ToString();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM drug_issue";
            tableIssued.DataSource = c.select(sql);
            txtRegNo.Enabled = false;
            dtpDate.Enabled = false;
        }

        private void radioNotIssue_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM drug_issue where drug_issued='"+"no"+"'";
            tableIssued.DataSource = c.select(sql);
            txtRegNo.Enabled = false;
            dtpDate.Enabled = false;
        }

        private void Issue_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM drug_issue where drug_issued='" + "yes" + "'";
            tableIssued.DataSource = c.select(sql);
            txtRegNo.Enabled = false;
            dtpDate.Enabled = false;
        }
    }
}
