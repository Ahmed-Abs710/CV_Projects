using Courses_Service.DTOs;
using Courses_Service.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Courses_Service.Services
{
    public class VideoService
    {
        public AppDbContext AppDbContext { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        public VideoService(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            AppDbContext = appDbContext;
            WebHostEnvironment = webHostEnvironment;
        }
        public async Task<bool> AddVideoAsync( VideoDto videoDto)
        {
            //for example
            //E:\\Test\\01.07.2024_17.48.14_REC.mp4
            if (videoDto.videopath !=null && videoDto.courseid !=null)
            {
                // var filename = Path.GetFileName(videoDto.videopath);
                var uploadpath = Path.Combine(WebHostEnvironment.WebRootPath, "vids");
               // Directory.CreateDirectory(uploadpath);
                var uniqname = Guid.NewGuid().ToString() + "_" + videoDto.videopath.FileName;
                var filepath = Path.Combine(uploadpath, uniqname);
               
                    using (var destination = new FileStream(filepath, FileMode.Create))
                        await videoDto.videopath.CopyToAsync(destination);
                var vidurl = $"https://localhost:7273/vids/{uniqname}";
                var video = new Videos
                {
                    Description = videoDto.Description,
                    Title = videoDto.Title,
                    VideoUrl = vidurl,
                    CourseId = int.Parse(videoDto.courseid)
                };
                AppDbContext.videos.Add(video);
                await AppDbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
         
          
        }

        public async Task<Videos> UpdateVideoAsync(int videoid,UpdateVideoDto videoDto)
        {
            var res = await AppDbContext.videos.FindAsync(videoid);
            if (res == null)
            {
                return null;
            }
            else
            {
                res.Description = videoDto.Description;
                res.VideoUrl = videoDto.VideoUrl;
                res.Title = videoDto.Title;
                AppDbContext.videos.Update(res);
                await AppDbContext.SaveChangesAsync();
                return res;
            }
        }

        public async Task<bool> DeleteVideoAsync(int videoid)
        {
            var res = await AppDbContext.videos.FindAsync(videoid);
            if (res==null)
            {
                return false;
            }
            else
            {
                AppDbContext.videos.Remove(res);
                await AppDbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Videos> GetVideoByIdAsync(int videoid)
        {
            var res = await AppDbContext.videos.FindAsync(videoid);
            if (res == null)
            {
                return null;
            }
            else
            {
                return res;
            }
        }

        public async Task<IEnumerable<Videos>> GetVideosByCourseId(int courseid)
        {
            var res = await AppDbContext.videos.Where(x => x.CourseId == courseid).ToListAsync();
            if (res == null)
            {
                return null;
            }
            else
            {
                return res;
            }
        }
    }
}
