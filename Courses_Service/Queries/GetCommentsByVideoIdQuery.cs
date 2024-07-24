using Courses_Service.Models;
using Courses_Service.Services;

namespace Courses_Service.Queries
{
    public class GetCommentsByVideoIdQuery
    {
        public GetCommentsByVideoIdQuery(CommentService commentService, int videoid)
        {
            CommentService = commentService;
            Videoid = videoid;
        }

        public CommentService CommentService { get; }
        public int Videoid { get; }

        public Task<IEnumerable<Comments>> Execute() 
        {
            return CommentService.GetCommentsByVideoIdAsync(Videoid);
        }
    }
}
