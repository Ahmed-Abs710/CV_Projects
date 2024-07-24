using Courses_Service.DTOs;
using Courses_Service.Models;
using Courses_Service.Services;

namespace Courses_Service.Commands
{
    public class UpdateCommentCommand
    {
        public UpdateCommentCommand(CommentService commentService, int commentid, UpdateCommentDto updateCommentDto
            )
        {
            CommentService = commentService;
            Commentid = commentid;
            UpdateCommentDto = updateCommentDto;
        }

        public CommentService CommentService { get; }
        public int Commentid { get; }
        public UpdateCommentDto UpdateCommentDto { get; }

        public Task<Comments> Execute()
        {
            return CommentService.UpdateCommentAsync(Commentid,UpdateCommentDto);
        }
    }
}
