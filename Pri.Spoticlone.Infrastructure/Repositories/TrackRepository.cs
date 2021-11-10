using Microsoft.EntityFrameworkCore;
using Pri.Spoticlone.Core.Entities;
using Pri.Spoticlone.Core.Interfaces.Repositories;
using Pri.Spoticlone.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Spoticlone.Infrastructure.Repositories
{
    public class TrackRepository : EfRepository<Track>, ITrackRepository
    {
        public TrackRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<Track> GetAllAsync()
        {
            return _dbContext.Tracks.AsNoTracking()
                .Include(t => t.Album)
                    .ThenInclude(a => a.Artist);
        }

        public override async Task<Track> GetByIdAsync(Guid id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(t => t.Id.Equals(id));
        }

        public async Task<IEnumerable<Track>> GetByAlbumIdAsync(Guid id)
        {
            return await GetAllAsync()
                .Where(t => t.AlbumId.Equals(id))
                .ToListAsync();
        }
    }
}
