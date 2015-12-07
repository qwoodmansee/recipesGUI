using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connecting_to_MySQL
{
    public partial class MainWindow : Form
    {

        static MySqlConnection conn = new MySqlConnection();
        MySqlCommand command = conn.CreateCommand();


        public MainWindow()
        {
            InitializeComponent();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            textBox1.Anchor = 
                AnchorStyles.Bottom |
                AnchorStyles.Right |
                AnchorStyles.Top |
                AnchorStyles.Left;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.ReadOnly = true;

            //clear current text from text box
            textBox1.Clear();

            string connString = "server=127.0.0.1;port=3306;Database=recipes;uid=remoteUser1;password=testing;";
            conn.ConnectionString = connString;

            try
            {
                conn.Open();
                textBox1.Text = "Connection Established Successfully";
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;

            }

            catch (MySqlException ex)
            {
                textBox1.Text = (ex.Message);
            }

            conn.Close();

        }

        //Connect to MySQL and do a test "Open"
        private void button1_Click(object sender, EventArgs e)
        {

            

        }

        //List Recipes
        private void button2_Click(object sender, EventArgs e)
        {
            //clear current text from text box
            textBox1.Clear();

            command.CommandText = "SELECT * FROM recipes";
            try
            {
                conn.Open();
            }

            catch (Exception ex)
            {
                textBox1.Text = (ex.Message);
            }

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                textBox1.Text += (reader["recipeName"].ToString() + "\r\n");
            }

            conn.Close();
        }

        //List ingredients
        private void button3_Click(object sender, EventArgs e)
        {
            //clear current text from text box
            textBox1.Clear();

            command.CommandText = "SELECT * FROM ingredients";
            try
            {
                conn.Open();
            }

            catch (Exception ex)
            {
                textBox1.Text = (ex.Message);
            }

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                textBox1.Text += (reader["ingredientName"].ToString() + "\r\n");

            }

            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Add_Ingredient add = new Add_Ingredient();
            add.conn = conn;    
            add.Show();
        }

        //add recipe
        private void button1_Click_1(object sender, EventArgs e)
        {
            addRecipe recipe = new addRecipe(conn);
            recipe.Show();

        }

        private void searchRecipeButton_Click(object sender, EventArgs e)
        {
            SearchRecipe searchForRecipe = new SearchRecipe(conn);
            searchForRecipe.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //delete button
        private void button5_Click(object sender, EventArgs e)
        {
            deleteRecipe deleteRecipe1 = new deleteRecipe(conn);
            deleteRecipe1.Show();
        }
    }
}
