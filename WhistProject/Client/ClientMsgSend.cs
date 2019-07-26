using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web;
using Microsoft.Ajax.Utilities;
using WhistProject.Controllers;

namespace WhistProject.Client
{
    public class ClientMsgSend
    {
        public static Dictionary<string, Socket> clients = new Dictionary<string, Socket>();

        public static string Connect(string name)
        {
            try
            {
            Socket _clientSocket = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            _clientSocket.Connect(IPAddress.Parse("127.0.0.1") , 51555);
            clients.Add(name, _clientSocket);
            Send("Hello from "+ name , name);
             return Receive(name);
            }
            catch (SocketException)
            {
                return "Connection error, please try again, dear!";
            }
        }

        public static void Send(string text, string name)
        {
            byte[] buffBytes = Encoding.ASCII.GetBytes(text);
            clients[name].Send(buffBytes);
        }

        public static string Receive(string name)
        {
                System.Threading.Thread.Sleep(800);
            if (clients[name].Available > 0)
            {
                byte[] receiveBytes = new byte[4096];
                int receive = clients[name].Receive(receiveBytes);
                byte[] actualreceive = new byte[receive];
                Array.Copy(receiveBytes, actualreceive, receive);
                return Encoding.ASCII.GetString(actualreceive);
            }
            else
            {
                return null;
            }

        }
    }
}