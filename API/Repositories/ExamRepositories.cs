﻿using API.Data;
using API.DBContext;
using API.Enity;

namespace API.Repositories
{
    public interface IExamRepositories : IRepository<Exam>
    {
        public void insertExam(Exam exam);
        public void deleteExam(Exam exam);
        public void updateExam(Exam exam);
        public Exam getbyid(object id);
    }
    public class ExamRepository : RepositoryBase<Exam>, IExamRepositories
    {
        public ExamRepository(DB dbContext) : base(dbContext)
        {
        }
        public void insertExam(Exam exam)
        {
            _dbContext.exams.Add(exam);
        }
        public void deleteExam(Exam exam)
        {
            _dbContext.exams.Remove(exam);
        }
        public void updateExam(Exam exam)
        {
            _dbContext.exams.Attach(exam);
            _dbContext.Entry(exam).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public Exam getbyid(object id)
        {
            return _dbContext.exams.Find(id);
        }
    }
}
