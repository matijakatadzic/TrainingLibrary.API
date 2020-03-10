using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TrainingLibrary.API.Controllers
{
    [ApiController]
    public class AuthorsController : ControllerBase // not form Controller -> we dont need Views 
    {
        private readonly ICourseLibraryRepository _course;

        public AuthorsController(ICourseLibraryRepository course)
        {
            _course = course ??
                throw new ArgumentNullException(nameof(course));
        }

        [HttpGet("api/authors")]
        public IActionResult GetAuthors()
        {
            var authors = _course.GetAuthors();
            return new JsonResult(authors);
        }
    }
}
