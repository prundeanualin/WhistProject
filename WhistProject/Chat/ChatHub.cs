using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace WhistProject.Chat
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        static HashSet<string> CurrentConnections = new HashSet<string>();

        public override Task OnConnected()
        {
            string con = "";
            var name = Context.User.Identity.Name;
            if (!CurrentConnections.Contains(name))
            {
                CurrentConnections.Add(name);
            }
            foreach (string namen in CurrentConnections)
            {
                con += "<li>" + namen + "</li>";
            }
            Clients.All.updateCounter(CurrentConnections.Count);
            Clients.All.user(con);
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
                Clients.All.updateCounter(CurrentConnections.Count);
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