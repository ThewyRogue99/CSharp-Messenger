using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using MessengerServer;
using MessengerClient;
using Manager;
using System.IO;
using System.Net;
using System.Reflection;
using Crypto;
using System.Diagnostics;

namespace Messenger
{
    public partial class MessengerWindow : Form
    {
        public static string password;
        public bool threadcancel = false;
        public static string username;
        public static string ip_address;
        public static Server server;
        public static Client client;
        public static bool isadmin;
        public static List<Socket> connectedClient = new List<Socket>();
        public string filepath;
        public MessengerWindow()
        {
            InitializeComponent();
            CenterToScreen();
            this.FormClosing += MessengerWindow_FormClosing;
        }

        private void MessengerWindow_Load(object sender, EventArgs e)
        {
            MinimumSize = this.Size;
            if (isadmin)
            {
                join_room_button.Text = "Create Video Room";
                Message_Box.Text = "Server successfully created with ip: " + Server.GetIPAddress();
                Thread accept_user = new Thread(new ThreadStart(AcceptUser));
                accept_user.Start();
                kick_button.Enabled = true;
                Thread kickcheck = new Thread(new ThreadStart(activatekick));
                kickcheck.Start();
                if (username == "Admin")
                    AddMember(username);
                else
                    AddMember(username + "(Admin)");
            }
            else
            {
                join_room_button.Text = "Join Video Room";
                Message_Box.Text = "Successfully connected to the server";
                Thread client_thread = new Thread(new ThreadStart(ClientThread));
                client_thread.Start();
            }
            Thread typeinf = new Thread(new ThreadStart(typetester));
            typeinf.Start();
        }

        public void AcceptUser()
        {
            Socket clientSocket;
            while (true)
            {
                string user = "";
                try
                {
                    clientSocket = server.Accept(ref user, ref connectedClient, ref Members);
                }
                catch
                {
                    break;
                }
                connectedClient.Add(clientSocket);
                Thread clientThread = new Thread(new ThreadStart(() =>
                User(clientSocket, user)));
                clientThread.Start();
            }
        }

