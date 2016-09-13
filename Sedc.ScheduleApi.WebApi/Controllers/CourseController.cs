using Microsoft.AspNetCore.Mvc;
using Sedc.ScheduleApi.Data.Abstract;
using Sedc.ScheduleApi.Model.Entities;
using Sedc.ScheduleApi.WebApi.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Sedc.ScheduleApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private ICourseRepository _courseRepository;
        private IScheduleRepository _scheduleRepository;

        public CourseController(ICourseRepository courseRepository, IScheduleRepository scheduleRepository)
        {
            _courseRepository = courseRepository;
            _scheduleRepository = scheduleRepository;
        }

        public IActionResult Get()
        {
            IEnumerable<Course> courses = _courseRepository
                .GetAll()
                .OrderBy(c => c.Id)
                .ToList();

            IEnumerable<CourseViewModel> coursesVm = courses.Select(
                x => new CourseViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    LengthHours = x.LengthHours
                })
            .ToArray();

            return new OkObjectResult(coursesVm);
        }

        [HttpGet("{id}", Name = "GetCourse")]
        public IActionResult Get(int id)
        {
            Course course = _courseRepository.GetSingle(id);

            if (course != null)
            {
                var courseVm = new CourseViewModel
                {
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                    LengthHours = course.LengthHours
                };

                return new OkObjectResult(courseVm);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/schedules", Name = "GetCourseSchedules")]
        public IActionResult GetSchedules(int id)
        {
            IEnumerable<Schedule> schedules = _scheduleRepository.FindBy(s => s.CourseId == id);

            if (schedules != null)
            {
                IEnumerable<ScheduleViewModel> _userSchedulesVM = schedules.Select(
                    x => new ScheduleViewModel
                    {
                        Id = x.Id,
                        Starting = x.Starting,
                        Ending = x.Ending,
                        DurationHours = x.DurationHours
                    });
                return new OkObjectResult(_userSchedulesVM);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("report", Name = "GetCourseReport")]
        public IActionResult GetCourseReport()
        {
            var courses = _courseRepository.GetCoursesReport();
            return Ok(courses);
        }

        [HttpPost]
        public IActionResult Create([FromBody]CourseViewModel course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Course newCourse = new Course
            {
                Name = course.Name,
                Description = course.Description,
                LengthHours = course.LengthHours
            };

            _courseRepository.Add(newCourse);
            _courseRepository.Commit();

            CreatedAtRouteResult result = CreatedAtRoute("GetCourse", new { controller = "Course", id = newCourse.Id }, newCourse);
            return result;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]CourseViewModel course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Course found = _courseRepository.GetSingle(id);

            if (found == null)
            {
                return NotFound();
            }
            else
            {
                found.Name = course.Name;
                found.Description = course.Description;
                found.LengthHours = course.LengthHours;
                _courseRepository.Commit();
            }

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Course found = _courseRepository.GetSingle(id);

            if (found == null)
            {
                return NotFound();
            }
            else
            {
                IEnumerable<Schedule> schedules = _scheduleRepository.FindBy(s => s.CourseId == id);

                foreach (var schd in schedules)
                {
                    _scheduleRepository.Delete(schd);
                }

                _courseRepository.Delete(found);

                _scheduleRepository.Commit();
                _courseRepository.Commit();

                return new NoContentResult();
            }
        }

    }
}
