namespace RestTecAPI.Entities
{
    public class Bill
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string time { get; set; }
        public LinkedList<Plate> plates { get; set; }   
        public int price { get; set; }

        public Bill(int id, int price, DateTime date, LinkedList<Plate> plates)
        {
            this.id = id;   
            this.date = date;
            this.plates = plates;
            this.price = price;
        }
    }
}
