using System;
using System.Collections.Generic;
using System.Text;

namespace Brukerfeil.Enode.Common.Models
{
    class SenderRecipient
    {
        public Boolean IsRecipient { get; set; }
        public string Name { get; set; }
        public string ConversationId { get; set; }
        public int CreatedByUserNameId { get; set; }
        public int LastUpdatedByUserNameId { get; set; }
        public string ExternalId { get; set; }
    }
}
