using Courses_Service.Services;

namespace Courses_Service.Commands
{
    public class DeleteCommentFromVideoCommand
    {
        public DeleteCommentFromVideoCommand(CommentService commentService, int commentid)
        {
            CommentService = commentService;
            Commentid = commentid;
        }

        public CommentService CommentService { get; }
        public int Commentid { get; }

        public Task<bool> Execute() 
        { 
            return CommentService.DeleteCommentAsync(Commentid);
        }
    }
}
