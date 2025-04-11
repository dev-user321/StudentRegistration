using StudentRegistration.Data;
using StudentRegistration.Models;

namespace StudentRegistration.Services
{
    public class StudentService
    {
        private readonly DataAccess _dataAccess;

        public StudentService()
        {
            _dataAccess = new DataAccess();  
        }

        public List<Student> GetAllStudents()
        {
            return _dataAccess.GetAllStudents();
        }

        public void SaveStudents(List<Student> students)
        {
            _dataAccess.SaveStudents(students);
        }

        public Student GetStudentById(string id)
        {
            var students = GetAllStudents();
            return students.Find(x => x.Id == id);
        }

        public void AddStudent(Student student)
        {
            var students = GetAllStudents();
            students.Add(student);
            SaveStudents(students);
        }

        public void UpdateStudent(string id, Student updatedStudent)
        {
            var students = GetAllStudents();
            var student = students.Find(x => x.Id == id);
            if (student != null)
            {
                student.Name = updatedStudent.Name;
                student.Email = updatedStudent.Email;
                student.Phone = updatedStudent.Phone;
                student.GroupNumber = updatedStudent.GroupNumber;
                student.Surname = updatedStudent.Surname;
                student.Age = updatedStudent.Age;
                student.Specialty = updatedStudent.Specialty;
                SaveStudents(students);
            }
        }

        public void DeleteStudent(string id)
        {
            var students = GetAllStudents();
            var student = students.Find(x => x.Id == id);
            if (student != null)
            {
                student.IsDeleted = true;
                SaveStudents(students);
            }
        }
    }
}
