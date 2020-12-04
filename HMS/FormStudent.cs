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
    public partial class FormStudent : Form
    {
        public FormStudent()
        {
            InitializeComponent();
        }
        db c = new db();
        MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=hospital;password=;");
        public void parsingValue(String name)
        {
            txtRegNo.Text = name;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormMedHistory medHistory = new FormMedHistory();
            medHistory.key();
            medHistory.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO feedback (std_id,first_name,last_name,message,date) VALUES('" + txtRegNo.Text + "','" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtMessage.Text+ "','" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
            bool isSuccess = c.insert(sql);
            if (isSuccess == true)
            {
                MessageBox.Show("Sending Feedback is successfully!", "Sending Feedback", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMessage.Text = "";
            }
            else
            {
                MessageBox.Show("Faild! Occure something wrong Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "";
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked==true)
            {
                txtPassword.UseSystemPasswordChar = false;
                
            }else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE students SET password='" + txtPassword.Text + "' WHERE  id='" + txtRegNo.Text + "'  ";
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

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
           
            if (checkBoxShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void FormStudent_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM students  WHERE id='" + txtRegNo.Text + "'";
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
                    dtpDOB.Text = reader.GetString("date_of_birth");

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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
