using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Brukerfeil.Enode.Common.Models;
using Brukerfeil.Enode.Common.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Brukerfeil.Enode.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageStatusController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{messageId}", Name = "GetMessageStatusAsync")]
        public async Task<IEnumerable<MessageStatus>> GetMessageStatusAsync(string messageId, [FromServices] IMessageStatusRepository messageStatusRepository)
        {
            return await messageStatusRepository.GetMessageStatusAsync(messageId);
        }
    }
}