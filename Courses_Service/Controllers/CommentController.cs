using Courses_Service.Commands;
using Courses_Service.DTOs;
using Courses_Service.Queries;
using Courses_Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Courses_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        public CommentService CommentService { get; }

        public CommentController(CommentService commentService)
        {
            CommentService = commentService;
        }
        [HttpPost]
        [Route("AddCommentToVideo")]
        public async Task<IActionResult> AddCommentToVideo(int videoid,[FromBody] CommentDto commentDto)
        {
            var comment = new AddCommentToVideoCommand(CommentService,videoid , commentDto);
            var res =await comment.Execute();
            if (res==null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpGet]
        [Route("GetAllCommentsForVideo/{videoid}")]
        public async Task<IActionResult> GetAllCommentsForVideo(int videoid)
        {
            var comment = new GetCommentsByVideoIdQuery(CommentService, videoid);
            var res =await comment.Execute();
            if (res == null) { return BadRequest(); }
            else
            {
                return Ok(res);
            }
        }

        [HttpGet]
        [Route("GetCommentById/{commentid}")]
        public async Task<IActionResult> GetCommentById(int commentid)
        {
            var comment = new GetCommentByIdQuery(CommentService, commentid);
            var res = await comment.Execute();
            if (res == null)
            {
                return BadRequest();
            }
            else { return Ok(res); }
        }

        [HttpPut]
        [Route("UpdateComment/{commentid}")]
        public async Task<IActionResult> UpdateComment(int commentid, [FromBody] UpdateCommentDto updateCommentDto)
        {
            var comment = new UpdateCommentCommand(CommentService, commentid, updateCommentDto);
            var res = await comment.Execute();
            if (res == null) { return BadRequest(); }
            else { return Ok(res); }
        }

        [HttpDelete]
        [Route("DeleteComment/{commentid}")]
        public async Task<IActionResult> DeleteComment(int commentid)
        {
            var comment = new DeleteCommentFromVideoCommand(CommentService, commentid);
            var res = await comment.Execute();
            if (Convert.ToBoolean(res) == false) { return BadRequest(res); }
            else { return Ok(res); }
        }
    }
}
