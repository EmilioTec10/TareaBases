namespace RestTecAPI.Entities
{
    public class ShoppingCart
    {
        public int quantity_plates { get; set; }
        public int price { get; set;}

        public LinkedList<Plate> plates { get; set; }
    }
}
