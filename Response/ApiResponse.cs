namespace LicenciasAPI.Response
{
    public class ApiResponse<T>
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public T? Contenido { get; set; }

        public static ApiResponse<T> Success(T? contenido, string mensaje = "Operación exitosa.")
            => new ApiResponse<T> { Codigo = 200, Mensaje = mensaje, Contenido = contenido };

        public static ApiResponse<T> BadRequest(string mensaje)
            => new ApiResponse<T> { Codigo = 400, Mensaje = mensaje };

        public static ApiResponse<T> NotFound(string mensaje)
            => new ApiResponse<T> { Codigo = 404, Mensaje = mensaje };

        public static ApiResponse<T> ServerError(string mensaje = "Error interno del servidor.")
            => new ApiResponse<T> { Codigo = 500, Mensaje = mensaje };
    }
}
