namespace corona_api.Models
{
    public class Answer
    {
         public Question question { get; set; }

        public bool yesOrNo { get; set; }

        public int order { get; set; }
    }
}