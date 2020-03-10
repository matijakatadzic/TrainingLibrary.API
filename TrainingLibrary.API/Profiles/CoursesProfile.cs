using AutoMapper;
using CourseLibrary.API.Entities;
using TrainingLibrary.API.Helpers;
using TrainingLibrary.API.Models;

namespace TrainingLibrary.API.Profiles
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {
            CreateMap<Course, CourseDto>();
        }
    }
}
