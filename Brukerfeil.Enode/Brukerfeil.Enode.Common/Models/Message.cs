﻿using System;
using System.Collections.Generic;

namespace Brukerfeil.Enode.Common.Models
{
    public class MessageContent
    {
        public IEnumerable<Message> content { get; set; }
    }

    public class Message
    {
        public int id { get; set; }

        public string conversationId { get; set; }

        public string messageId { get; set; }

        public string senderIdentifier { get; set; }

        public string receiverIdentifier { get; set; }

        public string processIdentifier { get; set; }

        public string messageReference { get; set; }

        public string messageTitle { get; set; }

        public DateTime lastUpdate { get; set; }

        public bool finished { get; set; }

        public DateTime expiry { get; set; }

        public string direction { get; set; }

        public string serviceIdentifier { get; set; }

        public string latestMessageStatus { get; set; }

        public DateTime created { get; set; }

        public IEnumerable<MessageStatuses> messageStatuses { get; set; }

    }

    public class MessageStatuses
    {
        public int id { get; set; }
        public DateTime lastUpdate { get; set; }
        public string status { get; set; }
    }

}

