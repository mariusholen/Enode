﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Brukerfeil.Enode.Common.Models;
using Brukerfeil.Enode.Common.Repositories;
using Brukerfeil.Enode.Common.Services;
using System.Collections.Generic;
using System.Linq;
using System;
using Brukerfeil.Enode.Common.Exceptions;

namespace Brukerfeil.Enode.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {

        [HttpGet("in")]
        public async Task<ActionResult<IEnumerable<Message>>> GetAllIncomingMessagesAsync([FromServices] IMessageRepository messageRepository, [FromServices] ISortingService service, [FromServices] IMessageService  message)
        {
            try
            {
                var unsortedMessages = await messageRepository.GetAllIncomingMessagesAsync();
                if (unsortedMessages.ToList().Count() == 0)
                {
                    return NoContent();
                }
                var sortedMessages = service.SortMessages(unsortedMessages);
                var addLatestStatus = message.LatestStatus(sortedMessages);
                return Ok(addLatestStatus);
            } catch(Exception ex)
            {
                return this.StatusCode(502, ex.Message);
            }
            
        }

        [HttpGet("in/{organizationId}", Name = "GetOrgIncomingMessagesAync")]
        public async Task<ActionResult<IEnumerable<Message>>> GetOrgIncomingMessagesAsync(string organizationId,[FromServices] IMessageRepository messageRepository, [FromServices] ISortingService service, [FromServices] IMessageService message)
        {
            try
            {
                var unsortedMessages = await messageRepository.GetOrgIncomingMessagesAsync(organizationId);
                bool orgIsNumeric = int.TryParse(organizationId, out _);
                if (!orgIsNumeric)
                {
                    return BadRequest();
                }
                if (unsortedMessages.ToList().Count() == 0)
                {
                    return NoContent();
                }
                var sortedMessages = service.SortMessages(unsortedMessages);
                var addLatestStatus = message.LatestStatus(sortedMessages);

                return Ok(addLatestStatus);
            } catch(Exception ex)
            {
                return this.StatusCode(502, ex.Message);
            }
            
        }

        [HttpGet("out")]
        public async Task<ActionResult<IEnumerable<Message>>> GetAllOutgoingMessagesAsync([FromServices] IMessageRepository messageRepository, [FromServices] ISortingService service, [FromServices] IMessageService message)
        {
            try
            {
                var unsortedMessages = await messageRepository.GetAllOutgoingMessagesAsync();
                if (unsortedMessages.ToList().Count() == 0)
                {
                    return NoContent();
                }
                var sortedMessages = service.SortMessages(unsortedMessages);
                var addLatestStatus = message.LatestStatus(sortedMessages);
                return Ok(addLatestStatus);
            } catch (Exception ex)
            {
                return this.StatusCode(502, ex.Message);
            }
            
        }

        [HttpGet("out/{organizationId}", Name = "GetOrgOutgoingMessagesAsync")]
        public async Task<ActionResult<IEnumerable<Message>>> GetOrgOutgoingMessagesAsync(string organizationId,[FromServices] IMessageRepository messageRepository, [FromServices] ISortingService service, [FromServices] IMessageService message)
        {
            try
            {
                var unsortedMessages = await messageRepository.GetOrgOutgoingMessagesAsync(organizationId);
                bool orgIsNumeric = int.TryParse(organizationId, out _);
                if (!orgIsNumeric)
                {
                    return BadRequest();
                }
                if (unsortedMessages.ToList().Count() == 0)
                {
                    return NoContent();
                }
                var sortedMessages = service.SortMessages(unsortedMessages);
                var addLatestStatus = message.LatestStatus(sortedMessages);
                return Ok(addLatestStatus);
            } catch (Exception ex)
            {
                return this.StatusCode(502, ex.Message);
            }
            
        }

