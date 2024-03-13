namespace RestTecAPI.Entities
{
    public class ShoppingCart
    {
        public int price { get; set;}

        public LinkedList<Plate> plates { get; set; }

        public void generate_order()
        {

        }
    }
}
