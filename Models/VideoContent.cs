using System.ComponentModel.DataAnnotations;

namespace boolflix.Models
{
    public abstract class VideoContent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public int Duration { get; set; }

        public bool IsNew { get; set; }

        //relazioni
        public List<Genre>? Genres { get; set; }

        public List<Profile>? Profiles { get; set; }

        public List<Playlist>? Playlists { get; set; }
    }
}
