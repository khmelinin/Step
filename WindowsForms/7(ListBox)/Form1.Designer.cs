namespace _7_ListBox_
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonClearListBox = new System.Windows.Forms.Button();
            this.buttonClearSelected = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonClearSelected2 = new System.Windows.Forms.Button();
            this.buttonClearList2 = new System.Windows.Forms.Button();
            this.buttonCopySelected = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 63);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(157, 264);
            this.listBox1.TabIndex = 0;
            // 
            // buttonClearListBox
            // 
            this.buttonClearListBox.Location = new System.Drawing.Point(12, 23);
            this.buttonClearListBox.Name = "buttonClearListBox";
            this.buttonClearListBox.Size = new System.Drawing.Size(59, 23);
            this.buttonClearListBox.TabIndex = 1;
            this.buttonClearListBox.Text = "Clear List Box";
            this.buttonClearListBox.UseVisualStyleBackColor = true;
            this.buttonClearListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonClearListBox_MouseClick);
            // 
            // buttonClearSelected
            // 
            this.buttonClearSelected.Location = new System.Drawing.Point(77, 23);
            this.buttonClearSelected.Name = "buttonClearSelected";
            this.buttonClearSelected.Size = new System.Drawing.Size(92, 23);
            this.buttonClearSelected.TabIndex = 2;
            this.buttonClearSelected.Text = "Clear Selected";
            this.buttonClearSelected.UseVisualStyleBackColor = true;
            this.buttonClearSelected.Click += new System.EventHandler(this.buttonClearSelected_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(12, 365);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(12, 394);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 4;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(175, 90);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(75, 55);
            this.buttonCopy.TabIndex = 5;
            this.buttonCopy.Text = "Clear and Copy Selected ->";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(256, 63);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox2.Size = new System.Drawing.Size(163, 264);
            this.listBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 339);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 20);
            this.textBox1.TabIndex = 7;
            // 
            // buttonClearSelected2
            // 
            this.buttonClearSelected2.Location = new System.Drawing.Point(327, 23);
            this.buttonClearSelected2.Name = "buttonClearSelected2";
            this.buttonClearSelected2.Size = new System.Drawing.Size(92, 23);
            this.buttonClearSelected2.TabIndex = 8;
            this.buttonClearSelected2.Text = "Clear Selected";
            this.buttonClearSelected2.UseVisualStyleBackColor = true;
            this.buttonClearSelected2.Click += new System.EventHandler(this.buttonClearSelected2_Click);
            // 
            // buttonClearList2
            // 
            this.buttonClearList2.Location = new System.Drawing.Point(256, 23);
            this.buttonClearList2.Name = "buttonClearList2";
            this.buttonClearList2.Size = new System.Drawing.Size(59, 23);
            this.buttonClearList2.TabIndex = 9;
            this.buttonClearList2.Text = "Clear List Box";
            this.buttonClearList2.UseVisualStyleBackColor = true;
            this.buttonClearList2.Click += new System.EventHandler(this.buttonClearList2_Click);
            // 
            // buttonCopySelected
            // 
            this.buttonCopySelected.Location = new System.Drawing.Point(175, 160);
            this.buttonCopySelected.Name = "buttonCopySelected";
            this.buttonCopySelected.Size = new System.Drawing.Size(75, 47);
            this.buttonCopySelected.TabIndex = 10;
            this.buttonCopySelected.Text = "Copy Selected ->";
            this.buttonCopySelected.UseVisualStyleBackColor = true;
            this.buttonCopySelected.Click += new System.EventHandler(this.buttonCopySelected_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCopySelected);
            this.Controls.Add(this.buttonClearList2);
            this.Controls.Add(this.buttonClearSelected2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonClearSelected);
            this.Controls.Add(this.buttonClearListBox);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonClearListBox;
        private System.Windows.Forms.Button buttonClearSelected;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonClearSelected2;
        private System.Windows.Forms.Button buttonClearList2;
        private System.Windows.Forms.Button buttonCopySelected;
    }
}

