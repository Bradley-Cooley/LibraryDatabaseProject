namespace LibraryDatabaseProject
{
    partial class AddMovie
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.insertBookButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.directorTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.ratingComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.durationTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(37, 243);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(135, 23);
            this.cancelButton.TabIndex = 25;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancel);
            // 
            // insertBookButton
            // 
            this.insertBookButton.Location = new System.Drawing.Point(184, 243);
            this.insertBookButton.Name = "insertBookButton";
            this.insertBookButton.Size = new System.Drawing.Size(135, 23);
            this.insertBookButton.TabIndex = 24;
            this.insertBookButton.Text = "Add to Database";
            this.insertBookButton.UseVisualStyleBackColor = true;
            this.insertBookButton.Click += new System.EventHandler(this.insertMovie);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "New Movie Information";
            // 
            // directorTextBox
            // 
            this.directorTextBox.Location = new System.Drawing.Point(111, 85);
            this.directorTextBox.Name = "directorTextBox";
            this.directorTextBox.Size = new System.Drawing.Size(200, 20);
            this.directorTextBox.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Director";
            // 
            // genreComboBox
            // 
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(111, 111);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(200, 21);
            this.genreComboBox.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Genre";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(111, 59);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(200, 20);
            this.titleTextBox.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Release Date";
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(111, 192);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 20);
            this.datePicker.TabIndex = 13;
            // 
            // ratingComboBox
            // 
            this.ratingComboBox.FormattingEnabled = true;
            this.ratingComboBox.Location = new System.Drawing.Point(111, 138);
            this.ratingComboBox.Name = "ratingComboBox";
            this.ratingComboBox.Size = new System.Drawing.Size(200, 21);
            this.ratingComboBox.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "MPAA Rating";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(58, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Duration";
            // 
            // durationTextBox
            // 
            this.durationTextBox.Location = new System.Drawing.Point(111, 166);
            this.durationTextBox.Name = "durationTextBox";
            this.durationTextBox.Size = new System.Drawing.Size(200, 20);
            this.durationTextBox.TabIndex = 29;
            // 
            // AddMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 287);
            this.Controls.Add(this.durationTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ratingComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.insertBookButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.directorTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.genreComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datePicker);
            this.Name = "AddMovie";
            this.Text = "AddMovie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button insertBookButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox directorTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox genreComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.ComboBox ratingComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox durationTextBox;
    }
}