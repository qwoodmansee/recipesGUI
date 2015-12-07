namespace Connecting_to_MySQL
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.searchRecipeButton = new System.Windows.Forms.Button();
            this.deleteRecipeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "List Recipes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(399, 25);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(584, 319);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(166, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(148, 35);
            this.button3.TabIndex = 3;
            this.button3.Text = "List Ingredients";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(166, 154);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(148, 35);
            this.button4.TabIndex = 4;
            this.button4.Text = "Add Ingredient";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "Add Recipe";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // searchRecipeButton
            // 
            this.searchRecipeButton.Location = new System.Drawing.Point(12, 85);
            this.searchRecipeButton.Name = "searchRecipeButton";
            this.searchRecipeButton.Size = new System.Drawing.Size(148, 35);
            this.searchRecipeButton.TabIndex = 6;
            this.searchRecipeButton.Text = "Search Recipes";
            this.searchRecipeButton.UseVisualStyleBackColor = true;
            this.searchRecipeButton.Click += new System.EventHandler(this.searchRecipeButton_Click);
            // 
            // deleteRecipeButton
            // 
            this.deleteRecipeButton.Location = new System.Drawing.Point(12, 222);
            this.deleteRecipeButton.Name = "deleteRecipeButton";
            this.deleteRecipeButton.Size = new System.Drawing.Size(148, 35);
            this.deleteRecipeButton.TabIndex = 7;
            this.deleteRecipeButton.Text = "Delete Recipes";
            this.deleteRecipeButton.UseVisualStyleBackColor = true;
            this.deleteRecipeButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 358);
            this.Controls.Add(this.deleteRecipeButton);
            this.Controls.Add(this.searchRecipeButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Name = "MainWindow";
            this.Text = "Recipes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button searchRecipeButton;
        private System.Windows.Forms.Button deleteRecipeButton;
    }
}

