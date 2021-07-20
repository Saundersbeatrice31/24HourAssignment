using _24HourAssignment.Data;
using _24HourAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Services
{
    public class PostService
    {
        private readonly Guid _userId;
        public PostService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    AuthorId = _userId,
                    Title = model.Title,
                    Text = model.Text
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;

            }
        }
        public IEnumerable<PostListItem> GetPosts()
        {
            using(var ctx = new ApplicationDbContext())
            {

            var query =
                ctx
                    .Posts
                    .Where(p => p.AuthorId == _userId)
                    .Select(
                        p =>
                            new PostListItem
                            {
                                Id = p.Id,
                                Title = p.Title,
                                Text = p.Text
                            }
                    );
            return query.ToArray();
            }
        }
        public PostDetail GetPostById (Guid AuthorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(p => p.AuthorId == _userId);
                return
                    new PostDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Text = entity.Text
                    };
            }
        }
        public bool UpdatePost (PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(p => p.Id == model.Id && p.AuthorId == _userId);
                entity.Title = model.Title;
                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePost(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(p => p.Id == id && p.AuthorId == _userId);
                ctx.Posts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }

    }
}
