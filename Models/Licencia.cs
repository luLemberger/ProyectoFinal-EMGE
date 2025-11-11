namespace LicenciasAPI.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Licencia
    {
        public int Id { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 8)]
        public string DNI { get; set; } = null!;

        [Required]
        public string Tipo { get; set; } = null!; 

        [Required]
        public string Provincia { get; set; } = null!;

        [Required]
        public string Localidad { get; set; } = null!;

        [Required]
        public string Direccion { get; set; } = null!;

        [Required]
        [StringLength(10, MinimumLength = 6)]
        public string OrdenDelDia { get; set; } = null!;

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }
    }
}
