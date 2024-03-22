using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace App1
{
    public partial class FacturaPage : ContentPage
    {
        private static int numeroConsecutivo = 1;

        // Propiedad para vincular el número de factura con el Label en el XAML
        public int NumeroFactura { get; set; }

        private ObservableCollection<ItemMenu> carrito;

        // Constructor y otros miembros de la clase

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

            // Guardar el carrito en un campo de la clase
            this.carrito = carrito;
        }

        // Método para manejar el evento de visualizar estado del pedido
        async void OnVisualizarEstadoPedidoClicked(object sender, EventArgs e)
        {
            // Aquí colocas la lógica para abrir la página de visualización del estado del pedido
            // Por ejemplo:
            EstadoPage estadoPage = new EstadoPage(this.carrito);
            await Navigation.PushAsync(estadoPage);
        }
    }


}
