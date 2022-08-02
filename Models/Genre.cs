namespace boolflix.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //relazioni
        public List<VideoContent>? VideoContents { get; set; }
    }
}
