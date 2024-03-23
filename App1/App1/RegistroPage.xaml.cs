using System;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace App1
{
    public partial class RegistroPage : ContentPage
    {
        public RegistroPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            // Verificar que los campos obligatorios estén completos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCorreoElectronico.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos obligatorios.", "OK");
                return;
            }


            DateTime fechaNacimiento;
            if (!DateTime.TryParseExact(txtFechaNacimiento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaNacimiento))
            {
                await DisplayAlert("Error", "El formato de fecha de nacimiento es incorrecto. Por favor, utilice el formato dd/MM/yyyy.", "OK");
                return;
            }


            // Crear una instancia de Usuario con los datos del formulario
            Usuario nuevoUsuario = new Usuario
            {
                Nombre = txtNombre.Text,
                CorreoElectronico = txtCorreoElectronico.Text,
                Password = txtContrasena.Text,
                FechaNacimiento = fechaNacimiento,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text
            };

            try
            {
                // Serializar el objeto Usuario a JSON
                string usuarioJson = JsonConvert.SerializeObject(nuevoUsuario);

                // Obtener la ruta del archivo usuarios.json
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "usuarios.json");


                // Escribir el JSON en el archivo
                File.WriteAllText(filePath, usuarioJson);

                // Mostrar mensaje de creación exitosa
                await DisplayAlert("Registrarse", "¡Registro exitoso! Por favor, inicie sesión nuevamente.", "OK");

                // Navegar a la página de inicio de sesión (asumiendo que LoginPage es la página de inicio de sesión)
                await Navigation.PopAsync(); // Vuelve a la página anteriorr
            }
            catch (Exception ex)
            {
                // Manejar cualquier error al guardar la información del usuario
                await DisplayAlert("Error", $"Ha ocurrido un error al guardar la información del usuario: {ex.Message}", "OK");
            }
        }
    }
}
