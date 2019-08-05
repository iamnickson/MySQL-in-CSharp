using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DisplayTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string productid = textBox1.Text;
            MySqlConnection mycon = new MySqlConnection("server=localhost; User Id=root; database=employee");
            
           
            using (mycon)
            {
                MySqlCommand productName = new MySqlCommand("SELECT * FROM `product` WHERE `ProductId`=" + productid, mycon);
                mycon.Open();
                //productName.ExecuteNonQuery();

                //textBox2.Text = productName.ExecuteScalar();
                //productName.ExecuteReader();
                MySqlDataReader DR1 = productName.ExecuteReader();
                if (DR1.Read())
                {
                    textBox2.Text = DR1.GetValue(1).ToString();
                    textBox3.Text = DR1.GetValue(2).ToString();
                }
            }
            mycon.Close();
        }
    }
}
