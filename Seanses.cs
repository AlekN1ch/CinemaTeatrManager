using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaTeatrManager
{

    public partial class Seanses : Form
    {
        public Seanses()
        {
            InitializeComponent();
        }
        public static List<Seans> seanses = new List<Seans>();
        private void Seanses_Load(object sender, EventArgs e)
        {
            button1.Visible = Form1.accesAdmin;
            Maker();

        }
        public void Maker()
        {
            foreach (var item in seanses)
            {
                System.Windows.Forms.Label name = new System.Windows.Forms.Label();
                System.Windows.Forms.Label time = new System.Windows.Forms.Label();
                PictureBox poster = new PictureBox();
                Button button = new Button();
                Font font = new Font("Segoe Print", 10);
                name.Text =item.name;
                name.Font = font;
                time.Text =item.time;
                time.Font = font;
                poster.Image = item.image;
                poster.Size = new Size(320, 300);
                poster.SizeMode = PictureBoxSizeMode.StretchImage;
                button.Font = font;
                button.Text = "Купить билет";
                button.Size = new Size(100, 100);
                button.BackColor = Color.Firebrick;
                button.Click += new EventHandler(button_Click);
                flowLayoutPanel2.Controls.Add(name);
                flowLayoutPanel2.Controls.Add(time);
                flowLayoutPanel2.Controls.Add(poster);
                flowLayoutPanel2.Controls.Add(button);


            }
            if (flowLayoutPanel2.Controls.Count == 0) { label1.Visible = true; label1.Text = "Нет доступных сеансов"; }
            else { label1.Visible = false; }
        }

        private void button_Click(object sender, EventArgs e)
        {
            BuyTicket ticket = new BuyTicket();
            BuyTicket.index = flowLayoutPanel2.Controls.IndexOf(sender as Control);
            ticket.Show();

        }
        private void button1_Click(object sender, EventArgs e)
        {

            NewSeans newSeans = new NewSeans();
            newSeans.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Seanses_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
    public class Seans
    {
        public string name, time;
        public Image image;
        public bool[] enabled = new bool[100];
        public List<bool> enabledList = new List<bool>();

        public void Start()
        {

            for (int i = 0; i < enabled.Length; i++)
            {
                enabled[i] = true;
                enabledList.Clear();
                enabledList.Add(enabled[i]);
            }
        }
        public void ChangeStats(int ind, bool var)
        {
            enabled[ind] = var;

        }
        public Seans(string Name, string Time, Image Poster)
        {
            name = Name;
            time = Time;
            image = Poster;
            Start();
        }

    }
}
