namespace RestTecAPI.Entities
{
    public class Bill
    {
        public int id { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public LinkedList<Plate> plates { get; set; }   
        public int price { get; set; }

        public Bill(int id, int price, string date, string time, LinkedList<Plate> plates)
        {
            this.id = id;   
            this.date = date;
            this.time = time;
            this.plates = plates;
            this.price = price;
        }
    }
}
