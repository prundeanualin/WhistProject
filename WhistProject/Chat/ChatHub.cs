using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using WhistProject.Models;

namespace WhistProject.Chat
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        static HashSet<string> CurrentConnections = new HashSet<string>();

        public override Task OnConnected()
        {
            var name = Context.User.Identity.Name;
            string username;
            string con = "";
            using (var db = new ApplicationDbContext())
            {
                username = db.Player.Where(i => i.email == name).Single().username;
            }
            if (!CurrentConnections.Contains(username))
            {
                CurrentConnections.Add(username);
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
            string username;
            using(var db = new ApplicationDbContext())
            {
                username = db.Player.Where(x => x.email == Context.User.Identity.Name).Single().username;
            }
            var connection = CurrentConnections.FirstOrDefault(x => x == username);
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
            string username;
            using (var db = new ApplicationDbContext())
            {
                username = db.Player.Where(x => x.email == Context.User.Identity.Name).Single().username;
            }
            Clients.Others.message(username + " : " + message);
        }
    }
}