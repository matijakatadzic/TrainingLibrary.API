using AutoMapper;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TrainingLibrary.API.Models;

namespace TrainingLibrary.API.Controllers
{
    [ApiController]
    [Route("api/authors/{authorId}/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseLibraryRepository _course;
        private readonly IMapper _mapper;

        public CoursesController(ICourseLibraryRepository course, IMapper mapper)
        {
            _course = course ??
                throw new ArgumentNullException(nameof(course));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseDto>> GetCoursesForAuthor(Guid authorId)
        {
            if(!_course.AuthorExists(authorId: authorId))
            {
                return NotFound();
            }

            var courses = _course.GetCourses(authorId);

            return Ok(_mapper.Map<IEnumerable<CourseDto>>(courses));
        }
    }
}
