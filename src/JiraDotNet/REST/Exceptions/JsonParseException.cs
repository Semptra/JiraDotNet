namespace Semptra.JiraDotNet.REST
{
    using System;

    public class JsonParseException : Exception
    {
        public JsonParseException() : base() { }

        public JsonParseException(string message) : base(message) { }
    }
}