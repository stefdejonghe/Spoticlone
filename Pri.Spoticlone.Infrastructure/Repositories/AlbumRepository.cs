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
    public class AlbumRepository : EfRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public override async Task<Album> GetByIdAsync(Guid id)
        {
            return await GetAllAsync().SingleOrDefaultAsync(a => a.Id.Equals(id));
        }

        public override IQueryable<Album> GetAllAsync()
        {
            return _dbContext.Albums.AsNoTracking()
                .Include(a => a.Artist)
                .Include(a => a.Tracks);
        }
    }
}
