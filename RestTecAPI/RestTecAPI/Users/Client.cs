using System;
using System.Numerics;
using System.Reflection;

namespace RestTecAPI.Entities
{
    public class Client : Person
    {
        public int id { get; set; }
        public string name { get; set; }

        public string last_name { get; set; }

        public string address { get; set; }

        public string birth_date { get; set; }

        public string email { get; set; }

        public string password {  get; set; }

        public LinkedList<int> phones { get; set; }

        private ShoppingCart cart { get; set; }

        private Order order { get; set; }

        const string data_base = "C:\\Users\\manue\\Escritorio\\RestTec-TareaCorta\\RestTecAPI\\RestTecAPI\\DataBases\\Users.txt";
        public void register(string name, string last_name, string address, string birth_date, int phones, 
            string email, string password)
        {
            using (StreamWriter writer = new StreamWriter(data_base))
            {
                writer.WriteLine($"{name},{last_name},{address},{birth_date},{phones},{email},{password},client");
            }

        }

        public bool login(string email, string password)
        {
            bool isRegisteredClient = false;

            using (StreamReader reader = new StreamReader(data_base))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    // Verificar si el correo electrónico y la contraseña coinciden
                    if (parts.Length >= 4 && parts[5] == email && parts[6] == password)
                    {
                        if (parts[7] == "client")
                        {
                            // Se encontró una coincidencia, se asume que es un cliente registrado
                            isRegisteredClient = true;
                            // No es necesario continuar el bucle, podemos salir
                            break;
                        }
                    }
                }
            }

            return isRegisteredClient;
        }

        public void create_cart()
        {
            cart = new ShoppingCart();
        }

        public bool add_to_cart(int index, int quantity)
        {
            int currentIndex = 0;
            foreach (Plate plate in Menu.plates)
            {
                if (currentIndex == index)
                {
                    cart.plates.AddLast(plate); 
                    return true;
                }
                currentIndex++;
            }
            return false; 
        }

        public LinkedList<Plate> see_cart()
        {
            return cart.plates;
        }

        public void modify_quantity(int index, int quantity) 
        {
            int currentIndex = 0;
            foreach (Plate plate in cart.plates)
            {
                if (currentIndex == index)
                {
                    plate.quantity = quantity;

                }
                currentIndex++;
            }
   
        }

        public void remove_from_cart(int index)
        {
            int currentIndex = 0;
            foreach (Plate plate in cart.plates)
            {
                if (currentIndex == index)
                {
                    cart.plates.Remove(plate);
                    return;
                }
                currentIndex++;
            }
        }

        public void generate_order()
        {
            DateTime now = DateTime.Now;
            order = new Order(1, now, cart.plates, cart.price);
        }
        
        public int see_state_order()
        {
            return order.state;
        }

        public void make_feedback(float rating)
        {
            FeedBack feedBack = new FeedBack(rating);
        }

    }

    
}
