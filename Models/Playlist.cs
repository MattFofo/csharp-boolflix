using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace boolflix.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Title { get; set; }

        //relazioni
        public Profile? Profile { get; set; }
        public int? ProfileId { get; set; }

        public List<VideoContent>? VideoContents { get; set; }
    }
}
