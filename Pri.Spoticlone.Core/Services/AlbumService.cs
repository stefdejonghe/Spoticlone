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
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;
        public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }
        public async Task<AlbumResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _albumRepository.GetByIdAsync(id);

            var dto = _mapper.Map<AlbumResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<AlbumResponseDto>> ListAllAsync()
        {
            var result = await _albumRepository.ListAllAsync();

            var dto = _mapper.Map<IEnumerable<AlbumResponseDto>>(result);
            return dto;
        }

        public async Task<IEnumerable<AlbumResponseDto>> GetByArtistId(Guid id)
        {
            var result = await _albumRepository.GetByArtistIdAsync(id);
            var dto = _mapper.Map<IEnumerable<AlbumResponseDto>>(result);
            return dto;
        }
    }
}
