namespace _8_CheckedListBox_
{
    partial class Form1
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.ClearSelectedButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.InsertButton = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.Remove = new System.Windows.Forms.Button();
            this.RemoveAtButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ShowCheckedButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.Info;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Dima",
            "Ivan",
            "Katya",
            "Kolya",
            "Nika",
            "Olya"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(321, 199);
            this.checkedListBox1.TabIndex = 0;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(12, 243);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(89, 23);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // ClearSelectedButton
            // 
            this.ClearSelectedButton.Location = new System.Drawing.Point(12, 272);
            this.ClearSelectedButton.Name = "ClearSelectedButton";
            this.ClearSelectedButton.Size = new System.Drawing.Size(89, 23);
            this.ClearSelectedButton.TabIndex = 3;
            this.ClearSelectedButton.Text = "Clear Selected";
            this.ClearSelectedButton.UseVisualStyleBackColor = true;
            this.ClearSelectedButton.Click += new System.EventHandler(this.ClearSelectedButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(111, 216);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 20);
            this.textBox1.TabIndex = 4;
            // 
            // InsertButton
            // 
            this.InsertButton.Location = new System.Drawing.Point(111, 243);
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(52, 23);
            this.InsertButton.TabIndex = 5;
            this.InsertButton.Text = "Insert";
            this.InsertButton.UseVisualStyleBackColor = true;
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 217);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(89, 20);
            this.numericUpDown1.TabIndex = 6;
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(107, 272);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(56, 23);
            this.Remove.TabIndex = 7;
            this.Remove.Text = "Remove";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // RemoveAtButton
            // 
            this.RemoveAtButton.Location = new System.Drawing.Point(169, 272);
            this.RemoveAtButton.Name = "RemoveAtButton";
            this.RemoveAtButton.Size = new System.Drawing.Size(70, 23);
            this.RemoveAtButton.TabIndex = 8;
            this.RemoveAtButton.Text = "Remove at";
            this.RemoveAtButton.UseVisualStyleBackColor = true;
            this.RemoveAtButton.Click += new System.EventHandler(this.RemoveAtButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(169, 242);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(70, 23);
            this.ClearButton.TabIndex = 9;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click_1);
            // 
            // ShowCheckedButton
            // 
            this.ShowCheckedButton.Location = new System.Drawing.Point(12, 301);
            this.ShowCheckedButton.Name = "ShowCheckedButton";
            this.ShowCheckedButton.Size = new System.Drawing.Size(89, 23);
            this.ShowCheckedButton.TabIndex = 10;
            this.ShowCheckedButton.Text = "Show Checked";
            this.ShowCheckedButton.UseVisualStyleBackColor = true;
            this.ShowCheckedButton.Click += new System.EventHandler(this.ShowCheckedButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 358);
            this.Controls.Add(this.ShowCheckedButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.RemoveAtButton);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.InsertButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ClearSelectedButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button ClearSelectedButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button InsertButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.Button RemoveAtButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button ShowCheckedButton;
    }
}

