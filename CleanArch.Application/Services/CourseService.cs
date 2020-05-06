using System;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Commands;
using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMediatorHandler _bus;

        public CourseService(ICourseRepository courseRepository, IMediatorHandler bus)
        {
            _courseRepository = courseRepository;
            _bus = bus;
        }

        public CoursesViewModel GetCourses()
        {
            return new CoursesViewModel { Courses = _courseRepository.GetCourses() };
        }

        public void Create(CoursesViewModel coursesViewModel)
        {
            var createCourseCommand = new CreateCourseCommand(coursesViewModel.Name, coursesViewModel.Description, coursesViewModel.ImageUrl);
            _bus.SendCommand(createCourseCommand);
        }
    }
}
