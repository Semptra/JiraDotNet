﻿using System;

namespace Semptra.JiraDotNet.REST.Models
{
    public class Account
    {
        public Uri Self { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Key { get; set; }

        public string AccountId { get; set; }

        public string EmailAddress { get; set; }

        public string DisplayName { get; set; }

        public bool Active { get; set; }

        public string TimeZone { get; set; }

        public AvatarUrls AvatarUrls { get; set; }
    }
}