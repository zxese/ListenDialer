using System;
using System.Collections.Generic;
using System.Text;

namespace PageListenDialer
{
    class Message
    {
        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        string raw;

        public string Raw
        {
            get { return raw; }
            set { raw = value; }
        }
        string flags;

        public string Flags
        {
            get { return flags; }
            set { flags = value; }
        }
        DateTime createdAt;

        public DateTime CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

        string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public Message(string address, string content)
        {
            this.address = address;
        }
    }
}
