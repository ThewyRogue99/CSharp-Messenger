using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Manager;
using System.Windows.Forms;
using System.Linq;
using System.Net.NetworkInformation;

namespace MessengerServer
{
    public class Server
    {
        public Socket server;
        private IPAddress addr;
        private int port;
        public string password;
        public int maxperson;

        public Server(string ip_address, int port_number)
        {
            addr = IPAddress.Parse(ip_address);
            port = port_number;
        }

        public int CreateServer(int max_person, string pass)
        {
            maxperson = max_person + 1;
            try
            {
                GetIPAddress();
            }
            catch
            {
                return 1;
            }
            IPEndPoint ep;
            try
            {
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ep = new IPEndPoint(addr, port);
            }
            catch
            {
                return 2;
            }

            server.Bind(ep);
            server.Listen(maxperson);

            password = pass;

            return 0;
        }

        public Socket Accept(ref string user, ref List<Socket> clientlist, ref ListBox listBox)
        {
            while (true)
            {
                Socket result;
                MessageManager pass;
                result = server.Accept();
                byte[] file = new byte[result.ReceiveBufferSize];
                try
                {
                    result.Receive(file);
                }
                catch
                {
                    result.Close();
                    continue;
                }
                pass = (MessageManager)file;
                if (password.CompareTo(pass.password) != 0)
                {
                    result.Send(Encoding.ASCII.GetBytes("wrong_pass"));
                    result.Close();
                    continue;
                }
                else if (maxperson == clientlist.Count + 1)
                {
                    result.Send(Encoding.ASCII.GetBytes("busy_server"));
                    result.Close();
                    continue;
                }
                else if (listBox.Items.Contains(pass.username))
                {
                    result.Send(Encoding.ASCII.GetBytes("name_error"));
                    result.Close();
                    continue;
                }
                else
                {
                    result.Send(Encoding.ASCII.GetBytes("success"));
                    user = pass.username;
                    return result;
                }
            }
        }

        public void Close()
        {
            server.Close();
        }

        public static string GetLocalIPAddress()
        {
            string Localip = "";
            foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {

                var defaultGateway = from nics in NetworkInterface.GetAllNetworkInterfaces()


                                     from props in nics.GetIPProperties().GatewayAddresses
                                     where nics.OperationalStatus == OperationalStatus.Up
                                     select props.Address.ToString(); // this sets the default gateway in a variable

                GatewayIPAddressInformationCollection prop = netInterface.GetIPProperties().GatewayAddresses;

                if (defaultGateway.First() != null)
                {
                    IPInterfaceProperties ipProps = netInterface.GetIPProperties();

                    foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
                    {
                        // The IP address of the computer is always a bit equal to the default gateway except for the last group of numbers. This splits it and checks
                        //if the ip without the last group matches the default gateway
                        if (addr.Address.ToString().Contains(defaultGateway.First().Remove(defaultGateway.First().LastIndexOf("."))))
                        {
                            if (Localip == "") // check if the string has been changed before
                            {
                                Localip = addr.Address.ToString(); // put the ip address in a string that you can use.
                            }
                        }

                    }

                }

            }
            return Localip;
        }

        public static string GetIPAddress()
        {
            string address = "";
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                address = stream.ReadToEnd();
            }

            int first = address.IndexOf("Address: ") + 9;
            int last = address.LastIndexOf("</body>");
            address = address.Substring(first, last - first);

            return address;
        }
    }
}