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
    public class ArtistService : IArtistService
    {
        private readonly IRepository<Artist> _artistRepository;
        private readonly IMapper _mapper;

        public ArtistService(IRepository<Artist> artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }


        public async Task<ArtistResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _artistRepository.GetAllAsync()
                .Include(a => a.ArtistGenres)
                    .ThenInclude(ag => ag.Genre)
                .Include(a => a.Albums)
                .SingleOrDefaultAsync(a => a.Id.Equals(id));

            var dto = _mapper.Map<ArtistResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<ArtistResponseDto>> ListAllAsync()
        {
            var result = await _artistRepository.GetAllAsync()
                .Include(a => a.ArtistGenres)
                    .ThenInclude(a => a.Genre)
                .Include(a => a.Albums)
                .ToListAsync();

            var dto = _mapper.Map<IEnumerable<ArtistResponseDto>>(result);
            return dto;
        }
        public async Task<ArtistResponseDto> AddAsync(ArtistRequestDto artistRequestDto)
        {
            var artistEntity = _mapper.Map<Artist>(artistRequestDto);

            if (artistEntity.Image == null)
            {
                artistEntity.Image = new Uri("https://via.placeholder.com/150/1ED760/ffffff?text="
                    + artistEntity.Name.Replace(" ", "+"), UriKind.Absolute);
            }

            var result = await _artistRepository.AddAsync(artistEntity);
            var dto = _mapper.Map<ArtistResponseDto>(result);
            return dto;
        }
    }
}
