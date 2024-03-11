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

        public void add_to_cart(string plate, int quantity)
        {

        }

        public void see_cart()
        {

        }

        public void modify_quantity(string plate, int quantity) 
        { 
        
        }

        public void remove_from_cart(string plate)
        {

        }

        public void generate_order()
        {

        }

        public void see_state_order()
        {

        }

        public void make_feedback(float rating, string description)
        {

        }

    }

    
}
