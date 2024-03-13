namespace RestTecAPI.Entities
{
    public class Order
    {
        public int id { get; set; }

        public string date { get; set; }

        public string time { get; set; }

        public Chef chef { get; set; }

        public int state { get; set; }

        public LinkedList<Plate> plates {  get; set; }

        public int price { get; set; }

        public Bill bill { get; set; }

        public Order(LinkedList<Plate> plates)
        {
            this.plates = plates;
        }

        public void generate_bill()
        {
            bill = new Bill(1, this.price, this.date, this.time, this.plates);
        }
    }
}
