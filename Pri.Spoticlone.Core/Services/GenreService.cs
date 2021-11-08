using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pri.Spoticlone.Core.Dtos;
using Pri.Spoticlone.Core.Entities;
using Pri.Spoticlone.Core.Interfaces.Repositories;
using Pri.Spoticlone.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Spoticlone.Core.Services
{
    public class GenreService : IGenreService
    {
        private readonly IRepository<Genre> _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IRepository<Genre> genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        public async Task<GenreResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _genreRepository.GetAllAsync()
                .Include(g => g.ArtistGenres)
                    .ThenInclude(ag => ag.Artist)
                .SingleOrDefaultAsync(g => g.Id.Equals(id));

            var dto = _mapper.Map<GenreResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<GenreResponseDto>> ListAllAsync()
        {
            var result = await _genreRepository.GetAllAsync()
                .Include(g => g.ArtistGenres)
                    .ThenInclude(ag => ag.Artist)
                .ToListAsync();

            var dto = _mapper.Map<IEnumerable<GenreResponseDto>>(result);
            return dto;
        }
    }
}
