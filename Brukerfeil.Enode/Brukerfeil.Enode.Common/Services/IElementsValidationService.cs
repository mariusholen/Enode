using System;
using System.Collections.Generic;
using System.Text;
using Brukerfeil.Enode.Common.Models;


namespace Brukerfeil.Enode.Common.Services
{
     public interface IElementsValidationService
        {
        public List<ElementsMessage> ValidateElementsIncomingMessages(IEnumerable<ElementsMessage> isRecipient);

        public List<ElementsMessage> ValidateElementsOutgoingMessages(IEnumerable<ElementsMessage> isNotRecipient);

    }
}

