using Pri.Spoticlone.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Spoticlone.Core.Dtos
{
    public class ArtistResponseDto : DtoBase
    {
        public string Name { get; set; }
        public int Followers { get; set; }
        public int Popularity { get; set; }
        public string SpotifyId { get; set; }
        public Uri Image { get; set; }
        public ICollection<GenreResponseDto> Genres { get; set; }
        public int AlbumCount { get; set; }
    }
}
