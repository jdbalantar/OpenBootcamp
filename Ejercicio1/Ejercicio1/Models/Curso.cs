using System.ComponentModel.DataAnnotations;

namespace Ejercicio1.Models
{
    public class Curso
    {
        public int Id { get; set; }
        [MaxLength]
        public string Nombre { get; set; } = string.Empty;
        [MaxLength(280)]
        public string DescripcionCorta { get; set; } = string.Empty;
        public string DescripcionLarga { get; set; } = string.Empty;
        public string PublicoObjetivo { get; set; } = string.Empty;
        public string Objetivos { get; set; } = string.Empty;
        public string Requisitos { get; set; } = string.Empty;
    }
}
