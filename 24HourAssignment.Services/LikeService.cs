﻿using _24HourAssignment.Data;
using _24HourAssignment.Data.Entities;
using _24HourAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourAssignment.Services
{
    public class LikeService
    {
        private readonly Guid _userId;
        public LikeService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateLike (LikeCreate model)
        {
            var entity =
                new Like()
                {
                    OwnerId = _userId,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LikeListItem> GetLikes(Post Id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var query =
                    ctx
                        .Likes
                        .Where(p => p.OwnerId == _userId)
                        .Select(
                            p =>
                                new LikeListItem
                                {
                                   LikeId = p.LikeId,
                                }
                        );
                return query.ToArray();
            }
        }
        public LikeDetail GetLikeById(Guid AuthorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Likes
                        .Single(p => p.OwnerId == _userId);
                return
                    new LikeDetail
                    {
                        LikeId = entity.LikeId,
                       
                    };
            }
        }
        public bool UpdateLike(LikeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Likes
                        .Single(p => p.LikeId == model.LikeId && p.OwnerId == _userId);
                entity.LikeId = model.LikeId;                
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteLike(int Likeid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Likes
                        .Single(p => p.LikeId == Likeid && p.OwnerId == _userId);
                ctx.Likes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }
    }
}
