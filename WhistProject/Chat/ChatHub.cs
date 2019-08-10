using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WhistProject.Chat
{
    public class ChatHub : Hub
    {
        static HashSet<string> CurrentConnections = new HashSet<string>();

        public override Task OnConnected()
        {
            string con = "";
            var name = Context.User.Identity.Name;
            int count = CurrentConnections.Count;
            CurrentConnections.Add(name);
            foreach (string namen in CurrentConnections)
            {
                con += "<li>" + namen + "</li>";
            }
            Clients.All.user(con);
            int a = (int)HttpContext.Current.Application["NrOnlineUsers"];
            a += 1;
            HttpContext.Current.Application["NrOnlineUsers"] = a;
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stop)
        {
            var connection = CurrentConnections.FirstOrDefault(x => x == Context.User.Identity.Name);
            if(connection != null)
            {
                CurrentConnections.Remove(connection);
                string con = "";
                foreach (string namen in CurrentConnections)
                {
                    con += "<li>" + namen + "</li>";
                }
                Clients.Others.user(con);
            }
            return base.OnDisconnected(stop);
        }

        public void send(string message)
        {
            Clients.Caller.message("You: " + message);
            Clients.Others.message(Context.User.Identity.Name + ": " + message);
        }
    }
}