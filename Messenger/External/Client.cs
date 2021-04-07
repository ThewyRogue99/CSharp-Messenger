using Manager;
using System.Net.Sockets;
using System.Text;

namespace MessengerClient
{
    public class Client
    {
        public Socket ClientSocket;

        public int Connect(string ip, int port, string password, string username)
        {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                ClientSocket.Connect(ip, port);
            }
            catch
            {
                ClientSocket.Close();
                return 1;
            }
            MessageManager join = new MessageManager();
            join.CreateJoin(username, password);
            ClientSocket.Send(join);
            byte[] stat = new byte[1024];
            try
            {
                ClientSocket.Receive(stat);
            }
            catch
            {
                ClientSocket.Close();
                return 1;
            }
            if (Encoding.ASCII.GetString(stat).CompareTo("wrong_pass") == 0)
            {
                ClientSocket.Close();
                return 2;
            }
            else if (Encoding.ASCII.GetString(stat).CompareTo("busy_server") == 0)
            {
                ClientSocket.Close();
                return 3;
            }
            else if (Encoding.ASCII.GetString(stat).CompareTo("name_error") == 0)
            {
                ClientSocket.Close();
                return 4;
            }
            else if (Encoding.ASCII.GetString(stat).CompareTo("success") == 0)
            {
                return 0;
            }

            ClientSocket.Close();
            return 1;
        }

        public string EndPoint
        {
            get { return ClientSocket.RemoteEndPoint.ToString().Split(':')[0]; }
        }

        public void Close()
        {
            ClientSocket.Close();
        }
    }
}
