using System;
using System.Net.Http;

namespace Semptra.JiraDotNet.REST
{
    public sealed class JiraRequestException : Exception
    {
        public JiraRequestException() : base() { }

        public JiraRequestException(string message) : base(message) { }

        public JiraRequestException(HttpResponseMessage message) : base() { }

        public HttpResponseMessage ResponceMessage { get; set; }
    }
}