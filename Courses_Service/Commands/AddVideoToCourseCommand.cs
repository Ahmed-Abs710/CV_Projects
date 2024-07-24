using Courses_Service.DTOs;
using Courses_Service.Services;

namespace Courses_Service.Commands
{
    public class AddVideoToCourseCommand
    {
        public AddVideoToCourseCommand(VideoService videoService, VideoDto videoDto)
        {
            VideoService = videoService;
            VideoDto = videoDto;
        }

        public VideoService VideoService { get; }
        public int Courseid { get; }
        public IFormFile FormFile { get; }
        public string Videopath { get; }
        public VideoDto VideoDto { get; }

        public async Task<bool> Execute()
        {
            return await VideoService.AddVideoAsync(VideoDto);
        }
    }
}
