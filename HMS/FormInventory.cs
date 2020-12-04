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
    public partial class FormInventory : Form
    {
        public FormInventory()
        {
            InitializeComponent();
        }
        db c = new db();
        MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=hospital;password=;");

        private void FormInventory_Load(object sender, EventArgs e)
        {
            radioButton3.Text = "Item No.";
            radioButton2.Text = "Name";
            radioButton1.Text = "Exp. Date";
            radioButton4.Text = "Add New Drug";
            radioButton5.Text = "Update Drug";

            radioAll.Checked = true;
            btnAdd.Enabled = false;
            comboQtyNumber.Enabled = true;
            txtQty.Enabled = false;
            btnEdit.Enabled = false;

            string sql = "SELECT * FROM drug";
            tableDrugs.DataSource = c.select(sql);
            loadCombo();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txtItemNo.Enabled = true;
            txtItemName.Enabled = false;
            dtpItemExp.Enabled = false;
            btnAdd.Visible = false;
            btnEdit.Enabled = false;
            btnSearch.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtItemNo.Enabled = false;
            txtItemName.Enabled = true;
            dtpItemExp.Enabled = false;
            btnAdd.Visible = false;
            btnEdit.Enabled =false;
            btnSearch.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtItemNo.Enabled = false;
            txtItemName.Enabled = false;
            dtpItemExp.Enabled = true;
            btnAdd.Visible = false;
            btnEdit.Enabled = false;
            btnSearch.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            string sql = "INSERT INTO drug (item_id,name,exp) VALUES('" + txtItemNo.Text + "','" + txtItemName.Text + "','" + dtpItemExp.Value.Date.ToString("yyyy-MM-dd") + "')";
            bool isSuccess = c.insert(sql);
            if (isSuccess == true)
            {
                MessageBox.Show("Adding new drugs  is successfully!", "Adding new drug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtItemName.Text = "";
                txtItemNo.Text = "";
                
                

            }
            else
            {
                MessageBox.Show("Faild! Occure something wrong Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string sql2 = "SELECT * FROM drug";
            tableDrugs.DataSource = c.select(sql2);
            loadCombo();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            txtItemNo.Enabled = true;
            txtItemName.Enabled = true;
            dtpItemExp.Enabled = true;
            btnEdit.Visible = false;
            btnSearch.Enabled = false;
            btnAdd.Visible = true;
            btnAdd.Enabled = true;
            

            txtItemNo.Text = "";
            txtItemName.Text = "";
            dtpItemExp.ResetText();
            

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            txtItemNo.Enabled = true;
            txtItemName.Enabled = true;
            dtpItemExp.Enabled = true;
            btnAdd.Visible = false;
            btnEdit.Visible = true;
            btnSearch.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            string sql = "UPDATE drug SET item_id='" + txtItemNo.Text + "',name='"+txtItemName.Text+"',exp='"+dtpItemExp.Value.Date.ToString("yyyy-MM-dd")+"' WHERE  item_id='" + txtItemNo.Text + "'  ";
            bool isSuccess = c.updating(sql);
            if (isSuccess == true)
            {
                MessageBox.Show("Updating drug  is successfully!", "Updating drugs", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Faild! Occure something wrong Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string sql2 = "SELECT * FROM drug";
            tableDrugs.DataSource = c.select(sql2);
            loadCombo();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String search = txtItemName.Text;
            String search2 = txtItemNo.Text;
            String search3 = dtpItemExp.Value.Date.ToString("yyyy-MM-dd");
            if (radioButton3.Checked==true)
            {
                string sql = "SELECT * FROM drug where item_id LIKE '" + search2 + "%' ";
                tableDrugs.DataSource = c.select(sql);
                txtItemName.Text = "";
                dtpItemExp.ResetText();
            }
            if (radioButton2.Checked == true)
            {
                string sql = "SELECT * FROM drug where name LIKE '" + search + "%' ";
                tableDrugs.DataSource = c.select(sql);
                txtItemNo.Text = "";
                dtpItemExp.ResetText();
            }
            if (radioButton1.Checked == true)
            {
                string sql = "SELECT * FROM drug where exp LIKE '" + search3 + "%' ";
                tableDrugs.DataSource = c.select(sql);
                txtItemName.Text = "";
                txtItemNo.Text = "";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int newAmountOfItem = Convert.ToInt32(txtQty.Text)+0;
            int oldamount = 0;
            string sql3 = "SELECT * FROM drug WHERE item_id = '" + comboQtyNumber.Text + "' ";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql3, conn);
                MySqlDataReader adapter = cmd.ExecuteReader();
                if (adapter.Read())
                {
                    oldamount = adapter.GetInt32("qty")+0;
                }


                int total = oldamount + newAmountOfItem;
                string sql = "UPDATE drug SET qty='" + total + "' WHERE item_id = '" + comboQtyNumber.Text + "' ";
                bool isSuccess = c.updating(sql);
                if (isSuccess == true)
                {
                    MessageBox.Show("Adding new drugs qty is successfully!", "Adding quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Faild! Occure something wrong Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
           
            string sql2 = "SELECT * FROM drug";
            tableDrugs.DataSource = c.select(sql2);
            
        }

        private void txtQtyName_TextChanged(object sender, EventArgs e)
        {
            comboQtyNumber.Enabled = true;
            txtQty.Enabled = true;
        }

        private void tableDrugs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableDrugs_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtItemNo.Text = tableDrugs.Rows[rowIndex].Cells[1].Value.ToString();
            txtItemName.Text = tableDrugs.Rows[rowIndex].Cells[2].Value.ToString();
            dtpItemExp.Text = tableDrugs.Rows[rowIndex].Cells[3].Value.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to permanently delete this?", "Delete Appoinment", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                string sql = "DELETE FROM drug where item_id='" + txtItemNo.Text + "'";
                bool isSuccess = c.delete(sql);
                if (isSuccess == true)
                {

                    txtItemNo.Text = "";
                    dtpItemExp.ResetText();
                    txtItemName.Text = "";
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
            

            string sql2 = "SELECT * FROM drug";
            tableDrugs.DataSource = c.select(sql2);
        }

        private void tableDrugs_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtItemNo.Text = tableDrugs.Rows[rowIndex].Cells[1].Value.ToString();
            txtItemName.Text = tableDrugs.Rows[rowIndex].Cells[2].Value.ToString();
            dtpItemExp.Text = tableDrugs.Rows[rowIndex].Cells[3].Value.ToString();
            comboQtyNumber.Text= tableDrugs.Rows[rowIndex].Cells[1].Value.ToString(); 
        }

        public void loadCombo()
        {
            comboQtyNumber.Items.Clear();
            string sql = "SELECT * FROM drug ";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader adapter = cmd.ExecuteReader();
                while (adapter.Read())
                {
                    string sname = adapter.GetString("item_id");
                    comboQtyNumber.Items.Add(sname); 
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

        private void comboQtyNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboQtyNumber.Enabled = true;
            txtQty.Enabled = true;
        }

        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM drug";
            tableDrugs.DataSource = c.select(sql);
            txtItemName.Enabled = false;
            txtItemNo.Enabled = false;
            dtpItemExp.Enabled = false;




        }

        private void dtpItemExp_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
