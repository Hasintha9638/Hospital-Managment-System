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
    public partial class FormPharmasistReg : Form
    {
        public FormPharmasistReg()
        {
            InitializeComponent();
        }
        db c = new db();

        private void button9_Click(object sender, EventArgs e)
        {
            clearDat();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO pharmasist (id,first_name,last_name,date_of_appointment,address,contact_no,password) VALUES('" + txtRegNo.Text + "','" + txtFirstName.Text + "','" + txtLastName.Text + "','" + dtpAppoinment.Value.Date.ToString("yyyy-MM-dd") + "','" + txtAddress.Text + "','" + txtContactNo.Text + "','"+ txtPassword.Text + "')";
            bool isSuccess = c.insert(sql);
            if (isSuccess == true)
            {
                MessageBox.Show("Pharmasist Registration is successfully!", "Pharmasist Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearDat();
            }
            else
            {
                MessageBox.Show("Faild! Occure something wrong Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clearDat()
        {
            txtContactNo.Text = "";
            txtRegNo.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtPassword.Text = "";
            dtpAppoinment.ResetText();
        }

        private void FormPharmasistReg_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=hospital;password=;");
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    label1.Text = "Connected";
                    label1.ForeColor = Color.Green;
                }
                else
                {
                    label1.Text = "Not Connected";
                    label1.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