        public void ClientThread()
        {
            while (!threadcancel)
            {
                MessageManager msg = new MessageManager();
                msg = client.ClientSocket.ReceiveMessage(password);
                if (msg == null)
                {
                    CloseMessenger();
                    break;
                }
                if (msg.type == "text")
                {
                    AppendTextBox(msg.username + ": " + msg.message);
                }
                else if (msg.type == "MemInf")
                {
                    Members.Invoke((Action)delegate { Members.Items.Clear(); });
                    foreach (string name in msg.clients)
                    {
                        AddMember(name);
                    }
                }
                else if (msg.type == "JoinInf")
                {
                    if (msg.username != username)
                    {
                        AddMember(msg.username);
                        AppendTextBox(msg.username + " joined");
                    }
                }
                else if (msg.type == "LeftInf")
                {
                    AppendTextBox(msg.username + " left");
                    RemoveMember(msg.username);
                }
                else if (msg.type == "KickUser")
                {
                    if (msg.username == username)
                    {
                        MessageBox.Show("You are kicked by admin!", "Kicked by Admin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        FormClosingEventArgs e = new FormClosingEventArgs(CloseReason.ApplicationExitCall, false);
                        CloseMessenger();
                        break;
                    }
                    else
                        AppendTextBox(msg.username + " is kicked by admin");
                }
                else if (msg.type == "Error")
                {
                    if (msg.message == "ServExit")
                    {
                        MessageBox.Show("Server disconnected!", "Server Disconnected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CloseMessenger();
                    }
                    else if (msg.message == "RecvFail")
                    {
                        AppendTextBox("Corrupted message received");
                    }
                }
                else if (msg.type == "UserType")
                {
                    if (msg.typestatus && msg.username != username)
                        typelabel.Invoke((Action)delegate { typelabel.Text = msg.username + " is typing..."; });
                    else
                        typelabel.Invoke((Action)delegate { typelabel.Text = ""; });
                }
                else if (msg.type == "FileSend" && msg.username != username)
                {
                    File.WriteAllBytes(msg.filename, msg.sendfile);
                    string currentdir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                    AppendTextBox("\r\n" + msg.username + ": File " + msg.filename + " saved at " + currentdir);
                }
                Thread.Sleep(100);
            }
        }

        public void User(Socket client, string user)
        {
            AppendTextBox(user + " joined");
            AddMember(user);
            sendmembers(client);
            Thread.Sleep(100);
            sendjoininf(user);
            while (true)
            {
                MessageManager message = new MessageManager();
                message = client.ReceiveMessage(password);
                if (message == null)
                {
                    AppendTextBox(user + " left");
                    RemoveMember(user);
                    connectedClient.Remove(client);
                    client.Close();
                    MessageManager leftinf = new MessageManager();
                    leftinf.CreateLeftInf(user);
                    sendall(leftinf);
                    break;
                }
                if (message.type == "text")
                {
                    AppendTextBox(user + ": " + message.message);
                }
                else if (message.type == "UserType")
                {
                    if (message.typestatus && message.username != username)
                        typelabel.Invoke((Action)delegate { typelabel.Text = message.username + " is typing..."; });
                    else
                        typelabel.Invoke((Action)delegate { typelabel.Text = ""; });
                }
                else if (message.type == "FileSend")
                {
                    File.WriteAllBytes(message.filename, message.sendfile);
                    string currentdir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                    AppendTextBox(message.username + ": File " + message.filename + " saved at " + currentdir);
                }

                sendall(message);
                Thread.Sleep(100);
            }
        }

        public bool isempty(string text)
        {
            if (text == "")
                return true;

            for (int i = 0; i < text.Length; i++)
            {
                if (!char.IsWhiteSpace(text[i]))
                    return false;
            }
            return true;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs key)
        {
            if (key.KeyCode == Keys.Enter && !isempty(textBox2.Text))
            {
                MessageManager message = new MessageManager();
                message.CreateText(textBox2.Text, username);
                if (isadmin)
                {
                    AppendTextBox(username + ": " + textBox2.Text);
                    sendall(message);
                }
                else
                {
                    client.ClientSocket.SendMessage(message, password);
                }
                textBox2.Text = "";
                key.SuppressKeyPress = true; //stop error voice
            }
            else if (key.KeyCode == Keys.Enter)
                textBox2.Text = "";
        }

        static void RestartApp()
        {
            Process process;
            process = Process.GetCurrentProcess();
            process.WaitForExit(1000);
            Process.Start("Messenger.exe", "");
            Environment.Exit(1);
        }

        public void CloseMessenger()
        {
            threadcancel = true;
            if (isadmin)
            {
                server.Close();
                MessageManager msg = new MessageManager();
                msg.CreateError("ServExit");
                sendall(msg);
            }
            else
                client.Close();
            //RestartApp();
            Invoke((Action)delegate { Hide(); });
            var Entry = new Entry();
            Entry.Closed += (s, args) => Invoke((Action)delegate { Close(); });
            Entry.Show();
        }

        public void typetester()
        {
            int calls = 0;
            while (!threadcancel)
            {
                if (textBox2.Text != "" && calls == 0)
                {
                    ++calls;
                    MessageManager type = new MessageManager();
                    type.CreateTyping(username, true);
                    if (isadmin)
                    {
                        sendall(type);
                    }
                    else
                    {
                        client.ClientSocket.SendMessage(type, password);
                    }
                }
                else if (textBox2.Text == "" && calls == 1)
                {
                    --calls;
                    MessageManager type = new MessageManager();
                    type.CreateTyping(username, false);
                    if (isadmin)
                    {
                        sendall(type);
                    }
                    else
                    {
                        client.ClientSocket.SendMessage(type, password);
                    }
                }
                Thread.Sleep(50);
            }
        }

        public void sendall(MessageManager message)
        {
            foreach (Socket clientSocket in connectedClient)
            {
                try
                {
                    clientSocket.SendMessage(message, password);
                }
                catch
                {
                    connectedClient.Remove(clientSocket);
                    continue;
                }
            }
        }

        public void sendjoininf(string name)
        {
            MessageManager joininf = new MessageManager();
            joininf.CreateJoinInf(name);
            sendall(joininf);
        }

        public void sendmembers(Socket client)
        {
            MessageManager members = new MessageManager();
            List<string> memberlist = new List<string>();
            foreach (string member in Members.Items)
            {
                memberlist.Add(member);
            }
            members.CreateMemInf(memberlist);
            client.SendMessage(members, password);
        }

        private void MessengerWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            CloseMessenger();
        }

        public void activatekick()
        {
            while (isadmin && !threadcancel)
            {
                int index = 0;
                Members.Invoke((Action)delegate { index = Members.SelectedIndex; });
                if (index > 0)
                {
                    kick_button.Invoke((Action)delegate { kick_button.Enabled = true; });
                }
                else
                    kick_button.Invoke((Action)delegate { kick_button.Enabled = false; });
                Thread.Sleep(50);
            }
        }

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            Message_Box.AppendText("\r\n" + value);
        }
        public void AddMember(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AddMember), new object[] { value });
                return;
            }
            Members.Items.Add(value);
        }

        public void RemoveMember(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(RemoveMember), new object[] { value });
                return;
            }
            Members.Items.Remove(value);
        }

        public void KickUser(string username)
        {
            MessageManager kick = new MessageManager();
            kick.CreateKick(username);
            sendall(kick);
        }

        private void info_button_Click(object sender, EventArgs e)
        {
            string ip = "";
            if (isadmin)
                ip = Server.GetIPAddress();
            else
                ip = client.EndPoint;

            MessageBox.Show("Server ip: " + ip + "\nServer password: " + password, "Server Info");
        }

        private void kick_button_Click(object sender, EventArgs e)
        {
            string user = Members.Items[Members.SelectedIndex].ToString();
            KickUser(user);
            AppendTextBox(user + " is kicked by admin");
        }

        private void selectfile_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();

            if (OFD.ShowDialog() == DialogResult.OK)
            {
                filepath = OFD.FileName;
                if (File.ReadAllBytes(filepath).Length > 5000000)
                {
                    MessageBox.Show("File size cannot be bigger than 5MB", "Large File Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    filepath = "";
                    return;
                }
                selectedfile_label.Text = OFD.SafeFileName;
                sendfile_button.Enabled = true;
            }
        }

        private void sendfile_button_Click(object sender, EventArgs e)
        {
            try
            {
                File.ReadAllBytes(filepath);
            }
            catch
            {
                MessageBox.Show("Failed to read file", "Failed to read file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                selectedfile_label.Text = "";
                sendfile_button.Enabled = false;
                filepath = "";
                return;
            }
            byte[] file = File.ReadAllBytes(filepath);
            MessageManager filemsg = new MessageManager();
            filemsg.CreateFileSend(username, file, Path.GetFileName(filepath));
            if (isadmin)
            {
                sendall(filemsg);
                AppendTextBox(selectedfile_label.Text + " file sent.");
            }
            else
            {
                AppendTextBox(selectedfile_label.Text + " file sent.");
                client.ClientSocket.SendMessage(filemsg, password);
            }
        }

        private void join_room_button_Click(object sender, EventArgs e)
        {
            var videoRoom = new VideoRoom();
            videoRoom.Show();
        }
    }
}
