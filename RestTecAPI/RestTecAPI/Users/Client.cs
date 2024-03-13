using System.Numerics;

namespace RestTecAPI.Entities
{
    public class Client : Person
    {
        public int id { get; set; }
        public string name { get; set; }

        public string last_name { get; set; }

        public string address { get; set; }

        public string birth_date { get; set; }

        public LinkedList<int> phones { get; set; }

        private ShoppingCart cart { get; set; }

        private Order order { get; set; }

        public void create_cart()
        {
            cart = new ShoppingCart();
        }

        public void add_to_cart(Plate plate, int quantity)
        {
            cart.plates.AddLast(plate);

        }

        public void see_cart()
        {
            foreach (var plate in cart.plates)
            {
  
                Console.WriteLine(plate); 
            }
        }

        public void modify_quantity(Plate plate, int quantity) 
        {
            Plate plate_found = cart.plates.FirstOrDefault(p => p.name == plate.name);
            plate_found.quantity = quantity;
   
        }

        public void remove_from_cart(Plate plate)
        {
            cart.plates.Remove(plate);
        }

        public void generate_order()
        {
            order = new Order(cart.plates);
        }

        public void see_state_order()
        {
            Console.WriteLine(order.state);
        }

        public void make_feedback(float rating, string description)
        {

        }

    }

    
}
