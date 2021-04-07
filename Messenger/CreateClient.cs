using System;
using System.Windows.Forms;
using MessengerClient;

namespace Messenger
{
    public partial class CreateClient : Form
    {
        public CreateClient()
        {
            InitializeComponent();
            CenterToScreen();
            this.FormClosing += CreateClient_FormClosing;
        }

        private void connect_button_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            int err = client.Connect(IpBox.Text, 45455, PassBox.Text, UsernameBox.Text);
            if(err == 1)
            {
                MessageBox.Show("Failed to Connect to the server!", "Failed to connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(err == 2)
            {
                MessageBox.Show("Wrong password!", "Wrong password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(err == 3)
            {
                MessageBox.Show("No room left to join in the server!", "No room", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(err == 4)
            {
                MessageBox.Show("This name is available in the server!", "Name available", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessengerWindow.ip_address = IpBox.Text;
                MessengerWindow.client = client;
                MessengerWindow.username = UsernameBox.Text;
                MessengerWindow.isadmin = false;
                MessengerWindow.password = PassBox.Text;

                this.Hide();
                var Messenger = new MessengerWindow();
                Messenger.Closed += (s, args) => this.Close();
                Messenger.Show();
            }
        }

        private void CreateClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            var Entry = new Entry();
            Entry.Closed += (s, args) => this.Close();
            Entry.Show();
        }
    }
}
