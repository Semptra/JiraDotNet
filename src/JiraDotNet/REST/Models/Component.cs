﻿using System;

namespace Semptra.JiraDotNet.REST.Models
{
    public class Component
    {
        public Uri Self { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool? IsAssigneeTypeValid { get; set; }
    }
}