using Courses_Service.DTOs;
using Courses_Service.Models;
using Courses_Service.Services;

namespace Courses_Service.Commands
{
    public class AddCommentToVideoCommand
    {
        public AddCommentToVideoCommand(CommentService commentService, int videoid, CommentDto commentDto)
        {
            CommentService = commentService;
            Videoid = videoid;
            CommentDto = commentDto;
        }

        public CommentService CommentService { get; }
        public int Videoid { get; }
        
        public CommentDto CommentDto { get; }

        public async Task<Comments> Execute() 
        {
            return await CommentService.AddCommentAsync(Videoid, CommentDto);
        }
    }
}
