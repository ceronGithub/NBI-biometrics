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

namespace NBI
{
    public partial class Form2 : Form
    {

        string connetionString = "Server=localhost;database=ht_iris;uid=root;pwd=password;";
        //string connetionString = "Server=localhost;database=ht_iris;uid=root;pwd=;";

        // variables
        int dataColumn;

        DataTable dt;
        QueryCRUD crud = new QueryCRUD();
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            buttonUpdate.Visible = true;
        }

        private void buttonShowRecord_Click(object sender, EventArgs e)
        {
            bool isDBConnectionOpen;

            isDBConnectionOpen = crud.testConnection();

            try
            {
                if (isDBConnectionOpen == true)
                {
                    string query = "SELECT * FROM users";
                    using (MySqlConnection conn = new MySqlConnection(connetionString))
                    {
                        using (MySqlCommand command = new MySqlCommand(query, conn))
                        {

                            conn.Open();
                            MySqlDataReader mysqlDataReader = command.ExecuteReader();
                            dt = new DataTable();
                            dt.Load(mysqlDataReader);
                            ListOfUsersDataGridView.DataSource = dt;
                            textBox1.Enabled = true;
                            buttonUpdate.Enabled = true;
                            conn.Close();

                            //count the columns of the datagridview
                            dataColumn = this.ListOfUsersDataGridView.Columns.Count;
                            for (int item = 0; item <= ListOfUsersDataGridView.Rows.Count - 1; item++)
                            {
                                // make columns readonly
                                ListOfUsersDataGridView.Columns[0].ReadOnly = true;
                                if (dataColumn > 10)
                                {
                                    ListOfUsersDataGridView.Columns[11].ReadOnly = true;
                                    ListOfUsersDataGridView.Columns[12].ReadOnly = true;
                                    ListOfUsersDataGridView.Columns[13].ReadOnly = true;
                                    ListOfUsersDataGridView.Columns[14].ReadOnly = true;
                                    ListOfUsersDataGridView.Columns[15].ReadOnly = true;
                                    ListOfUsersDataGridView.Columns[16].ReadOnly = true;
                                    ListOfUsersDataGridView.Columns[17].ReadOnly = true;
                                    ListOfUsersDataGridView.Columns[18].ReadOnly = true;
                                    ListOfUsersDataGridView.Columns[19].ReadOnly = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Something is wrong in database connection!.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something is wrong in database connection!.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string checkUpdateStatus = "";
            for (int item = 0; item <= ListOfUsersDataGridView.Rows.Count - 1; item++)
            {
                checkUpdateStatus = crud.updateUserInformation(ListOfUsersDataGridView.Rows[item].Cells[0].Value.ToString(), ListOfUsersDataGridView.Rows[item].Cells[1].Value.ToString(),
                    ListOfUsersDataGridView.Rows[item].Cells[2].Value.ToString(), ListOfUsersDataGridView.Rows[item].Cells[3].Value.ToString(),
                    ListOfUsersDataGridView.Rows[item].Cells[4].Value.ToString(), ListOfUsersDataGridView.Rows[item].Cells[5].Value.ToString(),
                    ListOfUsersDataGridView.Rows[item].Cells[6].Value.ToString(), ListOfUsersDataGridView.Rows[item].Cells[7].Value.ToString(),
                    ListOfUsersDataGridView.Rows[item].Cells[8].Value.ToString(), ListOfUsersDataGridView.Rows[item].Cells[9].Value.ToString(),
                    ListOfUsersDataGridView.Rows[item].Cells[10].Value.ToString(), ListOfUsersDataGridView.Rows[item].Cells[11].Value.ToString(),
                    ListOfUsersDataGridView.Rows[item].Cells[12].Value.ToString(), ListOfUsersDataGridView.Rows[item].Cells[13].Value.ToString(),
                    ListOfUsersDataGridView.Rows[item].Cells[14].Value.ToString(), ListOfUsersDataGridView.Rows[item].Cells[15].Value.ToString(),
                    ListOfUsersDataGridView.Rows[item].Cells[16].Value.ToString(), ListOfUsersDataGridView.Rows[item].Cells[17].Value.ToString(),
                    ListOfUsersDataGridView.Rows[item].Cells[18].Value.ToString(), ListOfUsersDataGridView.Rows[item].Cells[19].Value.ToString());
            }
            if (checkUpdateStatus == "success")
            {
                MessageBox.Show("Record has been updated");
            }
            else
            {
                MessageBox.Show("Failed to update record");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            //dv.RowFilter = "firstname like '%"+ textBox1.Text +"%' OR";
            dv.RowFilter = string.Format("firstname like '%{0}%' OR middlename like '%{1}%' OR lastname like '%{2}%'", textBox1.Text, textBox1.Text, textBox1.Text);
        }
    }
}
