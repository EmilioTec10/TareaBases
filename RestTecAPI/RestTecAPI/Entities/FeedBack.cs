namespace RestTecAPI.Entities
{
    public class FeedBack
    {
        public string date { get; set; }
        public string time { get; set; }

        public float rating { get; set; }
        public FeedBack(float rating) { 
        
            this.rating = rating;
        }
    }
}
