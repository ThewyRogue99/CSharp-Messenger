using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Messenger
{
    public partial class Entry : Form
    {
        public Entry()
        {
            InitializeComponent();
            this.FormClosing += Entry_FormClosing;
            CenterToScreen();
            MaximizeBox = false;
        }

        private void Entry_Load(object sender, EventArgs e)
        {
        }

        private void connect_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            var createClient = new CreateClient();
            createClient.Closed += (s, args) => this.Close();
            createClient.Show();
        }

        private void create_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            var CreateServer = new CreateServer();
            CreateServer.Closed += (s, args) => this.Close();
            CreateServer.Show();
        }

        private void Entry_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
