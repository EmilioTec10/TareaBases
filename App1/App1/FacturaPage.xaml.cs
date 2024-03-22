using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace App1
{
    public partial class FacturaPage : ContentPage
    {
        // Variable estática para mantener el número consecutivo
        private static int numeroConsecutivo = 1;

        // Propiedad para vincular el número de factura con el Label en el XAML
        public int NumeroFactura { get; set; }

        public FacturaPage(ObservableCollection<ItemMenu> carrito, double total)
        {
            InitializeComponent();

            // Obtener el número consecutivo y luego incrementarlo para la próxima factura
            NumeroFactura = numeroConsecutivo++;

            // Lógica para generar la factura
            DateTime fechaHora = DateTime.Now;
            string factura = $"Fecha y Hora: {fechaHora}\n\n";

            foreach (var item in carrito)
            {
                factura += $"Producto: {item.Nombre}\n";
                factura += $"Cantidad: {item.Cantidad}\n";
                factura += $"Precio Unitario: {item.Precio:C}\n";
                factura += $"Subtotal: {item.PrecioTotal:C}\n\n";
            }

            factura += $"Total a Pagar: {total:C}";

            FacturaLabel.Text = factura;

            // Establecer el contexto de datos de la página como esta instancia de FacturaPage
            BindingContext = this;
        }
    }
}
