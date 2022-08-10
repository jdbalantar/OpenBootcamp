using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.DataModels
{
    public class Student : BaseEntity
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public int Dob { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
