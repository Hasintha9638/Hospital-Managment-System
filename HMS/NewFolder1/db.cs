using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace HMS.NewFolder1
{
    class db
    {

        MySqlConnection conn = new MySqlConnection("server=localhost; user id=root; database=hospital; password=;");
        public bool insert(String sql)
        {
            conn.Open();

            bool isSuccess = false;
            try
            {
                //creating sql command using sql and conn 
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
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

        //select from table
        public DataTable select(String sql)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }



            return dt;
        }

        //update data

        public bool updating(String sql)
        {
            bool isSuccess = false;
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
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

        public bool delete(String sql)
        {
            bool isSuccess = false;
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
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

       

        public void loadNotificationFromqty()
        {
            int count2 = 0;
            string[] qtynameNo = new string[20];
            string alldrugs = "The ";
            try
            {
                conn.Open();
                string sql = "SELECT * FROM drug where qty<='" + 100 + "' ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    qtynameNo[count2++] = reader.GetString("name");

                }
               
                for (int i = 0; i < count2; i++)
                {
                    if (count2 == 1)
                    {
                        alldrugs += qtynameNo[i] + " ";
                    }
                    else if (count2 > 1)
                    {
                        alldrugs += qtynameNo[i] + " , ";
                    }

                }

                if (count2 > 0)
                {
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.info;
                    popup.TitleText = "HMS-Trincomalee Campus";
                    popup.ContentText = " " + alldrugs + " drugs quantity which are drug in inventory lower than 100";
                    popup.ContentColor = Color.Red;
                    popup.Popup();
                    popup.Delay = 5000;
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

        
        public void loadNotificationFromExp()
        {
            int count3 = 0;
            string[] qtynameNo = new string[20];
            string alldrugs = "The ";
            try
            {
                conn.Open();
                string sql = "SELECT * FROM drug where exp<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    qtynameNo[count3++] = reader.GetString("name");

                }

                for (int i = 0; i < count3; i++)
                {
                    if (count3 == 1)
                    {
                        alldrugs += qtynameNo[i] + " ";
                    }
                    else if (count3 > 1)
                    {
                        alldrugs += qtynameNo[i] + " , ";
                    }

                }

                if (count3 > 0)
                {
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.info;
                    popup.TitleText = "HMS-Trincomalee Campus";
                    popup.ContentText = " " + alldrugs + " drugs quantity which are drug in inventory has Expired";
                    popup.ContentColor = Color.Red;
                    popup.Popup();
                    
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


        static int count = 0;
        public bool lablecolor()
        {
            //notification for qty
            string sql = "SELECT * FROM drug where qty<='" + 100 + "' OR exp<='" + DateTime.Now.ToString("yyyy-MM-dd") + "' ";
            bool isSuccess = false;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    count++;
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

    }
}
