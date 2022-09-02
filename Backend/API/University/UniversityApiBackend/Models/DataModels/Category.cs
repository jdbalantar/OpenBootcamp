using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.DataModels
{
    public class Category : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
