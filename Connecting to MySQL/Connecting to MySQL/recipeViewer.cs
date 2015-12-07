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
    public partial class recipeViewer : Form
    {

        public MySqlConnection conn;
        MySqlDataReader reader;
        MySqlCommand command;
        Dictionary<string, List<object>> searchResults;

        public recipeViewer(MySqlConnection parentConn, string recipeName)
        {
            InitializeComponent();

            //dictionary for search results
            searchResults = new Dictionary<string, List<object>>();

            //label with recipe name
            label1.Text = recipeName;

            //set up a connection and check that it opens
            conn = parentConn;

            //text box 1 attributes
            textBox1.ReadOnly = true;
            textBox1.TabStop = false;

            try
            {
                conn.Open();
            }

            catch (Exception ex)
            {
                textBox1.Text = (ex.Message);
            }

            //create a command 
            command = conn.CreateCommand();

            //get the information from the SQL database
            command.CommandText = "SELECT ingredientName, unit, amount FROM recipes natural join hasingredients natural join ingredients WHERE recipeName = @recipeName; ";
            command.Parameters.AddWithValue("recipeName", recipeName);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                searchResults[reader.GetString(0)] = new List<object>();
                searchResults[reader.GetString(0)].Add(reader.GetFloat(2)); // get amount
                searchResults[reader.GetString(0)].Add(reader.GetString(1)); //get unit
                searchResults[reader.GetString(0)].Add(reader.GetString(0)); //get name of ingredient
            }

            reader.Close();

            //add all the ingredients and amounts to the output.
            foreach (var item in searchResults)
            {
                textBox1.Text += item.Value[0].ToString() + " " + item.Value[1] + " " + item.Value[2] + "\r\n";
            }

            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
