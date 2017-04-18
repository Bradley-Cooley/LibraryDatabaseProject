namespace LibraryDatabaseProject
{
    partial class AddMusicAlbum
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
            this.label4 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.insertBookButton = new System.Windows.Forms.Button();
            this.artistTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.numTracksTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Num. Tracks";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(31, 242);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(135, 23);
            this.cancelButton.TabIndex = 39;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancel);
            // 
            // insertBookButton
            // 
            this.insertBookButton.Location = new System.Drawing.Point(178, 242);
            this.insertBookButton.Name = "insertBookButton";
            this.insertBookButton.Size = new System.Drawing.Size(135, 23);
            this.insertBookButton.TabIndex = 38;
            this.insertBookButton.Text = "Add to Database";
            this.insertBookButton.UseVisualStyleBackColor = true;
            this.insertBookButton.Click += new System.EventHandler(this.insertMusicAlbum);
            // 
            // artistTextBox
            // 
            this.artistTextBox.Location = new System.Drawing.Point(104, 100);
            this.artistTextBox.Name = "artistTextBox";
            this.artistTextBox.Size = new System.Drawing.Size(200, 20);
            this.artistTextBox.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 36;
            this.label5.Text = "Artist";
            // 
            // genreComboBox
            // 
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(104, 126);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(200, 21);
            this.genreComboBox.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Genre";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(104, 74);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(200, 20);
            this.titleTextBox.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Release Date";
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(104, 181);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(200, 20);
            this.datePicker.TabIndex = 30;
            // 
            // numTracksTextBox
            // 
            this.numTracksTextBox.Location = new System.Drawing.Point(104, 154);
            this.numTracksTextBox.Name = "numTracksTextBox";
            this.numTracksTextBox.Size = new System.Drawing.Size(200, 20);
            this.numTracksTextBox.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "New Music Album Information";
            // 
            // AddMusicAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 296);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numTracksTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.insertBookButton);
            this.Controls.Add(this.artistTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.genreComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datePicker);
            this.Name = "AddMusicAlbum";
            this.Text = "AddMusicAlbum";
            this.Load += new System.EventHandler(this.onLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button insertBookButton;
        private System.Windows.Forms.TextBox artistTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox genreComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.TextBox numTracksTextBox;
        private System.Windows.Forms.Label label6;
    }
}