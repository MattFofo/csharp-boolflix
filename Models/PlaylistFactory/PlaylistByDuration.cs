using boolflix.Data;
using boolflix.Models;

namespace boolflix.Models.PlaylistFactory
{
    internal class PlaylistByDuration : Playlist
    {
        public int Duration { get; set; }
        public PlaylistByDuration(int duration)
        {
            BoolflixContext ctx = new BoolflixContext();
            Duration = duration;
            Title = $"Più di {duration} minuti di intrattenimento";
            VideoContents = ctx.VideoContents.Where(vc => vc.Duration >= duration).ToList();
        }
    }
}