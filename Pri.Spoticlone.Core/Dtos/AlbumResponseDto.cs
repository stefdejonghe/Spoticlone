using Pri.Spoticlone.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Spoticlone.Core.Dtos
{
    public class AlbumResponseDto : DtoBase
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Uri Image { get; set; }
        public Guid ArtistId { get; set; }
        public string SpotifyId { get; set; }
        public ArtistResponseDto Artist { get; set; }
        public int TrackCount { get; set; }
    }
}