        [HttpGet("sender/{senderId}", Name = "GetAllMessagesBySenderIdAsync")]
        public async Task<ActionResult<IEnumerable<Message>>> GetAllMessagesBySenderIdAsync(string senderId, [FromServices] IMessageRepository messageRepository, [FromServices] ISortingService service, [FromServices] IMessageService message)
        {
            try
            {
                var unsortedMessages = await messageRepository.GetAllMessagesBySenderIdAsync(senderId);
                bool senderIsNumeric = int.TryParse(senderId, out _);
                if (!senderIsNumeric)
                {
                    return BadRequest();
                }
                if (unsortedMessages.ToList().Count() == 0)
                {
                    return NoContent();
                }
                var sortedMessages = service.SortMessages(unsortedMessages);
                var addLatestStatus = message.LatestStatus(sortedMessages);
                return Ok(addLatestStatus);
            }
            catch (Exception ex)
            {
                return this.StatusCode(502, ex.Message);
            }
        }

        [HttpGet("{organizationId}/sender/{senderId}", Name = "GetOrgMessagesBySenderIdAsync")]
        public async Task<ActionResult<IEnumerable<Message>>> GetOrgMessagesBySenderIdAsync(string senderId, string organizationId, [FromServices] IMessageRepository messageRepository, [FromServices] ISortingService service, [FromServices] IMessageService message)
        {
            try
            {
                var unsortedMessages = await messageRepository.GetOrgMessagesBySenderIdAsync(senderId, organizationId);
                bool senderIsNumeric = int.TryParse(senderId, out _);
                bool orgIsNumeric = int.TryParse(organizationId, out _);
                if (!senderIsNumeric || !orgIsNumeric)
                {
                    return BadRequest();
                }
                if (unsortedMessages.ToList().Count() == 0)
                {
                    return NoContent();
                }
                var sortedMessages = service.SortMessages(unsortedMessages);
                var addLatestStatus = message.LatestStatus(sortedMessages);
                return Ok(addLatestStatus);
            }
            catch (Exception ex)
            {
                return this.StatusCode(502, ex.Message);
            }

        }

        [HttpGet("receiver/{receiverId}", Name = "GetAllMessagesByReceiverIdAsync")]
        public async Task<ActionResult<IEnumerable<Message>>> GetAllMessagesByReceiverIdAsync(string receiverId, [FromServices] IMessageRepository messageRepository, [FromServices] ISortingService service, [FromServices] IMessageService message)
        {
            try
            {
                var unsortedMessages = await messageRepository.GetAllMessagesByReceiverIdAsync(receiverId);
                bool receiverIsNumeric = int.TryParse(receiverId, out _);
                if (!receiverIsNumeric)
                {
                    return BadRequest();
                }
                if (unsortedMessages.ToList().Count() == 0)
                {
                    return NoContent();
                }
                var sortedMessages = service.SortMessages(unsortedMessages);
                var addLatestStatus = message.LatestStatus(sortedMessages);
                return Ok(addLatestStatus);
            }
            catch (Exception ex)
            {
                return this.StatusCode(502, ex.Message);
            }

        }

        [HttpGet("{organizationId}/receiver/{receiverId}", Name = "GetOrgMessagesByReceiverIdAsync")]
        public async Task<ActionResult<IEnumerable<Message>>> GetOrgMessagesByReceiverIdAsync(string receiverId, string organizationId, [FromServices] IMessageRepository messageRepository, [FromServices] ISortingService service, [FromServices] IMessageService message)
        {
            try
            {
                var unsortedMessages = await messageRepository.GetOrgMessagesByReceiverIdAsync(receiverId, organizationId);
                bool receiverIsNumeric = int.TryParse(receiverId, out _);
                bool orgIsNumeric = int.TryParse(organizationId, out _);
                if (!receiverIsNumeric || !orgIsNumeric)
                {
                    return BadRequest();
                }
                Int32.Parse(organizationId);
                if (unsortedMessages.ToList().Count() == 0)
                {
                    return NoContent();
                }
                var sortedMessages = service.SortMessages(unsortedMessages);
                var addLatestStatus = message.LatestStatus(sortedMessages);
                return Ok(addLatestStatus);
            }
            catch (Exception ex)
            {
                return this.StatusCode(502, ex.Message);
            }
        }
    }
}