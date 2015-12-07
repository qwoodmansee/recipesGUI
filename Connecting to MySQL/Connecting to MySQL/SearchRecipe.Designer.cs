namespace Connecting_to_MySQL
{
    partial class SearchRecipe
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
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchResultsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(13, 46);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(183, 20);
            this.searchBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Recipe Name";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(213, 46);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search";
            this.searchButton.UseMnemonic = false;
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchResultsListBox
            // 
            this.searchResultsListBox.FormattingEnabled = true;
            this.searchResultsListBox.Location = new System.Drawing.Point(324, 30);
            this.searchResultsListBox.Name = "searchResultsListBox";
            this.searchResultsListBox.Size = new System.Drawing.Size(176, 173);
            this.searchResultsListBox.TabIndex = 3;
            this.searchResultsListBox.SelectedIndexChanged += new System.EventHandler(this.searchResultsListBox_SelectedIndexChanged);
            // 
            // SearchRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 232);
            this.Controls.Add(this.searchResultsListBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchBox);
            this.Name = "SearchRecipe";
            this.Text = "Search Recipes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ListBox searchResultsListBox;
    }
}