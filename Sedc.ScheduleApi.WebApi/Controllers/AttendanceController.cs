using Microsoft.AspNetCore.Mvc;
using Sedc.ScheduleApi.Data.Abstract;
using Sedc.ScheduleApi.Model.Entities;
using Sedc.ScheduleApi.WebApi.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Sedc.ScheduleApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AttendanceController : Controller
    {
        private IAttandanceRepository _attRepository;

        public AttendanceController(IAttandanceRepository attRepository)
        {
            _attRepository = attRepository;
        }

        [HttpGet("getForSchedule/{id}")]
        public IActionResult GetForSchedule(int id)
        {
            var attendances = _attRepository.FindBy(x => x.ScheduleId == id);
            var attendancesVms = attendances.Select(x => new
            AttendanceViewModel
            {
                Id = x.Id,
                StudentId = x.StudentId,
                ScheduleId = x.ScheduleId
            })
            .ToList();
            return Ok(attendancesVms);
        }

        [HttpPost]
        public IActionResult Create([FromBody]MultiAttendanceViewModel att)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get existing attendances
            var newState = _attRepository
                .FindBy(x => att.StudentsIds.Contains(x.StudentId) && x.ScheduleId == att.ScheduleId);
            // Identify student ids not found in existing attendances
            var newStudentIds = att.StudentsIds.Where(x => newState.All(y => y.StudentId != x));
            // Insert new attendances
            foreach (var studentId in newStudentIds)
            {
                Attendance newAtt = new Attendance
                {
                    ScheduleId = att.ScheduleId,
                    StudentId = studentId
                };

                _attRepository.Add(newAtt);
            }

            // Identify attendances not found in new student ids
            var forDelete = _attRepository
                .FindBy(x => !att.StudentsIds.Contains(x.StudentId) && x.ScheduleId == att.ScheduleId);
            // Delete attendances
            foreach (var attToDelete in forDelete)
            {
                _attRepository.Delete(attToDelete);
            }
                        
            _attRepository.Commit();

            return Ok();
        }
    }
}
