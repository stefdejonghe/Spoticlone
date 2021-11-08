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
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;

        public ArtistService(IArtistRepository artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }


        public async Task<ArtistResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _artistRepository.GetByIdAsync(id);

            var dto = _mapper.Map<ArtistResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<ArtistResponseDto>> ListAllAsync()
        {
            var result = await _artistRepository.ListAllAsync();

            var dto = _mapper.Map<IEnumerable<ArtistResponseDto>>(result);
            return dto;
        }

        public async Task<IEnumerable<ArtistResponseDto>> GetByGenreIdAsync(Guid id)
        {
            var result = await _artistRepository.GetByGenreIdAsync(id);

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

        public async Task<ArtistResponseDto> UpdateAsync(ArtistRequestDto artistRequestDto)
        {
            var artistEntity = _mapper.Map<Artist>(artistRequestDto);
            var result = await _artistRepository.UpdateAsync(artistEntity);
            var dto = _mapper.Map<ArtistResponseDto>(result);
            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _artistRepository.DeleteAsync(id);
        }
    }
}
