using Courses_Service.DTOs;
using Courses_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Courses_Service.Services
{
    public class CommentService
    {
        public AppDbContext AppDbContext { get; }

        public CommentService(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }
        public async Task<Comments> AddCommentAsync(int videoid, CommentDto commentDto)
        {
            var video = await AppDbContext.videos.FindAsync(videoid);
            if (video == null)
            {
                return null;
            }
            else
            {
                var comment = new Comments { 
                    CommentText = commentDto.CommentText,
                    UserId = commentDto.userid,
                    VideoId = videoid
                };
                await AppDbContext.comments.AddAsync(comment);
                await AppDbContext.SaveChangesAsync();
                return comment;
            }
        }

        public async Task<Comments> UpdateCommentAsync(int commentid, UpdateCommentDto commentDto)
        {
            var res = await AppDbContext.comments.FindAsync(commentid);
            if (res == null)
            {
                return null;
            }
            else
            {
                res.CommentText = commentDto.CommentText;
                AppDbContext.comments.Update(res);
                await AppDbContext.SaveChangesAsync();
                return res;
            }
        }

        public async Task<bool> DeleteCommentAsync(int commentid)
        {
            var res = await AppDbContext.comments.FindAsync(commentid);
            if (res == null)
            {
                return false;
            }
            else
            {
                AppDbContext.comments.Remove(res);
                await AppDbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Comments> GetCommentById(int commentid)
        {
            var res = await AppDbContext.comments.FindAsync(commentid);
            if (res == null)
            {
                return null;
            }
            else
            {
                return res;
            }
        }

        public async Task<IEnumerable<Comments>> GetCommentsByVideoIdAsync(int videoid)
        {
            var res = await AppDbContext.comments.Where(x => x.VideoId == videoid).ToListAsync();
            if (res == null)
            {
                return null;
            }
            else
            {
                return res;
            }
        }

    }
}
