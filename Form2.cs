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
            string productid = textBox1.Text;
            string Name = textBox2.Text;
            string p = textBox3.Text;
            Double price = Convert.ToDouble(textBox3.Text);

            System.Windows.Forms.MessageBox.Show(productid);
            System.Windows.Forms.MessageBox.Show(Name);

            MySqlConnection mycon = new MySqlConnection("server=localhost; User Id=root; database=employee");
            mycon.Open();
            using (mycon)
            {
                MySqlCommand insert = new MySqlCommand("INSERT INTO `product`(`ProductId`, `ProductName`, `UnitPrice`) VALUES ('" + productid + "','" + Name + "'," + price + ")", mycon);
                int result = insert.ExecuteNonQuery();
                if (result < 1)
                {
                    System.Windows.Forms.MessageBox.Show("Insertion failed");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Inserted Successfully");
                }
                mycon.Close();
            }

            mycon.Open();
            using (mycon)
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM product", mycon);
                cmd.ExecuteNonQuery();
                using (MySqlDataReader mrdr = cmd.ExecuteReader())
                {
                    DataTable product = new DataTable();
                    product.Columns.Add("PID");
                    product.Columns.Add("PName");
                    product.Columns.Add("UPrice");
                    product.Columns.Add("Discount");
                    while (mrdr.Read())
                    {
                        DataRow drow = product.NewRow();
                        double productPrice = Convert.ToDouble(mrdr["UnitPrice"]);
                        double discount = productPrice * 0.9;
                        drow["PID"] = mrdr["ProductId"];
                        drow["PName"] = mrdr["ProductName"];
                        drow["UPrice"] = mrdr["UnitPrice"];
                        drow["Discount"] = discount;
                        product.Rows.Add(drow);
                    }
                    dataGridView1.DataSource = product;
                }
            }
            mycon.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string productid = textBox1.Text;
            string Name = textBox2.Text;
            string p = textBox3.Text;
            Double price = Convert.ToDouble(textBox3.Text);

            MySqlConnection mycon = new MySqlConnection("server=localhost; User Id=root; database=employee");
            mycon.Open();
            using (mycon)
            {
                MySqlCommand update = new MySqlCommand("UPDATE `product` SET `ProductId`='" + productid + "',`ProductName`='" + Name + "',`UnitPrice`=" + price + " WHERE ProductId='" + productid + "'", mycon);
                update.ExecuteNonQuery();
                
                int result = update.ExecuteNonQuery();
                if (result < 1)
                {
                    System.Windows.Forms.MessageBox.Show("Update failed");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("The Product Name and Price of " + productid + " has been Updated Successfully");
                }
                mycon.Close();
            }
            mycon.Close();

            mycon.Open();
            using (mycon)
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM product", mycon);
                cmd.ExecuteNonQuery();
                using (MySqlDataReader mrdr = cmd.ExecuteReader())
                {
                    DataTable product = new DataTable();
                    product.Columns.Add("PID");
                    product.Columns.Add("PName");
                    product.Columns.Add("UPrice");
                    product.Columns.Add("Discount");
                    while (mrdr.Read())
                    {
                        DataRow drow = product.NewRow();
                        double productPrice = Convert.ToDouble(mrdr["UnitPrice"]);
                        double discount = productPrice * 0.9;
                        drow["PID"] = mrdr["ProductId"];
                        drow["PName"] = mrdr["ProductName"];
                        drow["UPrice"] = mrdr["UnitPrice"];
                        drow["Discount"] = discount;
                        product.Rows.Add(drow);
                    }
                    dataGridView1.DataSource = product;
                }
            }
        }
    }
}
