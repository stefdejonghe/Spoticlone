using Pri.Spoticlone.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Spoticlone.Core.Dtos
{
    public class TrackRequestDto : DtoBase
    {
        public string Name { get; set; }
        public int DurationMs { get; set; }
        public bool Explicit { get; set; }
        public Uri PreviewUrl { get; set; }
        public Guid AlbumId { get; set; }
    }
}
