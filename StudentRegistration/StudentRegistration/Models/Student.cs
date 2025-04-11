namespace StudentRegistration.Models
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Specialty { get; set; }
        public string GroupNumber { get; set; }
        public string Phone { get; set; }
 
    }
}
