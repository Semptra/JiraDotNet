using System;

namespace Semptra.JiraDotNet.REST
{
    public sealed class JsonParseException : Exception
    {
        public JsonParseException() : base() { }

        public JsonParseException(string message) : base(message) { }
    }
}