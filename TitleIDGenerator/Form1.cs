using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace TitleIDGenerator
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
        }

        private void aboutThisProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            string tid = "0x";

            for(int i = 0; i < 16; i++)
            {
                tid += random.Next(0, 10);
            }
            textBox1.Text = tid;
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Clipboard.SetText(textBox1.Text);
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Coppied to clipboard!");
            }
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                About about = new About();
                about.Show();
            }

            if (e.KeyCode == Keys.Control || e.KeyCode == Keys.C)
            {
                if (textBox1.Text != "")
                {
                    Clipboard.SetText(textBox1.Text);
                    System.Media.SystemSounds.Beep.Play();
                    MessageBox.Show("Coppied to clipboard!");
                }
            }

        }

        private void copyCTRLCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Clipboard.SetText(textBox1.Text);
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Coppied to clipboard!");
            }
        }
    }
}
