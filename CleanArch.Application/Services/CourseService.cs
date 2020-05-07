using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMediatorHandler bus, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _bus = bus;
            _mapper = mapper;
        }

        public IEnumerable<CoursesViewModel> GetCourses()
        {
            return _courseRepository.GetCourses().ProjectTo<CoursesViewModel>(_mapper.ConfigurationProvider);
        }

        public void Create(CoursesViewModel coursesViewModel)
        {
           // var createCourseCommand = new CreateCourseCommand(coursesViewModel.Name, coursesViewModel.Description, coursesViewModel.ImageUrl);

            _bus.SendCommand(_mapper.Map<CreateCourseCommand>(coursesViewModel));
        }
    }
}
