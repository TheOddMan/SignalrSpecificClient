using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using System.Collections.Concurrent;
using _9_16SignalR.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace _9_16SignalR.Hubs
{
    public class MyHub : Hub
    {

        ApplicationDbContext db = new ApplicationDbContext();

        //public void Send(string name, string message)
        //{
        //    // Call the addNewMessageToPage method to update clients.
        //    Clients.All.addNewMessageToPage(name, message);
        //}


        public void Send(string sendtouser, string message)
        {
            var FromUserName = Context.User.Identity.Name;
            var FromUserId = HttpContext.Current.User.Identity.GetUserId();
            ApplicationUser ToUser = db.Users.FirstOrDefault(u => u.Email.Equals(sendtouser));
            var ToUserId = ToUser.Id;


            var cid = ToUser.ConnectionSignal.FirstOrDefault().ConnectionIds;
            var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            context.Clients.Client(cid).addNewMessageToPage(FromUserName, message);
        }

        private static readonly ConcurrentDictionary<string, ApplicationUser> Users =
        new ConcurrentDictionary<string, ApplicationUser>(StringComparer.InvariantCultureIgnoreCase);

        public  string getConnectionId()
        {
            string id = Context.ConnectionId;
            return id;
        }

        public override Task OnConnected()
        {
            //string userName = Context.User.Identity.Name;
            string connectionId = Context.ConnectionId;
            HttpContext con = HttpContext.Current;
              
            var FromUserId = HttpContext.Current.User.Identity.GetUserId();
            ApplicationUser FromUser = db.Users.Find(FromUserId);

            if(FromUser == null)
            {
                return base.OnConnected(); ;
            }


            if (FromUser.ConnectionSignal == null)
            {
                FromUser.ConnectionSignal = new List<ConnectionSignal>();
            }




            lock (FromUser.ConnectionSignal)
            {

                ConnectionSignal c = new ConnectionSignal();
                c.ConnectionIds = connectionId;
                ConnectionSignal x = FromUser.ConnectionSignal.FirstOrDefault(d => d.ConnectionIds.Equals(connectionId));

                if (x == null)
                {
                    //if (FromUser.ConnectionSignal.Count == 1)
                    //{

                    //}
                    //else
                    //{
                        FromUser.ConnectionSignal.Add(c);
                    //}
                }


            }
            db.SaveChanges();

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string userName = Context.User.Identity.Name;
            ApplicationUser FromUser = null;
            try
            {
                 FromUser = db.Users.FirstOrDefault(u => u.Email.Equals(userName));

            }catch(Exception e)
            {
                
            }
            
            string connectionId = Context.ConnectionId;



            if (FromUser != null)
            {
                lock (FromUser.ConnectionSignal)
                {
                    ConnectionSignal cs = db.ConnectionSignal.FirstOrDefault(c => c.ConnectionIds.Equals(connectionId));
                    db.ConnectionSignal.Remove(cs);
                }
            }
            db.SaveChanges();
            return base.OnDisconnected(stopCalled);
        }
    }
}