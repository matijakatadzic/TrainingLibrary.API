using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TrainingLibrary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase // not form Controller -> we dont need Views 
    {
        private readonly ICourseLibraryRepository _course;

        public AuthorsController(ICourseLibraryRepository course)
        {
            _course = course ??
                throw new ArgumentNullException(nameof(course));
        }

        [HttpGet()]
        public IActionResult GetAuthors()
        {
            var authors = _course.GetAuthors();
            return Ok(authors);
        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var author = _course.GetAuthor(authorId: authorId);

            if(author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }
    }
}
