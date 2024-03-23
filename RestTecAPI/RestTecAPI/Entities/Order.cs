namespace RestTecAPI.Entities
{
    public class Order
    {
        public int id { get; set; }

        public DateTime date { get; set; }

        public Chef chef { get; set; }

        public int state { get; set; }

        public bool assigned;

        public LinkedList<Plate> plates { get; set; }

        public static LinkedList<Order> orders = new LinkedList<Order>();

        public int price { get; set; }

        public Bill bill { get; set; }

        public Order (int id, DateTime date, LinkedList<Plate> plates, int price)
        {
            this.id = id;   
            this.date = date;   
            this.plates = plates;
            this.price = price;
            orders.AddLast(this);
        }

        public void generate_bill()
        {
            bill = new Bill(this.id, this.price, this.date, this.plates);
        }
    }
}
