using _24HourAssignment.Data.Entities;
using _24HourAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;
        public ReplyService (Guid userId)
        {
            _userId = userId;
        }
        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    AuthorId = _userId,
                    Text = model.Text
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query =
                    ctx
                        .Replies
                        .Where(p => p.AuthorId == _userId)
                        .Select(
                            p =>
                                new ReplyListItem
                                {
                                    ReplyId = p.ReplyId,                                    
                                    Text = p.Text
                                }
                        );
                return query.ToArray();
            }
        }
        public ReplyDetail GetReplyById(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(p => p.ReplyId == Id && p.AuthorId == _userId);
                return
                    new ReplyDetail
                    {
                        ReplyId = entity.ReplyId,
                        Text = entity.Text
                    };
            }
        }
        public bool UpdateReply(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(p => p.ReplyId == model.ReplyId && p.AuthorId == _userId);                
                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteReply(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(p => p.ReplyId == id && p.AuthorId == _userId);
                ctx.Replies.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }
    }
}
