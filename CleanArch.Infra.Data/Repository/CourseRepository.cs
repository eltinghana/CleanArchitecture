using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;

namespace CleanArch.Infra.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly UniversityDbContext _dbContext;

        public CourseRepository(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Course> GetCourses()
        {
            return _dbContext.Courses;
        }

        public void Add(Course course)
        {
            _dbContext.Add(course);
            _dbContext.SaveChanges();
        }
    }
}
