using System;
using System.Windows.Forms;
using MessengerServer;

namespace Messenger
{
    public partial class CreateServer : Form
    {
        public CreateServer()
        {
            InitializeComponent();
            this.FormClosing += CreateServer_FormClosing;
        }

        private void CreateServer_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            MaximizeBox = false;
        }

        private void confirm_pass_Click(object sender, EventArgs e)
        {
            if(ServerPass.Text == "")
            {
                MessageBox.Show("You need to enter a key for the server", "No Key Entered", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (UsernameBox.Text == "")
                MessengerWindow.username = "Admin";
            else
                MessengerWindow.username = UsernameBox.Text;

            Server server = new Server(Server.GetLocalIPAddress(), 45455);

            int error = server.CreateServer(int.Parse(Max_Person.Text), ServerPass.Text);
            if(error == 1)
            {
                MessageBox.Show("No internet connection detected", "No Internet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(error == 2)
            {
                MessageBox.Show("Failed to create a server", "Failed to create a server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessengerWindow.server = server;
                MessengerWindow.isadmin = true;
                MessengerWindow.password = ServerPass.Text;

                this.Hide();
                var Messenger = new MessengerWindow();
                Messenger.Closed += (s, args) => this.Close();
                Messenger.Show();
            }
        }

        private void CreateServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            var Entry = new Entry();
            Entry.Closed += (s, args) => this.Close();
            Entry.Show();
        }
    }
}
