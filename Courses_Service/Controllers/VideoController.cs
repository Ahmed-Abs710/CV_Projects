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
    public class VideoController : ControllerBase
    {
        public VideoService VideoService { get; }

        public VideoController(VideoService videoService)
        {
            VideoService = videoService;
        }
        [HttpPost]
        [Route("AddVideoToCourse")]
        public async Task<IActionResult> AddVideoToCourse([FromForm] VideoDto videoDto)
        {
            var video = new AddVideoToCourseCommand(VideoService,videoDto);
            var res = await video.Execute();
            if (Convert.ToBoolean(res) == true)
            {
                return Ok("Video Uploded");
            }
            else
            {
               return BadRequest("Connot Upload Video");
            }
        }

        [HttpGet]
        [Route("GetAllVideosForCourse")]
        public async Task<IActionResult> GetAllVideosForCourse(int courseid)
        {
            var Videos= new GetVideosByCourseIdQuery(VideoService,courseid);
            var res =await Videos.Execute();
            if (res== null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpGet]
        [Route("GetVideoById")]
        public async Task<IActionResult> GetVideoById(int videoid)
        {
            var Video = new GetVideoByIdQuery(VideoService, videoid);
            var res =await Video.Execute();
            if (res==null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpPut]
        [Route("UpdateVideo")]
        public async Task<IActionResult> UpdateVideo(int videoid, [FromBody] UpdateVideoDto updateVideoDto)
        {
            var video = new UpdateVideoCommand(VideoService, videoid, updateVideoDto);
            var res =await video.Execute();
            if (res==null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpDelete]
        [Route("DeleteVideo")]
        public async Task<IActionResult> DeleteVideo(int videoid)
        {
            var video = new DeleteVideoFromCourse(VideoService , videoid);
            var res =await video.Execute();
            if (Convert.ToBoolean(res) == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok(res);
            }
        }



    }
}
