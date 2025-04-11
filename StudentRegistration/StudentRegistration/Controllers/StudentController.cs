using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentRegistration.Data;
using StudentRegistration.Models;

namespace StudentRegistration.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataAccess _dataAccess;

        public StudentController()
        {
            _dataAccess = new DataAccess();
        }

        public IActionResult Index()
        {
            var studentList = _dataAccess.GetAllStudents();
            var students = studentList.FindAll(m => !m.IsDeleted);
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
            var students = _dataAccess.GetAllStudents();
            students.Add(student);
            _dataAccess.SaveStudents(students);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string? id)
        {
            if (id == null) return BadRequest();
            var students = _dataAccess.GetAllStudents();
            var student = students.Find(x => x.Id == id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(string? id, Student student)
        {
            if (id == null) return BadRequest();
            var students = _dataAccess.GetAllStudents();
            var oldStudent = students.Find(x => x.Id == id);
            if (oldStudent == null) return NotFound();
            oldStudent.Name = student.Name;
            oldStudent.Email = student.Email;
            oldStudent.Phone = student.Phone;
            oldStudent.GroupNumber = student.GroupNumber;
            oldStudent.Surname = student.Surname;
            oldStudent.Age = student.Age;
            oldStudent.Specialty = student.Specialty;
            _dataAccess.SaveStudents(students);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string? id)
        {
            if (id == null) return BadRequest();
            var students = _dataAccess.GetAllStudents();
            var student = students.Find(x => x.Id == id);
            if (student == null) return NotFound();
            student.IsDeleted = true;
            _dataAccess.SaveStudents(students);
            return RedirectToAction("Index");
        }

        public IActionResult Detail(string id)
        {
            var students = _dataAccess.GetAllStudents();
            var student = students.Find(x => x.Id == id);
            return View(student);
        }
    }

}
