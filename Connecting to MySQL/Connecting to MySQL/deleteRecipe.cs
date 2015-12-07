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
    public partial class deleteRecipe : Form
    {

        public MySqlConnection conn;
        MySqlDataReader reader;
        MySqlCommand command;
        Dictionary<string, uint> recipesDict;
        List<string> recipesList;

        public deleteRecipe(MySqlConnection parentConn)
        {
            InitializeComponent();
            conn = parentConn;
            command = conn.CreateCommand();
            command.CommandText = "SELECT recipeName, recipeID FROM recipes";
            try
            {
                conn.Open();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //List Box 1 (Available Ingredients)
            reader = command.ExecuteReader();
            recipesDict = new Dictionary<string, uint>();

            while (reader.Read())
            {
                recipesDict[(reader["recipeName"].ToString())] = reader.GetUInt32(reader.GetOrdinal("recipeID"));

            }

            reader.Close();
            conn.Close();

            recipesList = recipesDict.Keys.ToList();

            //sort for good looks
            recipesList.Sort();
            listBox1.DataSource = recipesList;
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            listBox1.ClearSelected();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //delete button
        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            command.CommandText = "DELETE FROM recipes where recipeID = @recipeID";

            //get selected items list 
            foreach (var item in listBox1.SelectedItems)
            {
                command.Parameters.AddWithValue("recipeID", recipesDict[item.ToString()]);

                try
                {
                    //execute SQL command
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //catch if command fails
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            MessageBox.Show("Recipe Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
            conn.Close();
            this.Close();
        }
    }
}
