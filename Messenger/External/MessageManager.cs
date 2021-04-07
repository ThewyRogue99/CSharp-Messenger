using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Crypto;
using System.Xml.Serialization;

namespace Manager
{
    [Serializable]
    public class MessageManager
    {
        public string type;
        public string message;
        public string username;
        public string password;
        public byte[] sendfile;
        public string filename;
        public List<string> clients = new List<string>();
        public bool typestatus;

        public void CreateText(string msg, string user)
        {
            type = "text";
            message = msg;
            username = user;
        }

        public void CreateJoin(string user, string pass)
        {
            type = "join";
            username = user;
            password = pass;
        }

        public void CreateJoinInf(string user)
        {
            type = "JoinInf";
            username = user;
        }

        public void CreateLeftInf(string user)
        {
            type = "LeftInf";
            username = user;
        }

        public void CreateMemInf(List<string> names)
        {
            type = "MemInf";
            clients = names;
        }

        public void CreateKick(string user)
        {
            type = "KickUser";
            username = user;
        }

        public void CreateError(string reason)
        {
            type = "Error";
            message = reason;
        }

        public void CreateTyping(string user, bool status)
        {
            type = "UserType";
            username = user;
            typestatus = status;
        }

        public void CreateFileSend(string user, byte[] file, string file_name)
        {
            type = "FileSend";
            username = user;
            sendfile = file;
            filename = file_name;
        }

        public static implicit operator byte[](MessageManager obj)
        {
            return obj.XmlSerialize();
        }

        public static explicit operator MessageManager(byte[] array)
        {
            return array.XmlDeserialize<MessageManager>();
        }
    }

    public static class Serializer
    {
        public static T XmlDeserialize<T>(this byte[] toDeserialize)
        {
            /*XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader str = new StringReader(Encoding.UTF32.GetString(toDeserialize));
            return (T)serializer.Deserialize(str);*/
            return JsonConvert.DeserializeObject<T>(Encoding.UTF32.GetString(toDeserialize));
        }

        public static byte[] XmlSerialize<T>(this T toSerialize)
        {
            /*XmlSerializer serializer = new XmlSerializer(toSerialize.GetType());
            StringWriter str = new StringWriter();
            serializer.Serialize(str, toSerialize);
            return Encoding.UTF32.GetBytes(str.ToString());*/
            return Encoding.UTF32.GetBytes(JsonConvert.SerializeObject(toSerialize));
        }
    }

    public static class MessageManagerSockets
    {
        public static bool SendMessage(this Socket client, MessageManager msg, string pass)
        {
            byte[] encrypted = Cipher.EncryptData(msg, pass);
            try
            {
                client.Send(encrypted);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static MessageManager ReceiveMessage(this Socket client, string pass)
        {
            byte[] receive = new byte[5100000];
            MessageManager result = new MessageManager();
            try
            {
                client.Receive(receive);
            }
            catch
            {
                return null;
            }
            try
            {
                result = (MessageManager)Cipher.DecryptData(receive, pass);
            }
            catch
            {
                result.CreateError("RecvFail");
            }
            return result;
        }

        public static bool SendMessage(this Socket client, MessageManager msg)
        {
            try
            {
                client.Send(msg);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static MessageManager ReceiveMessage(this Socket client)
        {
            byte[] receive = new byte[5100000];
            try
            {
                client.Receive(receive);
            }
            catch
            {
                return null;
            }
            return (MessageManager)receive;
        }
    }
}
