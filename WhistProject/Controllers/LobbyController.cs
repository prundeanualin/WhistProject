using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WhistProject.Client;
using WhistProject.Models;

namespace WhistProject.Controllers
{
    public class LobbyController : Controller
    {
        public static Player ChatHistory { get; set; } = new Player();

        // GET: Lobby
        public ActionResult Index()
        {
            ViewBag.Message = "Time to play";
            return View();
        }

        [HttpPost]
        public ActionResult Lobby(string username)
        {
            string Msg = ClientMsgSend.Connect(username);
            ViewBag.Message = "Time to play";
            ChatHistory.username = username;
            ChatHistory.AddMessage(Msg);
            return View(ChatHistory);
        }

        [HttpPost]
        public ActionResult Talking(string username, string msg)
        {
            ChatHistory.username = username;
            if (msg != null)
            {
                ClientMsgSend.Send(msg, username);
            }
            //string Msg = ClientMsgSend.Receive(username);
            //if (Msg != null)
            //{
            //    ChatHistory.chat.Add(Msg);
            //}
            return View(ChatHistory);
        }

        public ActionResult UpdateChat(string name)
        {
            string msg = ClientMsgSend.Receive(name);
            if(msg != null)
            {
                ChatHistory.chat.Add(msg);
            }
            ChatHistory.username = name;
            return PartialView("_ChatView", ChatHistory);
        }
    }
}