using _24HourAssignment.Data;
using _24HourAssignment.Data.Entities;
using _24HourAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Services
{
     public class CommentService
    {
        private readonly Guid _userId;
        public CommentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity =
            new Comment()
            {
                AuthorId = _userId,
                CommId = model.CommId,
                Text = model.Text,
                
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItem> GetComments(Post Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                .Comments
                .Where(e => e.AuthorId == _userId)
                .Select(
                e =>
                new CommentListItem
                {
                    CommId = e.CommId,
                    Text = e.Text
                }
            );
                return query.ToArray();
            }
        }
        public CommentDetail GetCommentById(Guid AuthorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e =>  e.AuthorId == _userId);
                return
                    new CommentDetail
                    {
                        CommId = entity.CommId,                       
                        Text = entity.Text,                        
                    };
            }
        }
        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommId == model.CommId && e.AuthorId == _userId);
                entity.Text = model.Text;               
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteComment(int CommId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommId == CommId && e.AuthorId == _userId);
                ctx.Comments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
