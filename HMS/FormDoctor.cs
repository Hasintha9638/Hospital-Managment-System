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
    public partial class FormDoctor : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=hospital;password=;");
        public FormDoctor()
        {
            InitializeComponent();
        }
        db c = new db();
        DataTable dt = new DataTable();
        static string loginusername = "";
        public void whoLogin(string name)
        {
            loginusername = name;
        }


        private void FormDoctor_Load(object sender, EventArgs e)
        {
            loadCombo();
            txtQty.Enabled = false;
            radioAll.Checked = true;
            dt.Columns.Add("Name",typeof(string));
            dt.Columns.Add("Qty", typeof(int));
            drugTable.DataSource = dt;

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

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM appointment WHERE std_id='" + txtRegNo.Text+"' ";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtNote.Text = reader.GetString("note");
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

        private void comboDrugName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQty.Enabled = true;
            string sql = "SELECT * FROM drug  WHERE name='"+comboDrugName.Text+"'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtExp.Text = reader.GetString("exp");
                    txtAvailableQty.Text = reader.GetString("qty");

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
        public void loadCombo()
        {
            comboDrugName.Items.Clear();
            string sql = "SELECT * FROM drug";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql,conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString("name");
                    comboDrugName.Items.Add(name);
                }
            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string name = comboDrugName.Text;
            if (name=="")
            {
                MessageBox.Show("select the drug item first,Try again!");
            }else
            {
                if (txtQty.Text=="")
                {
                    MessageBox.Show("please input the amount of medicines");
                    return;
                }
                int qtyNo = Convert.ToInt32(txtQty.Text)+0;
                dt.Rows.Add(comboDrugName.Text,txtQty.Text);
                drugTable.DataSource = dt;

                comboDrugName.Text = "";
                txtAvailableQty.Text = "";
                txtExp.Text = "";

            } 


        }
       

        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            string dateToday = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = "SELECT * FROM appointment where date='" + dateToday + "'";
            appointedTable.DataSource = c.select(sql);
        }

        private void radioComplete_CheckedChanged(object sender, EventArgs e)
        {
            string dateToday = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = "SELECT * FROM appointment where completed='" + "yes" + "' AND date='" + dateToday + "' ";
            appointedTable.DataSource = c.select(sql);
        }

        private void radioNocomplete_CheckedChanged(object sender, EventArgs e)
        {
            string dateToday = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = "SELECT * FROM appointment where completed='" + "no" + "' AND date='" + dateToday + "' ";
            appointedTable.DataSource = c.select(sql);
        }

        private void appointedTable_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            txtRegNo.Text = appointedTable.Rows[row].Cells[1].Value.ToString();
        }
        int row=-1;
        private void drugTable_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            row = e.RowIndex;
           
        }

        private void button8_Click(object sender, EventArgs e)
        {   //clear data temporaly in drug table
            if (row>=0)
            {
                int rowIndex = drugTable.CurrentCell.RowIndex;
                drugTable.Rows.RemoveAt(rowIndex);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtRegNo.Text!="")
            {
                string drug_name = "";

                int drug_qty = 0;

                string drugname = "";
                for (int i = 0; i < drugTable.Rows.Count ; i++)
                {
                    drugname += drugTable.Rows[i].Cells[0].Value.ToString() + "," + drugTable.Rows[i].Cells[1].Value.ToString() + ",";
                    drug_name = drugTable.Rows[i].Cells[0].Value.ToString();
                    drug_qty = Convert.ToInt32(drugTable.Rows[i].Cells[1].Value.ToString());

                    int oldamount = 0;
                    string sql3 = "SELECT * FROM drug WHERE name = '" + drug_name + "' ";
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(sql3, conn);
                        MySqlDataReader adapter = cmd.ExecuteReader();
                        if (adapter.Read())
                        {
                            oldamount = adapter.GetInt32("qty") + 0;
                        }


                        int total = oldamount - drug_qty;
                        string sql2 = "UPDATE drug SET qty='" + total + "' WHERE name = '" + drug_name + "' ";
                        c.updating(sql2);

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



                string sql = "INSERT INTO drug_issue (std_id,date,drugs,no_of_days,drug_issued) VALUES('" + txtRegNo.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + drugname + "','" + comboNoOfleaves.Text + "','" + "no" + "')";
                bool isSuccess = c.insert(sql);
               
                if (isSuccess == true)
                {
                    MessageBox.Show("Appoinment has checked  successfully!", "Appoinment Checked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string sql5 = "INSERT INTO medical_history (std_id,date,drug,diagnostic) VALUES('" + txtRegNo.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + drugname + "','" + txtNote.Text + "')";
                    bool isSuccessed = c.insert(sql5);
                    string sql2 = "UPDATE appointment SET completed='" + "yes" + "' WHERE  std_id='" + txtRegNo.Text + "'  ";
                    c.updating(sql2);
                    string dateToday = DateTime.Now.ToString("yyyy-MM-dd");
                    string sql4 = "SELECT * FROM appointment where completed='" + "no" + "' AND date='" + dateToday + "' ";
                    appointedTable.DataSource = c.select(sql4);
                    radioNocomplete.Checked = true;
                    clear();
                }
                else
                {
                    MessageBox.Show("Faild! Occure something wrong Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Enter the Registration number,Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            txtNote.Text = "";
            txtQty.Text = "";
            txtRegNo.Text = "";
            comboNoOfleaves.Text = "";
            ((DataTable)drugTable.DataSource).Rows.Clear();
            drugTable.Refresh();
            
        }

        private void radioNocomplete_CheckedChanged_1(object sender, EventArgs e)
        {
            string dateToday = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = "SELECT * FROM appointment where completed='" + "no" + "' AND date='" + dateToday + "' ";
            appointedTable.DataSource = c.select(sql);
            int row = appointedTable.Rows.Count;
            if (row==0)
            {
                lblCompltedMessage.Visible = true;
            }
            
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            updateprofile x = new updateprofile();
            x.loginType("doctor", loginusername);
            x.Show();
            
        }
    }
}
