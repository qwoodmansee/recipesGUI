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
    public partial class SearchRecipe : Form
    {

        public MySqlConnection conn;
        MySqlDataReader reader;
        MySqlCommand command;
        List<string> searchResults;

        public SearchRecipe(MySqlConnection parentConn)
        {
            InitializeComponent();
            conn = parentConn;
            command = conn.CreateCommand();
            searchResults = new List<string>();
            searchResultsListBox.DataSource = searchResults;
                
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

            //clear the parameters from any past searches
            command.Parameters.Clear();

            //clear the search results from any past searches
            searchResults.Clear();

            //connect to sql server
            try
            {
                conn.Open();
            }

            catch (Exception ex)
            {
                searchBox.Text = (ex.Message);
            }

            //check to make sure there is text in the box
            if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                MessageBox.Show("Please enter a search term", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //search the database for a recipe like search box
            command.CommandText = "SELECT recipeName FROM recipes WHERE recipeName LIKE CONCAT('%', @search, '%');";
            command.Parameters.AddWithValue("search", searchBox.Text.ToString());
            
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                searchResults.Add(reader["recipeName"].ToString());
            }

            //sort the list of results
            searchResults.Sort();

            //refresh the data source
            searchResultsListBox.DataSource = null;
            searchResultsListBox.DataSource = searchResults;

            reader.Close();
            conn.Close();

            searchResultsListBox.DoubleClick += new EventHandler(searchResultsListBox_DoubleClick);


        }

        //open a recipe if it is double clicked
        private void searchResultsListBox_DoubleClick(object sender, EventArgs e)
        {
            if (searchResultsListBox.SelectedItem != null)
            {
                recipeViewer viewer = new recipeViewer(conn, searchResultsListBox.SelectedItem.ToString());
                viewer.Show();
            }
        }

        private void searchResultsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
