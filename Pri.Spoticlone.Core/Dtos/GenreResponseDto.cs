using Pri.Spoticlone.Core.Dtos.Base;
using System.Collections;
using System.Collections.Generic;

namespace Pri.Spoticlone.Core.Dtos
{
    public class GenreResponseDto : DtoBase
    {
        public string Name { get; set; }
        public int ArtistCount { get; set; }
    }
}