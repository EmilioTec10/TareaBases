using System;

namespace App1
{
    public class Usuario
    {
        // Propiedades de Usuario
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Password { get; set; }

        // Constructor
        public Usuario()
        {
            // Inicialización si es necesario
        }
    }
}
