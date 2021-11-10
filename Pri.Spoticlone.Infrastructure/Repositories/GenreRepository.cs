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
    public class GenreRepository : EfRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<Genre> GetAllAsync()
        {
            return _dbContext.Genres.AsNoTracking()
                .Include(g => g.ArtistGenres)
                    .ThenInclude(ag => ag.Artist);
        }

        public override async Task<Genre> GetByIdAsync(Guid id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(g => g.Id.Equals(id));
        }
    }
}
