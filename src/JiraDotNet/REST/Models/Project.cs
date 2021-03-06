﻿using System;
using System.Collections.Generic;

namespace Semptra.JiraDotNet.REST.Models
{
    public class Project
    {
        public Uri Self { get; set; }

        public int Id { get; set; }

        public string Key { get; set; }

        public string Description { get; set; }

        public Lead Lead { get; set; }

        public ICollection<Component> Components { get; set; }

        public ICollection<IssueType> IssueTypes { get; set; }

        public string AssigneeType { get; set; }

        public ICollection<Version> Versions { get; set; }

        public string Name { get; set; }

        public IDictionary<string, string> Roles { get; set; }

        public string ProjectTypeKey { get; set; }
    }
}