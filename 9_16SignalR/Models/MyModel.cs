using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _9_16SignalR.Models
{
    public class UserHubModels
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public HashSet<string> ConnectionIds { get; set; }
    }

    public class Notifications
    {
        public int id { get; set; }
        public int Type { get; set; }
        public string Details { get; set; }
        public string Title { get; set; }
        public string DetailsURL { get; set; }
        public string SentTo { get; set; }
        public DateTime Date { get; set; }
        public byte IsRead { get; set; }
        public byte IsDeleted { get; set; }
        public byte IsReminder { get; set; }
        public string Code { get; set; }
        public string NotificationType { get; set; }
    }
    public class NotifModels
    {
        public int id { get; set; }
        public string UserID { get; set; }
        public string Message { get; set; }
    }

    public class ConnectionSignal
    {
        public int id { get; set; }
        public string ConnectionIds { get; set; }

        public virtual ApplicationUser user { get; set; }
    }
}