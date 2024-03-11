namespace RestTecAPI.Entities
{
    public class Order
    {
        public int id { get; set; }

        public string date { get; set; }

        public string time { get; set; }

        public Chef chef { get; set; }

        public int state { get; set; }

        public void generate_bill()
        {

        }
    }
}
