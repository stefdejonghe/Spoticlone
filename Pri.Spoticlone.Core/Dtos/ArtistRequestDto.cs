using Pri.Spoticlone.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Spoticlone.Core.Dtos
{
    public class ArtistRequestDto : DtoBase
    {
        public string Name { get; set; }
        public int Followers { get; set; }
        public int Popularity { get; set; }
        public Uri Image { get; set; }
    }
}
