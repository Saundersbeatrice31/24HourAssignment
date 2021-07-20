using _24HourAssignment.Data;
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
        public IEnumerable<ReplyListItem> GetReplies(Comment CommId)
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
                                    Id = p.Id,                                    
                                    Text = p.Text
                                }
                        );
                return query.ToArray();
            }
        }
        public ReplyDetail GetReplyById(Guid AuthorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(p => p.AuthorId == _userId);
                return
                    new ReplyDetail
                    {
                        Id = entity.Id,
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
                        .Single(p => p.Id == model.Id && p.AuthorId == _userId);                
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
                        .Single(p => p.Id == id && p.AuthorId == _userId);
                ctx.Replies.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }
    }
}
