namespace RestTecAPI.Entities
{
    public class Bill
    {
        public int id { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public LinkedList<Plate> plates { get; set; }   
        public int price { get; set; }
    }
}
