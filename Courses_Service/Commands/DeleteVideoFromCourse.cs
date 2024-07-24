using Courses_Service.Services;

namespace Courses_Service.Commands
{
    public class DeleteVideoFromCourse
    {
        public DeleteVideoFromCourse(VideoService videoService, int videoid)
        {
            VideoService = videoService;
            Videoid = videoid;
        }

        public VideoService VideoService { get; }
        public int Videoid { get; }

        public Task<bool> Execute() 
        { 
             return VideoService.DeleteVideoAsync(Videoid);
        }
    }
}
