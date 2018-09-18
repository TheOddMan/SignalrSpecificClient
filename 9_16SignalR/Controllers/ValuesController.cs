using _9_16SignalR.Hubs;
using _9_16SignalR.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _9_16SignalR.Controllers
{
    public class ValuesController : ApiController
    {
        
        private ApplicationDbContext context = new ApplicationDbContext();

        //[HttpPost]
        //public HttpResponseMessage SendNotification(NotifModels obj)
        //{
        //    MyHub objNotifHub = new MyHub();
        //    Notifications objNotif = new Notifications();
        //    objNotif.Date = DateTime.Now;
        //    objNotif.SentTo = obj.UserID;

        //    context.Configuration.ProxyCreationEnabled = false;
        //    context.Notifications.Add(objNotif);
            

        //    context.SaveChanges();


        //    objNotifHub.SendNotification(objNotif.SentTo);

        //    var query = (from t in context.Notifications
        //                 select t).ToList();

        //    return Request.CreateResponse(HttpStatusCode.OK, new { query });
        //}



    }
}
