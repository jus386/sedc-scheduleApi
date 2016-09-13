using Microsoft.AspNetCore.Mvc;
using Sedc.ScheduleApi.Data.Abstract;
using Sedc.ScheduleApi.Model.Entities;
using Sedc.ScheduleApi.WebApi.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Sedc.ScheduleApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IActionResult Get()
        {
            IEnumerable<Student> students = _studentRepository
                .GetAll()
                .OrderBy(c => c.Id)
                .ToList();

            IEnumerable<StudentViewModel> studentsVm = students.Select(
                x => new StudentViewModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                })
            .ToArray();

            return new OkObjectResult(studentsVm);
        }
    }
}
