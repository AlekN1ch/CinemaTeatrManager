﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaTeatrManager
{
    public partial class NewSeans : Form
    {
        public NewSeans()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Seanses.seanses.Add(new Seans(textBox1.Text,textBox2.Text,pictureBox1.Image));
            Seanses seanses = new Seanses();
            seanses.Show();
            this.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            { return; }
            string fileName = openFileDialog1.FileName;
            try
            {
                Image image = Image.FromFile(fileName);
                pictureBox1.Image = image;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch { MessageBox.Show("Тип файла не соответствует требуемому"); }

        }
    }
}
