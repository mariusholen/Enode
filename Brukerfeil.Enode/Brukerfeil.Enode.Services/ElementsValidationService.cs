using System.Collections.Generic;
using Brukerfeil.Enode.Common.Models;
using Brukerfeil.Enode.Common.Services;


namespace Brukerfeil.Enode.Services
{
    public class ElementsValidationService : IElementsValidationService
    {
        public List<SenderRecipient> ValidateElementsIncomingMessages(IEnumerable<SenderRecipient> isRecipient)
        {
            var validatedList = new List<SenderRecipient>();
            foreach (var senderRecipient in isRecipient)
            {
                if (senderRecipient.IsRecipient == true)
                {
                    validatedList.Add(senderRecipient);
                }
            }

            return validatedList;
        }

        public List<SenderRecipient> ValidateElementsOutgoingMessages(IEnumerable<SenderRecipient> isNotRecipient)
        {
            var validatedList = new List<SenderRecipient>();
            foreach (var senderRecipient in isNotRecipient)
            {
                if (!senderRecipient.IsRecipient)
                {
                    validatedList.Add(senderRecipient);
                }
            }
            return validatedList;
        }

    }
}
