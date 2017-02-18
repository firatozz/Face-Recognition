using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YuzTanima
{
    public partial class hakkinda : Form
    {
        //string revision;
        public string revision { get; set; }


        public hakkinda()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            //pb_about.Image = Image.FromFile(@"C:\BotBrain\EZ-Face\Resources\BotBrain.jpg");
            label3.Text = revision;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("");
        }

        private void btn_about_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

    }
}
