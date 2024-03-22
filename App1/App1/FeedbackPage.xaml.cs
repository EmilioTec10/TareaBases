using System;
using Xamarin.Forms;

namespace App1
{
    public partial class FeedbackPage : ContentPage
    {
        public FeedbackPage()
        {
            InitializeComponent();
        }

        private async void EnviarFeedbackClicked(object sender, EventArgs e)
        {
            if (!int.TryParse(calificacionEntry.Text, out int calificacion) || calificacion < 1 || calificacion > 5)
            {
                await DisplayAlert("Error", "Por favor, ingresa una calificación válida (1-5).", "OK");
                return;
            }

            // Crear una instancia de Feedback directamente aquí
            var feedback = new Feedback
            {
                Usuario = "Usuario Ejemplo",
                Fecha = DateTime.Now,
                Calificacion = calificacion
            };

            await DisplayAlert("Éxito", "¡Gracias por tu feedback!", "OK");

            await Navigation.PopAsync();
        }

        // Definir la clase Feedback aquí dentro de la clase FeedbackPage
        public class Feedback
        {
            public string Usuario { get; set; }
            public DateTime Fecha { get; set; }
            public int Calificacion { get; set; }
        }
    }
}
