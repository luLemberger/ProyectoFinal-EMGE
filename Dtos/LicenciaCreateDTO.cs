namespace LicenciasAPI.Dtos
{
    public class LicenciaCreateDto
    {
        public string DNI { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string Provincia { get; set; } = null!;
        public string Localidad { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string OrdenDelDia { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
