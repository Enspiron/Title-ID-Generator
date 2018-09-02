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
using System.Net.Http;
using System.Net;
using System.Collections.Specialized;

namespace TitleIDGenerator
{
    public partial class Main : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private static string url = "http://127.0.0.1/submitApplication.php";
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
            string tid = "0x0100";

            for(int i = 0; i < 12; i++)
            {
                tid += random.Next(0, 10);
            }
            tbGeneratedId.Text = tid;
            btnSubmit.Enabled = true;
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            if (tbGeneratedId.Text != "")
            {
                Clipboard.SetText(tbGeneratedId.Text);
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
                if (tbGeneratedId.Text != "")
                {
                    Clipboard.SetText(tbGeneratedId.Text);
                    System.Media.SystemSounds.Beep.Play();
                    MessageBox.Show("Coppied to clipboard!");
                }
            }

        }

        private void copyCTRLCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tbGeneratedId.Text != "")
            {
                Clipboard.SetText(tbGeneratedId.Text);
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Coppied to clipboard!");
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["appName"] =   tbAppName.Text;
                data["appID"]   =   tbGeneratedId.Text;
                data["website"] =   tbWebsite.Text;
                data["hbtype"]  =   cbHBType.SelectedIndex.ToString();
                data["version"] =   tbVersion.Text;

                try
                {
                    var response = wb.UploadValues(url, "POST", data);
                    toolStripStatusLabel1.Text = Encoding.UTF8.GetString(response);
                }
                catch(Exception ex)
                {
                    toolStripStatusLabel1.Text = ex.Message;
                }
            }

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
