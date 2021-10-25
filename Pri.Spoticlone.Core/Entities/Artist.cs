using Pri.Spoticlone.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Spoticlone.Core.Entities
{
    public class Artist : EntityBase
    {
        public string Name { get; set; }
        public int Followers { get; set; }
        public int Popularity { get; set; }
        public ICollection<ArtistGenre> ArtistGenres { get; set; }
        public ICollection<Album> Albums { get; set; }
        public string SpotifyId { get; set; }
        public Uri Image { get; set; }
    }
}
