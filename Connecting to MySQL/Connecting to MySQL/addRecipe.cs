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


//todo: after failing a test (and returning) make it start over somehow
//todo: fix multiple click garbage with combo box in selected recipes box
//todo: make sure we are closing connection correctly when closing this window.


namespace Connecting_to_MySQL
{
    public partial class addRecipe : Form
    {
        public MySqlConnection conn;
        MySqlDataReader reader;
        MySqlCommand command;
        Dictionary<string, uint> ingredientsDict;
        List<string> ingredientsList;


        public addRecipe(MySqlConnection parentConn)
        {

            InitializeComponent();
            conn = parentConn;
            command = conn.CreateCommand();
            command.CommandText = "SELECT ingredientName, ingredientID FROM ingredients";
            try
            {
                conn.Open();
            }

            catch (Exception ex)
            {
                textBox1.Text = (ex.Message);
            }

            //List Box 1 (Available Ingredients)
            reader = command.ExecuteReader();
            ingredientsDict = new Dictionary<string, uint>();

            while (reader.Read())
            {
                ingredientsDict[(reader["ingredientName"].ToString())] = reader.GetUInt32(reader.GetOrdinal("ingredientID")); 

            }
            reader.Close();
            conn.Close();

            ingredientsList = ingredientsDict.Keys.ToList();

            //sort for good looks
            ingredientsList.Sort();
            listBox1.DataSource = ingredientsList;
            listBox1.SelectionMode = SelectionMode.MultiSimple;
            listBox1.ClearSelected();

            //set up selected ingredients data grid view
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {            
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
            }

            catch (Exception ex)
            {
                textBox1.Text = (ex.Message);
            }

            Add_Ingredient add = new Add_Ingredient();
            add.conn = conn;
            add.ShowDialog(); //waits for add ingredient to close.

            //refresh the left list so the new ingredient is there.
            listBox1.DataSource = null;
            listBox1.DataSource = ingredientsList;

            conn.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // left to right
        private void button3_Click(object sender, EventArgs e)
        {

            // add selected ingredients to the other list view
            for (int x = listBox1.SelectedIndices.Count - 1; x >= 0; x--)
            {
          
                int idx = listBox1.SelectedIndices[x];
                dataGridView1.Rows.Add(listBox1.Items[idx].ToString(), 0);  

                //remove from the left box
                ingredientsList.RemoveAt(idx);
            }

            // refresh the left box
            ingredientsList.Sort();
            listBox1.DataSource = null;
            listBox1.DataSource = ingredientsList;

        }

        //right to left
        private void button4_Click(object sender, EventArgs e)
        {
            
            // add selected ingredients to the other list box
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                ingredientsList.Add(r.Cells[0].Value.ToString());
                dataGridView1.Rows.Remove(r);
            }
            
            ingredientsList.Sort();
            // refresh the left box
            listBox1.DataSource = null;
            listBox1.DataSource = ingredientsList;

        }

        //add recipe button
        private void button1_Click(object sender, EventArgs e)
        {
            //check values to make sure everything has been filled out correctly
            string testResult = checkValues();

            if (testResult != "Good")
            {
                MessageBox.Show(testResult, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //open the connection for all the work of adding a recipe
            try
            {
                conn.Open();
            }

            catch (Exception ex)
            {
                textBox1.Text = (ex.Message);
            }

            int categoryID = 0;
            //determine category ID based on selected item
            command.CommandText = "SELECT categoryID FROM categories WHERE categoryName = @categoryName";
            command.Parameters.AddWithValue("categoryName", CategoryComboBox.SelectedItem.ToString());

            //get the ID from SQL
            try
            {
                //execute SQL command
                categoryID = (int) command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //catch if command fails
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //add the recipe to the recipe table 
            command.CommandText = "INSERT INTO recipes(prepTime, cookTime, recipeName, categoryID) VALUES(@prepTime, @cookTime, @recipeName, @categoryID);";
            command.Parameters.AddWithValue("prepTime", float.Parse(textBox2.Text.ToString()));
            command.Parameters.AddWithValue("cookTime", float.Parse(textBox3.Text.ToString()));
            command.Parameters.AddWithValue("recipeName", textBox1.Text.ToString());
            command.Parameters.AddWithValue("categoryID", categoryID);

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

            //get the recipe ID of what we just inserted
            int recipeID = (int) command.LastInsertedId;

            //Create a command to add the ingredient to the recipe
            command.CommandText = "INSERT INTO hasIngredients(amount, recipeID, ingredientID, unit) VALUES(@amount, @recipeID, @ingredientID, @unit)";

            // should be the same recipe no matter what
            command.Parameters.AddWithValue("recipeID", recipeID);

            //these will change each time through the loop
            command.Parameters.Add(new MySqlParameter("ingredientID", MySqlDbType.UInt32));
            command.Parameters.Add(new MySqlParameter("amount", MySqlDbType.Float));
            command.Parameters.Add(new MySqlParameter("unit", MySqlDbType.String));

            uint ingredientID;

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {

                ingredientID = ingredientsDict[r.Cells[0].Value.ToString()];
                command.Parameters["ingredientID"].Value = ingredientID;
                command.Parameters["amount"].Value = r.Cells[1].Value;

                //add the ingredient to the recipe
                switch (r.Cells[2].Value.ToString())
                {
                    //handle drop down menu for unit
                    case "C.":
                        command.Parameters["unit"].Value = "CUP";
                        break;
                    case "Tbsp.":
                        command.Parameters["unit"].Value = "TABLESPOON";
                        break;
                    case "Tsp.":
                        command.Parameters["unit"].Value = "TEASPOON";
                        break;
                    case "Each":
                        command.Parameters["unit"].Value = "EACH";
                        break;
                    
                }

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

           

            MessageBox.Show("Recipe added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            conn.Close();
            this.Close();
        }

        //checks all values (recipe name, cook time, prep time, selected ingredients values) and returns a string message
        // returns "Good" if all values are good.
        private string checkValues()
        {
            float value; //used for error checking

            //check for recipe name
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                return "Please Enter a Recipe Name";
            }

            //check to make sure there are some ingredients
            if (dataGridView1.Rows.Count == 0)
            {
                return "Please add ingredients to the recipe";
            }

            //make sure prep time is entered correctly
            if (string.IsNullOrWhiteSpace(textBox2.Text) || float.TryParse(textBox2.Text, out value))
            {
            }
            else
            {
                return "Please enter a decimal or integer for Prep Time";
            }

            //make sure cook time is entered correctly
            if (string.IsNullOrWhiteSpace(textBox3.Text) || float.TryParse(textBox3.Text, out value))
            {
            }
            else
            {
                return "Please enter a decimal or integer for Cook Time";
            }

            //check to make sure something has been selected for category
            if (CategoryComboBox.SelectedIndex == -1)
            {
                return "Please select something for the category";
            }

            //check to make sure every subvalue of ingredients are okay
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                //make sure the values in the amount column are good
                if (float.TryParse(r.Cells[1].Value.ToString(), out value) && (float.Parse(r.Cells[1].Value.ToString()) > 0))
                {
                }
                else
                {
                    return "Please enter a decimal or integer amount for all amounts";
                }

                //make sure the unit type has been selected
                if (r.Cells[2].Value == null)
                {
                    return "Please Select something for the unit column";
                }
                
            }

            //all tests passed
            return "Good";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
