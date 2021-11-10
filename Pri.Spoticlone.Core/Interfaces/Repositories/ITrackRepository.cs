using Pri.Spoticlone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Spoticlone.Core.Interfaces.Repositories
{
    public interface ITrackRepository : IRepository<Track>
    {
        Task<IEnumerable<Track>> GetByAlbumIdAsync(Guid id);
    }
}
