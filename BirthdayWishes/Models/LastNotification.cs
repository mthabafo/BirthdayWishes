﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayWishes.Models
{
    public class LastNotification
    {
        public LastNotification(int Id, string lastNotificationDate) { }
        public int Id { get; set; }
        public string LastNotificationDate { get; set; }
    }
}
