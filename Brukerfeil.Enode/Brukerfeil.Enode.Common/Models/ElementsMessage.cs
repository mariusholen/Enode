using System;
using System.Collections.Generic;

namespace Brukerfeil.Enode.Common.Models
{
    public class ElementsMessageContent
    {
        public string odatacontext { get; set; }
        public IEnumerable<ElementsMessage> value { get; set; }
    }

    public class ElementsMessage
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public object IsRead { get; set; }
        public string ConversationId { get; set; }
        public IEnumerable<SendingMethod> sendingMethod { get; set; }
        public IEnumerable<SendingStatus> sendingStatuses { get; set; }
    }

    public class SendingMethod
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

    public class SendingStatus
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

}