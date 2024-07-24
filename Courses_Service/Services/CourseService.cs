
using Courses_Service.DTOs;
using Courses_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Courses_Service.Services
{
    public class CourseService
    {
        public AppDbContext AppDbContext { get; }
        public IWebHostEnvironment WebHost { get; }

        public CourseService(AppDbContext appDbContext, IWebHostEnvironment webHost)
        {
            AppDbContext = appDbContext;
            WebHost = webHost;
        }
        public async Task<Courses> AddCourseAsync(CourseDto courseDto)
        {
            if (courseDto.CoursePic != null)
            {
               // var upload = AppContext.BaseDirectory + "\\Pics";
                var upload = "pics2/";
            var picfullname = Guid.NewGuid().ToString() + "_" + courseDto.CoursePic.FileName;
                var folder = Path.Combine(WebHost.WebRootPath, "pics2");
            var uploadpath = Path.Combine(folder, picfullname);
          // var picname = Path.GetFileName(courseDto.CoursePic);
          //  Directory.CreateDirectory(upload);
            
           
               
                    using (var resource2 = new FileStream(uploadpath, FileMode.Create))
                    {
                        await courseDto.CoursePic.CopyToAsync(resource2);
                    }
               // var remove = "E:\\Projects\\Education\\Education_Platform\\Courses_Service\\bin\\Debug\\net8.0\\Pics";
               // var clean = uploadpath.Replace(remove,"");
                var imgurl = $"https://localhost:7273/pics2/{picfullname}";
              //  var imgurl = Uri.ac
                var course = new Courses
                {
                    Instructor = courseDto.Instructor,
                    Description = courseDto.Description,
                    Title = courseDto.Title,
                    CoursePic = imgurl
                };
                await AppDbContext.courses.AddAsync(course);
                await AppDbContext.SaveChangesAsync();
                return course;

            }
            else
            {
                return null;
            }

           
        }

        public async Task<Courses> UpdateCourseAsync(int courseid,UpdateCourseDto courseDto)
        {
            var course = await AppDbContext.courses.FindAsync(courseid);
            if (course == null)
            {
                return null;
            }
            else
            {
                course.Description = courseDto.Description;
                course.Title = courseDto.Title;
                course.Instructor = courseDto.Instructor;
                AppDbContext.courses.Update(course);
                await AppDbContext.SaveChangesAsync();
                return course;
            }

        }

        public async Task<bool> DeleteCourseAsync(int courseid)
        {
            var res = await AppDbContext.courses.FindAsync(courseid);
            if (res == null)
            {
                return false;
            }
            else
            {
                AppDbContext.courses.Remove(res);
                await AppDbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Courses>GetCourseByIdAsync(int courseid)
        {
            var res = await AppDbContext.courses.FindAsync(courseid);
            if (res == null)
            {
                return null;
            }
            else
            {
                return res;
            }
        }

        public async Task<IEnumerable<Courses>> GetAllCoursesAsync()
        {
            return await AppDbContext.courses.ToListAsync();
        }

    }
}
