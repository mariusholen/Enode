using System;
using System.Collections.Generic;
using System.Text;
using Brukerfeil.Enode.Common.Models;


namespace Brukerfeil.Enode.Common.Services
{
     public interface IElementsValidationService
        {
        public List<SenderRecipient> ValidateElementsIncomingMessages(IEnumerable<SenderRecipient> isRecipient);

        public List<SenderRecipient> ValidateElementsOutgoingMessages(IEnumerable<SenderRecipient> isNotRecipient);

    }
}

