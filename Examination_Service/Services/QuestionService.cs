using Examination_Service.DTOs;
using Examination_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Examination_Service.Services
{
    public class QuestionService
    {
        public AppDbContext AppDbContext { get; }

        public QuestionService(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }
        public async Task<Question> CreateQuestionAsync(QuestionDto questionDto)
        {
            if (questionDto != null)
            {
                var add = new Question
                {
                    ExamId = questionDto.ExamId,
                    Text = questionDto.Text
                };
                await AppDbContext.Questions.AddAsync(add);
                await AppDbContext.SaveChangesAsync();
                return add;
            }
            return null;
        }

        public async Task<Question> GetQuestionByIdAsync(int QuestionId)
        {
            if (QuestionId != 0)
            {
                return await AppDbContext.Questions.FindAsync(QuestionId);
            }
            return null;
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsAsync()
        {
            var res = await AppDbContext.Questions.ToListAsync();
            if (res != null)
            {
                return res;
            }
            return null;
        }

        public async Task<Question> UpdateQuestionAsync(int questionid,UpdateQuestionDto updateQuestionDto)
        {
            if (questionid != 0 && updateQuestionDto != null)
            {
                var res = await AppDbContext.Questions.FindAsync(questionid);
                if (res != null)
                {
                    res.ExamId = updateQuestionDto.ExamId;
                    res.Text = updateQuestionDto.Text;
                    AppDbContext.Questions.Update(res);
                    await AppDbContext.SaveChangesAsync();
                    return res;
                }
            }
            return null;
        }

        public async Task<bool> DeleteQuestionAsync(int QuestionId)
        {
            if (QuestionId != 0)
            {
                var res = await AppDbContext.Questions.FindAsync(QuestionId);
                if (res != null)
                {
                    AppDbContext.Questions.Remove(res);
                    await AppDbContext.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsByExamIdAsync(int examid)
        {
            var res = await AppDbContext.Questions.Where(x=>x.ExamId == examid).ToListAsync();
            if (res != null)
            {
                return res;
            }
            return null;
        }

    }
}
