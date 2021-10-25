using Pri.Spoticlone.Core.Entities.Base;
using System;

namespace Pri.Spoticlone.Core.Entities
{
    public class Track : EntityBase
    {
        public string Name { get; set; }
        public string SpotifyId { get; set; }
        public int TrackNumber { get; set; }
        public int DiscNumber { get; set; }
        public int DurationMs { get; set; }
        public bool Explicit { get; set; }
        public Uri PreviewUrl { get; set; }
        public Guid AlbumId { get; set; }
        public Album Album { get; set; }
    }
}