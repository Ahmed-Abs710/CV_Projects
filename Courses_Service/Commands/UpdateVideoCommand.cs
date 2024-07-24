using Courses_Service.DTOs;
using Courses_Service.Models;
using Courses_Service.Services;

namespace Courses_Service.Commands
{
    public class UpdateVideoCommand
    {
        public UpdateVideoCommand(VideoService videoService, int videoid, UpdateVideoDto updateVideoDto)
        {
            VideoService = videoService;
            Videoid = videoid;
            UpdateVideoDto = updateVideoDto;
        }

        public VideoService VideoService { get; }
        public int Videoid { get; }
        public UpdateVideoDto UpdateVideoDto { get; }

        public Task<Videos> Execute()
        {
            return VideoService.UpdateVideoAsync(Videoid, UpdateVideoDto);
        }
    }
}
