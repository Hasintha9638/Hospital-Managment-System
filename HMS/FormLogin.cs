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
using Tulpep.NotificationWindow;

namespace HMS
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        db c = new db();
        MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=hospital;password=;");
      
        private void FormLogin_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
           
          
 
        }


        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
    


        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) {

                bool isSuccess=login("admin");
                Console.WriteLine(isSuccess);
                if (isSuccess==true)
                {
                    FormAdmin admin = new FormAdmin();
                    this.Hide();
                    admin.whoLogin(txtUsername.Text);
                    admin.Show();
                   
                }else
                {
                    MessageBox.Show("Faild! Username or Password wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }


            else if(comboBox1.SelectedIndex == 1) {
                bool isSuccess = login("doctor");
                if (isSuccess == true)
                {
                    FormDoctor doctor = new FormDoctor();
                    this.Hide();
                    doctor.whoLogin(txtUsername.Text);
                    doctor.Show();
                   
                }
                else
                {
                    MessageBox.Show("Faild! Username or Password wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

            else if (comboBox1.SelectedIndex == 2)
            {
                bool isSuccess = login("pharmasist");
                if (isSuccess == true)
                {
                    FormPharmasist pharmasist = new FormPharmasist();
                    this.Hide();
                    pharmasist.whoLogin(txtUsername.Text);
                    pharmasist.Show();
                   
                }
                else
                {
                    MessageBox.Show("Faild! Username or Password wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }

            else if (comboBox1.SelectedIndex == 3)
            {
                bool isSuccess = login("students");
                if (isSuccess == true)
                {
                    FormStudent student = new FormStudent();
                    student.parsingValue(txtUsername.Text);
                    this.Hide();
                    student.Show();
                }
                else
                {
                    MessageBox.Show("Faild! Username or Password wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }




        public bool login(string table2)
        {
            string sql = "SELECT * FROM "+ table2 +" where password='"+txtPassword.Text+"' and id='"+txtUsername.Text+"' ";
            bool isSuccess =false;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count = count + 1;
                }
                if (count>=1)
                {
                    isSuccess = true;
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
            return isSuccess;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Faild! This have no permission from admin of the application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        
    }
}
