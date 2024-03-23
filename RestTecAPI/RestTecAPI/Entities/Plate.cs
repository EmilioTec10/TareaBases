namespace RestTecAPI.Entities
{
    public class Plate
    {
        public string name { get; set; }

        public int price { get; set; }

        public int calories { get; set; }

        public int quantity {  get; set; }

        public string type { get; set; }

        public string description { get; set; }

        public Plate(string name, int price, int quantity, string description)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.description = description;
        }
        public Plate(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }
}
