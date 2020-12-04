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
    public partial class updateprofile : Form
    {
        public updateprofile()
        {
            InitializeComponent();
        }
        static string Type="";
        static string name = "";

        public void loginType(string type,string userid)
        {
            Type = type;
            txtRegNo.Text = userid;
            name = userid;
        }
        db c = new db();
        MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=hospital;password=;");

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;

            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE "+Type+" SET password='" + txtPassword.Text + "' WHERE  id='" + name+ "'  ";
            bool isSuccess = c.updating(sql);
            if (isSuccess == true)
            {
                MessageBox.Show("Password Updated is successfully!", "Student Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Faild! Occure something wrong Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateprofile_Load(object sender, EventArgs e)
        {
           
            string sql = "SELECT * FROM "+Type+"  WHERE id='" + name + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtFirstName.Text = reader.GetString("first_name");
                    txtLastName.Text = reader.GetString("last_name");
                    txtPassword.Text = reader.GetString("password");
                    txtContactNo.Text = reader.GetString("contact_no");
                    txtAddress.Text = reader.GetString("address");
                    dtpAppoinment.Text = reader.GetString("date_of_appointment");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
