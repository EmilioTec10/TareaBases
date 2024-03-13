namespace RestTecAPI.Entities
{
    public class Admin : Person
    {
        private LinkedList<Plate> plates { get; set;}

        public Menu menu { get; set; }

        const string data_base = "C:\\Users\\manue\\Escritorio\\TareaBases\\RestTecAPI\\RestTecAPI\\Users\\Users.txt";

        public void register(string email, string password)
        {
            using (StreamWriter writer = new StreamWriter(data_base))
            {
                writer.WriteLine($"{email}, {password}, admin");
            }
        }

        public void create_plate(string name, string description)
        {
            Plate plate = new Plate();
            plates.AddLast(plate);
        }
        public void update_plate_name (Plate plate, string new_plate_name)
        {
            plate.name = new_plate_name;
        }

        public void update_plate_description (Plate plate, string new_description) 
        { 
            plate.description = new_description;
        }

        public void delete_plate (Plate plate)
        {
            plates.Remove(plate);
        }

        public void create_menu()
        {
            menu = new Menu();
        }

        public void add_plate_to_menu(Plate plate, int price, int calories, string type)
        {
            menu.plates.AddLast(plate);
            plate.price = price;
            plate.calories = calories; 
            plate.type = type;
        }

        public void update_plate_price_menu(Plate plate, int new_price)
        {
            plate.price = new_price;
        }

        public void update_plate_calories_menu(Plate plate, int new_calories)
        {
            plate.calories = new_calories;
        }

        public void update_plate_type_menu(Plate plate, string new_type)
        {
            plate.type = new_type;
        }

        public void remove_plate_from_menu(Plate plate) 
        {
            menu.plates.Remove(plate);
        }

        public void see_10_most_sell()
        {

        }

        public void see_10_most_worth()
        {

        }
        public void see_10_most_rated()
        {

        }
        public void see_10_most_ordered()
        {

        }
    }
}
