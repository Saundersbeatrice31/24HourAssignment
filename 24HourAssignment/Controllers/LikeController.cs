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
    public class LikeController : ApiController
    {
        private LikeService CreateLikeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var likeService = new LikeService(userId);
            return likeService;
        }
        public IHttpActionResult Get(Post Id)
        {
            LikeService likeService = CreateLikeService();
            var likes = likeService.GetLikes(Id);
            return Ok(likes);
        }
        public IHttpActionResult Like(LikeCreate like)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateLikeService();
            if (!service.CreateLike(like))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Get(Guid OwnerId)
        {
            LikeService likeService = CreateLikeService();
            var likes = likeService.GetLikeById(OwnerId);
            return Ok(likes);
        }
        public IHttpActionResult Put(LikeEdit like)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateLikeService();
            if (!service.UpdateLike(like))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateLikeService();
            if (!service.DeleteLike(id))
                return InternalServerError();
            return Ok();
        }
    }
}
