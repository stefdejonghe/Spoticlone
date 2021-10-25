using Pri.Spoticlone.Core.Entities.Base;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Pri.Spoticlone.Core.Entities
{
    public class Album : EntityBase
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Uri Image { get; set; }
        public Guid ArtistId { get; set; }
        public string SpotifyId { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Track> MyProperty { get; set; }
    }
}