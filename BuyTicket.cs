using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaTeatrManager
{
    public partial class BuyTicket : Form
    {
        public BuyTicket()
        {
            InitializeComponent();
        }
        public void Maker()
        {
            for (int i = 0; i < 99; i++)
            {
                Button button = new Button();
                button.Text = i.ToString();
                button.Size = new Size(40, 40);
                Font font = new Font("Segoe Print",10);
                button.Font = font;
                button.BackColor = Color.Firebrick;
                button.Click += new EventHandler(button_Click);
                buttons.Add(button);
                flowLayoutPanel1.Controls.Add(button);
                flowLayoutPanel1.AutoScroll = true;
            }
            CheckSeans();
            
                for (int i = 0; i < buttons.Count; i++)
                { buttons[i].Enabled = Seanses.seanses.ElementAt(indSeans-1).enabled[i]; }
            
        }
       public List<Button> buttons= new List<Button>();
        public int indSeans;
        public static int index;
        public void CheckSeans()
        {
            index++;
            indSeans = index / 4;
        }
        private void button_Click(object sender, EventArgs e)
        {
            CheckSeans();
            int PlaceInd = flowLayoutPanel1.Controls.IndexOf(sender as Control);
            buttons[PlaceInd].Enabled = false;
            buttons[PlaceInd].BackColor = Color.Maroon;
        }
        private void BuyTicket_Load(object sender, EventArgs e)
        {
            Maker();
        }
    }
}
