using Courses_Service.Models;
using Courses_Service.Services;

namespace Courses_Service.Queries
{
    public class GetVideosByCourseIdQuery
    {
        public GetVideosByCourseIdQuery(VideoService videoService, int courseid)
        {
            VideoService = videoService;
            Courseid = courseid;
        }

        public VideoService VideoService { get; }
        public int Courseid { get; }

        public Task<IEnumerable<Videos>> Execute() 
        {
            return VideoService.GetVideosByCourseId(Courseid);
        }
    }
}
