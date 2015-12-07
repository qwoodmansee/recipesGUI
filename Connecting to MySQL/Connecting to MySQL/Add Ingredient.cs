using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Connecting_to_MySQL
{
    public partial class Add_Ingredient : Form
    {
        public MySqlConnection conn;

        public Add_Ingredient()
        {
            InitializeComponent();
            textBox2.Text = "0.50";
            textBox3.ReadOnly = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
            }

            catch (Exception ex)
            {
                textBox3.Text = ex.Message;
            }

            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO ingredients(ingredientName, cost) VALUES(@ingredientName, @cost)";
            command.Parameters.AddWithValue("ingredientName", textBox1.Text.ToString());
            command.Parameters.AddWithValue("cost", float.Parse(textBox2.Text));

            try
            {
                command.ExecuteNonQuery();
                textBox3.Text = "Added Ingredient";
            }
            catch (Exception ex)
            {
                textBox3.Text = ex.Message;
            }

            conn.Close();

        }

        private void Add_Ingredient_Load(object sender, EventArgs e)
        {

        }
    }
}
