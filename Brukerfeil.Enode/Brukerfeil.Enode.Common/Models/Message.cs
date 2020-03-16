﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Brukerfeil.Enode.Common.Models
{
    public class Message
    {
        public IEnumerable<DifiElements> value { get; set; }
    }

    public class DifiElements
    {
        public int RegistryEntryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public object IsRead { get; set; }
        public string ConversationId { get; set; }
        public string conversationId { get; set; }
        public string messageId { get; set; }
        public string senderIdentifier { get; set; }
        public string receiverIdentifier { get; set; }
        public DateTime lastUpdate { get; set; }
        public string direction { get; set; }
        public string serviceIdentifier { get; set; }
        public string latestMessageStatus { get; set; }
        public DateTime created { get; set; }
        public IEnumerable<SendingMethods> sendingMethods { get; set; }
        public IEnumerable<SendingStatuses> sendingStatuses { get; set; }
        public IEnumerable<DifiMessageStatuses> messageStatuses { get; set; }
    }

    public class SendingMethods
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public bool ConvertToPdf { get; set; }
        public bool UseEmail { get; set; }
        public bool UseEde { get; set; }
        public bool UsePrint { get; set; }
        public bool OnlyMetadata { get; set; }
        public bool UseEdf { get; set; }
        public object CreatedDate { get; set; }
        public object CreatedByUserNameId { get; set; }
        public object LastUpdated { get; set; }
        public object LastUpdatedByUserNameId { get; set; }
        public object ChangeId { get; set; }
        public string SystemId { get; set; }
        public object LastUpdatedByExternalSystem { get; set; }
        public object CreatedByExternalSystem { get; set; }
        public object Operation { get; set; }
    }

    public class SendingStatuses
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public object CreatedDate { get; set; }
        public object CreatedByUserNameId { get; set; }
        public object LastUpdated { get; set; }
        public object LastUpdatedByUserNameId { get; set; }
        public object ChangeId { get; set; }
        public string SystemId { get; set; }
        public object LastUpdatedByExternalSystem { get; set; }
        public object CreatedByExternalSystem { get; set; }
        public object Operation { get; set; }
    }

    public class DifiMessageStatuses
    {
        public int id { get; set; }
        public DateTime lastUpdate { get; set; }
        public string status { get; set; }
    }
}
