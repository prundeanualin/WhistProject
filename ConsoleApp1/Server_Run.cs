using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Collections;
using System.Text;

namespace WhistProject.Server
{
    public class Server_Run
    {
        private static byte[] buff = new byte[4096];
        private static Dictionary<Socket, string> client_socket = new Dictionary<Socket, string>();
        private static List<Socket> client_send = new List<Socket>();
        private static Socket sock_Server = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        static void Main(String[] args)
        {
            Console.Title = "Server";
            setUp();
            Console.ReadLine();
            CloseAllSockets();
        }

        private static void setUp()
        {
            Console.WriteLine("Server initiating ...");
            sock_Server.Bind(new IPEndPoint(IPAddress.Any, 51555));
            sock_Server.Listen(4);
            sock_Server.BeginAccept(AcceptCallback, null);
            Console.WriteLine("Server ready!");
        }

        private static void CloseAllSockets()
        {
            foreach (Socket sock in client_socket.Keys)
            {
                sock.Shutdown(SocketShutdown.Both);
                sock.Close();
            }
            sock_Server.Close();
        }

        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket;
            try
            {
                socket = sock_Server.EndAccept(AR);
            }
            catch (Exception)
            {
                return;
            }
            client_socket.Add(socket, null);
            socket.BeginReceive(buff, 0, buff.Length, SocketFlags.None, RecieveCallback, socket);
            Console.WriteLine("Client connected!");
            sock_Server.BeginAccept(AcceptCallback, null);
        }

        private static void RecieveCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            int received;
            try
            {
                received = socket.EndReceive(AR);
            }
            catch (SocketException)
            {
                Console.WriteLine("Client forcefully disconnected");
                socket.Close();
                client_socket.Remove(socket);
                return;
            }
            byte[] anotherOne = new byte[received];
            Array.Copy(buff, anotherOne, received);
            string text = Encoding.ASCII.GetString(anotherOne);
            Console.WriteLine("Text received: " + text);

            byte[] dataToSend;
            if (client_socket[socket] == null)
            {
                client_socket[socket] = text.Split(' ')[2];
                client_send.Add(socket);
                dataToSend = Encoding.ASCII.GetBytes("Howdy, " + client_socket[socket]);
                Console.WriteLine("Client name: " + text);
            }
            else if (text.Equals("Exit"))
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                Console.WriteLine("Client " + client_socket[socket] + " disconnected!");
                client_socket.Remove(socket);
                return;
            }
            else
            {
                dataToSend = Encoding.ASCII.GetBytes("[" + DateTime.Now.ToLongDateString() +
                                                     "] " + client_socket[socket] + " : " + text);
                Console.WriteLine(text);
            }
            foreach (Socket sock in client_send)
            {
                sock.Send(dataToSend);
            }
            Console.WriteLine("Data sent from server: " + text);
            socket.BeginReceive(buff, 0, buff.Length, SocketFlags.None, RecieveCallback, socket);
        }
    }
}