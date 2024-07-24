using Examination_Service.DTOs;
using Examination_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Examination_Service.Services
{
    public class ExamService
    {
        public AppDbContext AppDbContext { get; }

        public ExamService(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }
        public async Task<Exam> CreateExamAsync(ExamDto examDto)
        {
            if (examDto != null)
            {
                var res =new Exam{
                    CreateDate=  examDto.CreateDate,
                    UpdateDate=  examDto.UpdateDate,
                    Title= examDto.Title
                };
               await AppDbContext.Exams.AddAsync(res);
               await AppDbContext.SaveChangesAsync();
               return res;
            }
            return null;
        }

        public async Task<Exam> UpdateExamAsync(int examid,UpdateExamDto updateExamDto)
        {
            if (updateExamDto != null)
            {
                var res = await AppDbContext.Exams.FindAsync(examid);
                if (res != null)
                {
                    res.CreateDate = updateExamDto.CreateDate;
                    res.UpdateDate = updateExamDto.UpdateDate;
                    res.Title = updateExamDto.Title;
                    AppDbContext.Exams.Update(res);
                    await AppDbContext.SaveChangesAsync();
                    return res;
                }
            }
            return null;
        }

        public async Task<bool> DeleteExamAsync(int examid)
        {
            if (examid != 0)
            {
                var res = await AppDbContext.Exams.FindAsync(examid);
                if (res !=null)
                {
                    AppDbContext.Exams.Remove(res);
                    await AppDbContext.SaveChangesAsync();
                }
                return true;
            }
            return false;
        }

        public async Task<Exam> GetExamByIdAsync(int examid)
        {
            if (examid !=0 )
            {
                var res = await AppDbContext.Exams.FindAsync(examid);
                if (res != null)
                {
                    return res;
                }
            }
            return null;
        }

        public async Task<IEnumerable<Exam>> GetAllExamsAsync()
        {  
                var res = await AppDbContext.Exams.ToListAsync();
                if (res != null)
                {
                    return res;
                }      
            return null;
        }

        public async Task<StudentAnswer> SubmitAnswerAsync(SubmitAnswerDto submitAnswerDto)
        {
            if (submitAnswerDto != null)
            {
                var res = await AppDbContext.studentAnswers.FindAsync(submitAnswerDto.QuestionId);
                if (res !=null)
                {

                    res.StudentId = submitAnswerDto.StudentId;
                    res.QuestionId = submitAnswerDto.QuestionId;
                    res.IsCorrect = submitAnswerDto.IsCorrect;
                    res.Answer = submitAnswerDto.Answer;
                    res.ExamId = submitAnswerDto.ExamId;
                  
                    AppDbContext.studentAnswers.Update(res);
                    await AppDbContext.SaveChangesAsync();
                    return res;
                }
                else
                {
                    var val = new StudentAnswer
                    {
                        StudentId = submitAnswerDto.StudentId,
                        QuestionId = submitAnswerDto.QuestionId,
                        IsCorrect = submitAnswerDto.IsCorrect,
                        Answer = submitAnswerDto.Answer,
                        ExamId = submitAnswerDto.ExamId
                    };
                    await AppDbContext.studentAnswers.AddAsync(val);
                    await AppDbContext.SaveChangesAsync();
                    return val;
                }
            }
            return null;
        }

        public async Task<double> CalculateResultAsync(CalculateResultDto calculateResultDto)
        {
            if (calculateResultDto != null)
            {
                var res = await AppDbContext.studentAnswers.Where(x => x.StudentId == calculateResultDto.StudentId
                && x.ExamId == calculateResultDto.ExamId).ToListAsync();
                if (res != null)
                {
                    int c = 0;
                    foreach (var item in res)
                    {
                        if (item.IsCorrect == true)
                        {
                            c++;
                        }
                        else
                        {
                            continue;
                        }
                    }         
                    return c;
                }
            }
            return 0;
        }


        public async Task<ExamResult> CreateExamResultAsync(CalculateResultDto calculateResultDto)
        {
            if (calculateResultDto != null)
            {
                double score =await CalculateResultAsync(calculateResultDto);
                if (score != null)
                {
                    var add = new ExamResult
                    {
                        ExamId = calculateResultDto.ExamId,
                        StudentId = calculateResultDto.StudentId,
                        Score = score
                    };
                    await AppDbContext.examResults.AddAsync(add);
                    await AppDbContext.SaveChangesAsync();
                    return add;
                }
            }
            return null;
        }
    }
}
