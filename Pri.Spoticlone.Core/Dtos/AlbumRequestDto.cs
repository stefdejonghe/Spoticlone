using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Spoticlone.Core.Dtos
{
    public class AlbumRequestDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Uri Image { get; set; }
        public Guid ArtistId { get; set; }
    }
}
