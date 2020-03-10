using AutoMapper;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TrainingLibrary.API.Helpers;
using TrainingLibrary.API.Models;

namespace TrainingLibrary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase // not form Controller -> we dont need Views 
    {
        private readonly ICourseLibraryRepository _course;
        private readonly IMapper _mapper;

        public AuthorsController(ICourseLibraryRepository course, IMapper mapper)
        {
            _course = course ??
                throw new ArgumentNullException(nameof(course));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors()
        {
            var authorsCourse = _course.GetAuthors();
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsCourse));
        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var author = _course.GetAuthor(authorId: authorId);

            if(author == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDto>(author));
        }
    }
}
