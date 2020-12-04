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
    public partial class FormMedHistory : Form
    {
        public FormMedHistory()
        {
            InitializeComponent();
        }
        db c = new db();
        public void key()
        {
            btnDelete.Visible = false;
        }
        private void FormMedHistory_Load(object sender, EventArgs e)
        {
            radioButton1.Text = "Student";
            radioButton2.Text = "Date";
            radioButton3.Text = "All";
            radioButton3.Checked = true;
            txtRegNo.Enabled = false;
            dttpDate.Enabled = false;


            string sql4 = "SELECT * FROM medical_history ";
            tableMedicalHistory.DataSource = c.select(sql4);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtRegNo.Enabled = false;
            dttpDate.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtRegNo.Enabled = true;
            dttpDate.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txtRegNo.Enabled = false;
            dttpDate.Enabled = false;
            string sql2 = "SELECT * FROM medical_history";
            tableMedicalHistory.DataSource = c.select(sql2);
            txtRegNo.Clear();
            dttpDate.ResetText();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rowIndex>=0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to permanently delete this?", "Delete Appoinment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string sql = "DELETE FROM medical_history where std_id='" + txtRegNo.Text + "'";
                    bool isSuccess = c.delete(sql);
                    if (isSuccess == true)
                    {

                        txtRegNo.Text = "";
                        dttpDate.ResetText();

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


                string sql2 = "SELECT * FROM medical_history";
                tableMedicalHistory.DataSource = c.select(sql2);
                 }
            
        }
        int rowIndex = -1;
        private void tableMedicalHistory_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowIndex = e.RowIndex;
            txtRegNo.Text = tableMedicalHistory.Rows[rowIndex].Cells[1].Value.ToString();
            dttpDate.Text = tableMedicalHistory.Rows[rowIndex].Cells[4].Value.ToString();
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            String search = txtRegNo.Text;
            String search3 = dttpDate.Value.Date.ToString("yyyy-MM-dd");
            if (radioButton1.Checked == true)
            {
                string sql = "SELECT * FROM medical_history where std_id LIKE '" + search + "%' ";
                tableMedicalHistory.DataSource = c.select(sql);
            }
            if (radioButton2.Checked == true)
            {
                string sql = "SELECT * FROM medical_history where date LIKE '" + search3 + "%' ";
                tableMedicalHistory.DataSource = c.select(sql);
              
            }
        }
    }
}
