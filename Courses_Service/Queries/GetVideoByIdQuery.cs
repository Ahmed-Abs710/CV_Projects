using Courses_Service.Models;
using Courses_Service.Services;

namespace Courses_Service.Queries
{
    public class GetVideoByIdQuery
    {
        public GetVideoByIdQuery(VideoService videoService, int videoid)
        {
            VideoService = videoService;
            Videoid = videoid;
        }

        public VideoService VideoService { get; }
        public int Videoid { get; }

        public Task<Videos> Execute()
        {
            return VideoService.GetVideoByIdAsync(Videoid);
        }
    }
}
