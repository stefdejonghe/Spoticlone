using Microsoft.EntityFrameworkCore;
using Pri.Spoticlone.Core.Entities;
using Pri.Spoticlone.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Spoticlone.Infrastructure.Repositories
{
    public class ArtistRepository : EfRepository<Artist>
    {
        public ArtistRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Artist> GetByIdAsync(Guid id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(a => a.Id.Equals(id));
        }

        public override IQueryable<Artist> GetAllAsync()
        {
            return _dbContext.Artists.AsNoTracking()
                .Include(a => a.ArtistGenres)
                    .ThenInclude(a => a.Genre)
                .Include(a => a.Albums);
        }

        public async Task<IEnumerable<Artist>> GetByGenreIdAsync(Guid id)
        {
            return await GetAllAsync()
                .Where(a => a.ArtistGenres.Any(ag => ag.GenreId.Equals(id)))
                .ToListAsync();
        }
    }
}
