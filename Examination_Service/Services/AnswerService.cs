using Examination_Service.DTOs;
using Examination_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Examination_Service.Services
{
    public class AnswerService
    {
        public AppDbContext AppDbContext { get; }

        public AnswerService(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }
        public async Task<Answer> CreateAnswerAsync(AnswerDto answerDto)
        {
            if (answerDto !=null)
            {
                var add = new Answer { 
                    IsCorrect = answerDto.IsCorrect,
                    QuestionId = answerDto.QuestionId,
                    Text = answerDto.Text
                };
                await AppDbContext.Answers.AddAsync(add);
                await AppDbContext.SaveChangesAsync();
                return add;
            }
            return null;
        }

        public async Task<Answer> GetAnswerByIdAsync(int AnswerId)
        {
            if (AnswerId != 0)
            {
                return await AppDbContext.Answers.FindAsync(AnswerId);
            }
            return null;
        }

        public async Task<Answer> UpdateAnswerAsync(int answerid,UpdateAnswerDto updateAnswerDto)
        {
            if (answerid != 0 && updateAnswerDto != null)
            {
                var res = await AppDbContext.Answers.FindAsync(answerid);
                if (res != null) 
                {
                    res.IsCorrect = updateAnswerDto.IsCorrect;
                    res.Text = updateAnswerDto.Text;
                    res.QuestionId = updateAnswerDto.QuestionId;
                    AppDbContext.Answers.Update(res);
                    await AppDbContext.SaveChangesAsync();
                    return res;
                }
            }
            return null;
        }

        public async Task<bool> DeleteAnswerAsync(int AnswerId)
        {
            if (AnswerId != 0)
            {
                var res = await AppDbContext.Answers.FindAsync(AnswerId);
                if (res != null)
                {
                    AppDbContext.Answers.Remove(res);
                    await AppDbContext.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Answer>> GetAllAnswersByQuestionIdAsync(int questionid)
        {
            var res = await AppDbContext.Answers.Where(x=>x.QuestionId == questionid).ToListAsync();
            if (res != null)
            {
                return res;
            }
            return null;
        }
    }
}
