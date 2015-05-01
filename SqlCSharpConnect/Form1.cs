using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlGiris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection("server=.;database=Students;integrated security=sspi;");

        private void showDatas()
        {
            connect.Open();

            SqlCommand command = new SqlCommand("select * from tblInformations",connect);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ListViewItem row = new ListViewItem(reader["studentName"].ToString());
                row.SubItems.Add(reader["studentSurname"].ToString());
                row.SubItems.Add(reader["city"].ToString());
                row.SubItems.Add(reader["school"].ToString());

                listView1.Items.Add(row);
                

            }
            connect.Close();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            showDatas();
        }
    }
}
