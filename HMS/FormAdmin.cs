using HMS.NewFolder1;
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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }
        db c = new db();
        int row=-1;
        static string loginusername = "";
        public void whoLogin(string name)
        {
            loginusername = name;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FormStudentReg studReg = new FormStudentReg();
            studReg.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            clearDat();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            comboH.SelectedIndex = 0;
            comboM.SelectedIndex = 0;
            radioToday.Checked = true;
            c.loadNotificationFromqty();
            c.loadNotificationFromExp();
            if (c.lablecolor())
            {
                btnWarnings.BackColor = Color.Crimson;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDoctorReg docReg = new FormDoctorReg();
            docReg.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormPharmasistReg pharReg = new FormPharmasistReg();
            pharReg.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormAdminReg adminReg = new FormAdminReg();
            adminReg.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormMedHistory medHistory = new FormMedHistory();
            medHistory.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormInventory inventory = new FormInventory();
            inventory.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (txtRegNo.Text != "")
            {
                string time = comboH.Text + ":" + comboM.Text;
                string sql = "INSERT INTO appointment (std_id,date,time,note) VALUES('" + txtRegNo.Text + "','" + dtpDate.Value.Date.ToString("yyyy-MM-dd") + "','" + time + "','" + txtNote.Text + "')";
                bool isSuccess = c.insert(sql);
                if (isSuccess == true)
                {
                    MessageBox.Show("Appoinment create Successfuly!", "Appointment Create", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNote.Text = "";
                    txtRegNo.Text = "";
                }
                else
                {
                    MessageBox.Show("Faild! Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            

            string dateToday = DateTime.Now.ToString("yyyy-MM-dd");
            string sql2 = "SELECT * FROM appointment where date='" + dateToday + "'";
            appointedTable.DataSource = c.select(sql2);
        }

        public void clearDat()
        {
            txtNote.Text = "";
            txtRegNo.Text = "";
            comboM.SelectedIndex = 0;
            comboH.SelectedIndex = 0;
            dtpDate.ResetText();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Users x = new Users();
            x.Show();

        }

        private void radioToday_CheckedChanged(object sender, EventArgs e)
        {
          
            string dateToday = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = "SELECT * FROM appointment where date='"+dateToday+"'";
            appointedTable.DataSource = c.select(sql);
        }

        private void radioComplete_CheckedChanged(object sender, EventArgs e)
        {
           
            string sql = "SELECT * FROM appointment where completed='"+"yes"+"'";
            appointedTable.DataSource = c.select(sql);
        }

        private void radioNocomplete_CheckedChanged(object sender, EventArgs e)
        {
       
            string sql = "SELECT * FROM appointment where completed='" + "no" + "'";
            appointedTable.DataSource = c.select(sql);
        }

        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM appointment";
            appointedTable.DataSource = c.select(sql);
        }
        static string std_id = "";
        private void btnMark_Click(object sender, EventArgs e)
        {
            if (std_id!="")
            {
                string sql = "UPDATE appointment SET completed='" + "yes" + "' WHERE  std_id='" + std_id + "'  ";
                bool isSuccess = c.updating(sql);
                if (isSuccess == true)
                {
                    MessageBox.Show("Appoinment has marked Completed!","Mark as Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string sql3 = "SELECT * FROM appointment where completed='" + "yes" + "'";
                    appointedTable.DataSource = c.select(sql3);
                    radioComplete.Checked = true;


                }
                else
                {
                    MessageBox.Show("Faild! Try again","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("please! select the row");
            }
            

        }
        
        private void appointedTable_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            row = e.RowIndex;
            std_id = appointedTable.Rows[row].Cells[1].Value.ToString();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (row>=0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to permanently delete this?", "Delete Appoinment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string sql = "DELETE FROM appointment where std_id='" + std_id + "'";
                    bool isSuccess = c.delete(sql);
                    if (isSuccess == true)
                    {

                        row = -1;
                    }
                    else
                    {
                        MessageBox.Show("Faild! Occure something wrong Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    string sql2 = "SELECT * FROM appointment";
                    appointedTable.DataSource = c.select(sql2);
                    radioAll.Checked = true;
                }
                else
                {
                    // Do something  
                }
            }
            
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            feefback x = new feefback();
            x.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            drugIssued x = new drugIssued();
            x.Show();
        }

        private void btnWarnings_Click(object sender, EventArgs e)
        {
            warnings x = new warnings();
            x.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            updateprofile x = new updateprofile();
            x.loginType("admin", loginusername);
            x.Show();
           
        }
    }
}
