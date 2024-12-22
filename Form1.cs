using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CinemaTeatrManager
{
    public partial class Form1 : Form
    {
        public static string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source = Autorization.accdb";
        private OleDbConnection myConnection;

        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();

        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "1")
            {
                accesAdmin = true;
                Seanses seanses = new Seanses();
                seanses.ShowDialog();
                
            }
            else { MessageBox.Show("В доступе отказано"); }

        }
        public static bool accesAdmin=false;
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in logins)
            {
                if (textBox1.Text == item)
                {
                    foreach (var item2 in passwords)
                    {
                        if (textBox2.Text == item2)
                        {
                            Seanses seanses = new Seanses();
                            seanses.ShowDialog();
                            accesAdmin = false;
                           
                            break;
                        }
                        else { MessageBox.Show("Неверный пароль"); }
                    }

                }
                else
                {
                    MessageBox.Show("Неверный логин");
                }
            }
        }
        public List<string> logins = new List<string>();
        public List<string> passwords = new List<string>();
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "autorizationDataSet.autorizationTable". При необходимости она может быть перемещена или удалена.
            this.autorizationTableTableAdapter.Fill(this.autorizationDataSet.autorizationTable);
            string query = "SELECT login FROM autorizationTable ORDER BY Код";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            logins.Clear();
            while (reader.Read())
            {
                logins.Add(reader[0].ToString());
            }
            reader.Close();
            string query1 = "SELECT password FROM autorizationTable ORDER BY Код";
            OleDbCommand command1 = new OleDbCommand(query1, myConnection);
            OleDbDataReader reader1 = command1.ExecuteReader();
            passwords.Clear();
            while (reader1.Read())
            {
                passwords.Add(reader1[0].ToString());
            }
            reader1.Close();
            

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var i in logins)
            {
                if (textBox1.Text == i) MessageBox.Show("Логин уже зарегистрирован");
                else {
                    string query = "INSERT INTO autorizationTable ([login],[password]) VALUES " + "('" + textBox1.Text + "','" + textBox2.Text + "')";
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Регистрация прошла успешно");
                }
            }
        }
    }
}
