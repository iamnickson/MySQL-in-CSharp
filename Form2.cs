using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DisplayTable
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String productid = textBox1.Text;
            //char id = char.Parse(productid);
            //char[] id = productid.ToCharArray();
            String Name = textBox2.Text;
            //char productName = char.Parse(textBox2.Text);
            //char[] productName = Name.ToCharArray();
            String p = textBox3.Text;
            Double price = Convert.ToDouble(textBox3.Text);
            /*int i = 0;
            int a = id.Length;
            int b = productName.Length;
            if (a >= b)
            {
                i = a;
            }
            else
            {
                i = b;
            }
            */
            MySqlConnection mycon = new MySqlConnection("server=localhost; User Id=root; database=employee");
            mycon.Open();
            using (mycon)
            {
                MySqlCommand insert = new MySqlCommand("INSERT INTO `product`(`ProductId`, `ProductName`, `UnitPrice`) VALUES ('" + productid + "','" + Name + "'," + price + ")", mycon);
                //mycon.Open();
                //insert.ExecuteNonQuery();
                int result = insert.ExecuteNonQuery();
                if (result < 1)
                {
                    System.Windows.Forms.MessageBox.Show("Insertion failed");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Updated Successfully");
                }
                mycon.Close();
            }
            /*
             //mycon.Open();
                for (int j = 0; j < i; j++)
                {

                    MySqlCommand insert = new MySqlCommand("INSERT INTO `product`(`ProductId`, `ProductName`, `UnitPrice`) VALUES ('" + id[j] + "','" + productName[j] + "'," + price + ")", mycon);
                    
                    insert.ExecuteNonQuery();
                }
             */
            mycon.Open();
            using (mycon)
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM product", mycon);
                //mycon.Open();
                cmd.ExecuteNonQuery();

                using (MySqlDataReader mrdr = cmd.ExecuteReader())
                {
                    DataTable product = new DataTable();
                    product.Columns.Add("PID");
                    product.Columns.Add("PName");
                    product.Columns.Add("UPrice");
                    while (mrdr.Read())
                    {
                        DataRow drow = product.NewRow();
                        double productPrice = Convert.ToDouble(mrdr["UnitPrice"]);
                        drow["PID"] = mrdr["ProductId"];
                        drow["PName"] = mrdr["ProductName"];
                        drow["UPrice"] = mrdr["UnitPrice"];
                        product.Rows.Add(drow);
                    }
                    dataGridView1.DataSource = product;
                }
            }
        }
    }
}
