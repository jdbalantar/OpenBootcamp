using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.DataModels
{
    /// <summary>
    /// Clase que contiene todos los campos que estarán presnete en las tablas de nuestra base de datos
    /// </summary>
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public string DeletedBy { get; set; } = string.Empty;
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;



    }
}
