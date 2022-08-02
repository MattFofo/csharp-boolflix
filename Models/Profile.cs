using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace boolflix.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsChild { get; set; }

        //relazioni
        public List<VideoContent>? VideoContents { get; set; } = new List<VideoContent>();

        public Playlist? Playlist { get; set; }
    }
}
