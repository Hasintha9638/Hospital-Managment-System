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
    public partial class FormPharmasist : Form
    {
        public FormPharmasist()
        {
            InitializeComponent();
        }

        db c = new db();
        static string loginusername = "";
        public void whoLogin(string name)
        {
            loginusername = name;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        DataTable table = new DataTable();
        private void FormPharmasist_Load(object sender, EventArgs e)
        {
            comboPaymentMethod.SelectedIndex = 0;
            radioToday.Checked = true;
            string dateToday = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = "SELECT * from drug_issue where date='"+dateToday+"'";
            tableOrder.DataSource = c.select(sql);


            table.Columns.Add("Drugs Name", typeof(string));
            table.Columns.Add("qty", typeof(string));
            tabledrugs.DataSource = table;


            c.loadNotificationFromqty();
            c.loadNotificationFromExp();
            if (c.lablecolor())
            {
                btnWarnings.BackColor= Color.Crimson;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormInventory inventory = new FormInventory();
            inventory.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
          
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            feefback x = new feefback();
            x.fromPharmisit();
            x.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            warnings x = new warnings();
            x.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string dateToday = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = "SELECT * from drug_issue where date='" + dateToday + "' and drug_issued='"+"yes"+"'";
            tableOrder.DataSource = c.select(sql);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string dateToday = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = "SELECT * from drug_issue where date='" + dateToday + "' and drug_issued='" + "no" + "'";
            tableOrder.DataSource = c.select(sql);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * from drug_issue";
            tableOrder.DataSource = c.select(sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (row>=0)
            {
                string sql = "UPDATE  drug_issue SET	drug_issued='" + "yes" + "' where order_id='" + tableOrder.Rows[row].Cells[0].Value + "' ";
                bool isSuccess = c.insert(sql);
                if (isSuccess == true)
                {
                    MessageBox.Show("Drug ISSUED is successfully!", "Drug Issue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string dateToday = DateTime.Now.ToString("yyyy-MM-dd");
                    string sql2 = "SELECT * from drug_issue where date='" + dateToday + "' and drug_issued='" + "no" + "'";
                    tableOrder.DataSource = c.select(sql2);
                    radioNotIssued.Checked = true;
                    ((DataTable)tabledrugs.DataSource).Rows.Clear();
                    row = -1;

                }
                else
                {
                    MessageBox.Show("Faild! Occure something wrong Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Faild! No order is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            double amount = Convert.ToDouble(txtAmount.Text);
            double paid = Convert.ToDouble(txtPaid.Text);
            double balance = paid - amount;
            txtBalance.Text = balance.ToString()+".00";

        }
        int row = -1;
        private void tableOrder_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            row = e.RowIndex;
            string drugs = tableOrder.Rows[row].Cells[3].Value.ToString();
            string[] drugslist = drugs.Split(',');
            for (int i=0;i<drugslist.Length-1;i+=2)
            {
                table.Rows.Add(drugslist[i],drugslist[i+1]);
            }


        }

        private void radioToday_CheckedChanged(object sender, EventArgs e)
        {
            string dateToday = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = "SELECT * from drug_issue where date='" + dateToday + "' ";
            tableOrder.DataSource = c.select(sql);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string dateToday = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = "SELECT * from drug_issue where date='" + dateToday + "' and drug_issued='" + "no" + "'";
            tableOrder.DataSource = c.select(sql);
            radioNotIssued.Checked = true;

        }
        int rowindex=-1;
        private void button8_Click(object sender, EventArgs e)
        {   
             
            if (rowindex>=0)
            {
                rowindex = tabledrugs.CurrentCell.RowIndex;
                tabledrugs.Rows.RemoveAt(rowindex);
            }
          
            
        }

        private void tabledrugs_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            rowindex = e.RowIndex;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            updateprofile x = new updateprofile();
            x.loginType("pharmasist", loginusername);
            x.Show();
           
        }
    }
}
