using Courses_Service.Models;
using Courses_Service.Services;

namespace Courses_Service.Queries
{
    public class GetCommentByIdQuery
    {
        public GetCommentByIdQuery(CommentService commentService, int commentid)
        {
            CommentService = commentService;
            Commentid = commentid;
        }

        public CommentService CommentService { get; }
        public int Commentid { get; }

        public Task<Comments> Execute()
        {
            return CommentService.GetCommentById(Commentid);
        }
    }
}
