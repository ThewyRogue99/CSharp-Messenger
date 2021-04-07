using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using MessengerClient;
using MessengerServer;
using System.Net.Sockets;
using System.Collections.Generic;
using VideoClass;
using AForge.Video.DirectShow;

namespace Messenger
{
    public partial class VideoRoom : Form
    {
        public VideoRoom()
        {
            InitializeComponent();
            this.MinimumSize = this.Size;
        }
        bool abort = false;
        Server server;
        Client client;
        List<Socket> clients = new List<Socket>();
        OpenH264Lib.Encoder encoder = new OpenH264Lib.Encoder("..\\H264\\openh264-1.7.0-win32.dll");
        OpenH264Lib.Decoder decoder = new OpenH264Lib.Decoder("..\\H264\\openh264-1.7.0-win32.dll");
        private void VideoRoom_Load(object sender, EventArgs e)
        {
            CameraSelect.Items.Add("Screen Share");
            if (MessengerWindow.isadmin)
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(Server.GetLocalIPAddress()), 45456);
                server = new Server(Server.GetLocalIPAddress(), 45456);
                server.CreateServer(1, MessengerWindow.password);
                StatLabel.Text = "Waiting for connections";
                join_button.Enabled = false;
                Thread adminth = new Thread(new ThreadStart(Admin));
                adminth.Start();
            }
            else
                StatLabel.Text = "";
            FilterInfoCollection filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                CameraSelect.Items.Add(filterInfo.Name);
            CameraSelect.SelectedIndex = 0;
        }

        private void join_button_Click(object sender, EventArgs e)
        {
            if (!abort)
                abort = true;
            Thread.Sleep(20);
            abort = false;
            Client();
        }

        private void Admin()
        {
            string username = "";
            Socket client = null;
            try
            {
                client = server.Accept(ref username, ref clients, ref MemberBox);
            }
            catch
            {
                return;
            }
            Invoke((Action)delegate { StatLabel.Text = "Connection Established"; });
            Thread StreamThread = new Thread(new ThreadStart(() => Stream(client, 60)));
            StreamThread.Start();
            Thread ReceiveThread = new Thread(new ThreadStart(() => Receive(client)));
            ReceiveThread.Start();
        }

        private void Client()
        {
            client = new Client();
            client.Connect(MessengerWindow.ip_address, 45456, MessengerWindow.password, MessengerWindow.username);
            Thread StreamThread = new Thread(new ThreadStart(() => Stream(client.ClientSocket, 60)));
            StreamThread.Start();
            Thread ReceiveThread = new Thread(new ThreadStart(() => Receive(client.ClientSocket)));
            ReceiveThread.Start();
        }

        private void Receive(Socket socket)
        {
            while (!abort)
            {
                try
                {
                    byte[] num = new byte[4];
                    socket.Receive(num);
                    byte[] buffer = new byte[BitConverter.ToInt32(num, 0)];
                    socket.Receive(buffer);
                    Image frame;
                    try
                    {
                        frame = decoder.Decode(buffer, buffer.Length);
                    }
                    catch
                    {
                        frame = null;
                    }
                    Image cont = videoFrame.Image;
                    if (frame != null)
                    {
                        videoFrame.Image = (Image)frame.Clone();
                        frame.Dispose();
                    }
                    if (cont != null)
                        cont.Dispose();
                    num = null;
                    buffer = null;
                }
                catch
                {
                    CloseVideoRoom();
                }
            }
        }

        private void Stream(Socket socket, int framerate)
        {
            VideoHandle videoHandle = new VideoHandle();
            System.Drawing.Size size = new System.Drawing.Size(1920, 1080);
            encoder.Setup(size.Width, size.Height, 5120 * 1000, framerate, 1f, (data, length, FrameType) =>
            {
                socket.Send(BitConverter.GetBytes(length));
                socket.Send(data);
            }
            );
            while (!abort)
            {
                int index = 0;
                try
                {
                    Invoke((Action)delegate { index = CameraSelect.SelectedIndex; });
                }
                catch
                {
                    break;
                }
                if (index == 0)
                    videoHandle.GetFrames(VideoCapType.TYPE_SCREEN);
                else
                    videoHandle.GetFrames(VideoCapType.TYPE_WEBCAM, index - 1);

                if (videoHandle.frame != null)
                {
                    Bitmap resized = ImageSerialize.ResizeImg((Bitmap)videoHandle.frame.Clone(), size);
                    encoder.Encode(resized);
                    resized.Dispose();
                }
                Thread.Sleep(1000 / framerate);
            }
        }

        private void CloseVideoRoom()
        {
            abort = true;
            if (MessengerWindow.isadmin)
                server.Close();
            else
                client.Close();
        }

        private void VideoRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseVideoRoom();
        }
    }

    public static class ImageSerialize
    {
        /*public static byte[] ImgToByte(Image img)
        {
            var converter = new System.Drawing.ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }*/

        public static Image ByteToImg(byte[] img)
        {
            var ms = new MemoryStream(img);
            return (Image)Image.FromStream(ms).Clone();
        }

        public static Bitmap ResizeImg(Bitmap img, System.Drawing.Size NewSize)
        {
            var bmp = new Bitmap(NewSize.Width, NewSize.Height);
            var graph = Graphics.FromImage(bmp);

            graph.DrawImage(img, 0, 0, NewSize.Width, NewSize.Height);
            graph.Dispose();
            img.Dispose();

            return bmp;
        }
    }
}
