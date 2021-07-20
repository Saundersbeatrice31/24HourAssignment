using _24HourAssignment.Data;
using _24HourAssignment.Data;
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
                Id = model.Id,
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
                    Id = e.Id,
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
                        Id = entity.Id,                       
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
                        .Single(e => e.Id == model.Id && e.AuthorId == _userId);
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
                        .Single(e => e.Id == CommId && e.AuthorId == _userId);
                ctx.Comments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
