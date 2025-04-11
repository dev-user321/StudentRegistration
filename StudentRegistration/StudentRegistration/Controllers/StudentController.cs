using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentRegistration.Data;
using StudentRegistration.Models;
using StudentRegistration.Services;

namespace StudentRegistration.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();  
        }

        public IActionResult Index()
        {
            var students = _studentService.GetAllStudents().FindAll(m => !m.IsDeleted);
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (student == null) return BadRequest();
            student.Id = Guid.NewGuid().ToString();
            _studentService.AddStudent(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string? id)
        {
            if (id == null) return BadRequest();
            var student = _studentService.GetStudentById(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(string? id, Student student)
        {
            if (id == null) return BadRequest();
            _studentService.UpdateStudent(id, student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string? id)
        {
            if (id == null) return BadRequest();
            _studentService.DeleteStudent(id);
            return RedirectToAction("Index");
        }

        public IActionResult Detail(string id)
        {
            var student = _studentService.GetStudentById(id);
            return View(student);
        }
    }

}
