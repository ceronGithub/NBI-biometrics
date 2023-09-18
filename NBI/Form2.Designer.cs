namespace NBI
{
    partial class Form2
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
            ListOfUsersDataGridView = new DataGridView();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            buttonShowRecord = new Button();
            buttonUpdate = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)ListOfUsersDataGridView).BeginInit();
            SuspendLayout();
            // 
            // ListOfUsersDataGridView
            // 
            ListOfUsersDataGridView.AllowUserToAddRows = false;
            ListOfUsersDataGridView.AllowUserToDeleteRows = false;
            ListOfUsersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ListOfUsersDataGridView.Location = new Point(12, 12);
            ListOfUsersDataGridView.Name = "ListOfUsersDataGridView";
            ListOfUsersDataGridView.RowTemplate.Height = 25;
            ListOfUsersDataGridView.Size = new Size(980, 382);
            ListOfUsersDataGridView.TabIndex = 0;            
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // buttonShowRecord
            // 
            buttonShowRecord.Location = new Point(108, 400);
            buttonShowRecord.Name = "buttonShowRecord";
            buttonShowRecord.Size = new Size(165, 38);
            buttonShowRecord.TabIndex = 1;
            buttonShowRecord.Text = "Show Record";
            buttonShowRecord.UseVisualStyleBackColor = true;
            buttonShowRecord.Click += buttonShowRecord_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Enabled = false;
            buttonUpdate.Location = new Point(714, 400);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(165, 38);
            buttonUpdate.TabIndex = 2;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(321, 412);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 3;
            label1.Text = "Search :";
            // 
            // textBox1
            // 
            textBox1.Enabled = false;
            textBox1.Location = new Point(375, 409);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(316, 23);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1011, 450);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonShowRecord);
            Controls.Add(ListOfUsersDataGridView);
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LIST OF USERS";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)ListOfUsersDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView ListOfUsersDataGridView;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private Button buttonShowRecord;
        private Button buttonUpdate;
        private Label label1;
        private TextBox textBox1;
    }
}