using _24HourAssignment.Data;
using _24HourAssignment.Models;
using _24HourAssignment.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24HourAssignment.Controllers
{
    [Authorize]
    public class ReplyController : ApiController
    {
        private ReplyService CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(userId);
            return replyService;
        }
        public IHttpActionResult Get(Comment CommId)
        {
            ReplyService replyService = CreateReplyService();
            var replies = replyService.GetReplies(CommId);
            return Ok(replies);
        }
        public IHttpActionResult Reply(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateReplyService();
            if (!service.CreateReply(reply))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Get(Guid AuthorId)
        {
            ReplyService replyService = CreateReplyService();
            var reply = replyService.GetReplyById(AuthorId);
            return Ok(reply);
        }
        public IHttpActionResult Put(ReplyEdit reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateReplyService();

            if (!service.UpdateReply(reply))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateReplyService();
            if (!service.DeleteReply(id))
                return InternalServerError();
            return Ok();
        }

    }
}
