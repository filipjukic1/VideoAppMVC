﻿namespace Javni_admin_modul.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ReceiverEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SentAt { get; set; }

    }
}
