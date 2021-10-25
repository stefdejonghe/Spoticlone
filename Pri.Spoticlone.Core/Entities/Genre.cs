using Pri.Spoticlone.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Spoticlone.Core.Entities
{
    public class Genre : EntityBase
    {
        public string Name { get; set; }
        public ICollection<ArtistGenre> ArtistGenres { get; set; }
    }
}
