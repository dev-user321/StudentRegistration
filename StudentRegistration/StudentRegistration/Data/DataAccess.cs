using Newtonsoft.Json;
using StudentRegistration.Models;

namespace StudentRegistration.Data
{
    public class DataAccess
    {
        private readonly string _path = "data.json";
        //Path deyismek
        public List<Student> GetAllStudents()
        {
            string jsonData = System.IO.File.ReadAllText(_path);
            return JsonConvert.DeserializeObject<List<Student>>(jsonData);
        }

        public void SaveStudents(List<Student> students)
        {
            var updatedJson = JsonConvert.SerializeObject(students, Formatting.Indented);
            System.IO.File.WriteAllText(_path, updatedJson);
        }
    }
}
