using System.ComponentModel; // Agregar este using para INotifyPropertyChanged

namespace App1
{
    public class ItemMenu : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }

        private double precio;
        public double Precio
        {
            get { return precio; }
            set
            {
                precio = value;
                OnPropertyChanged(nameof(Precio));
            }
        }

        private int cantidad;
        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                cantidad = value;
                OnPropertyChanged(nameof(Cantidad));
                OnPropertyChanged(nameof(PrecioTotal));
            }
        }

        // Agregar propiedad PrecioTotal
        public double PrecioTotal
        {
            get { return Precio * Cantidad; }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
