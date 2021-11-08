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
        private readonly IRepository<Album> _albumRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;
        public AlbumService(IRepository<Album> albumRepository, IArtistRepository artistRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
            _mapper = mapper;
        }
        public async Task<AlbumResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _albumRepository.GetAllAsync()
                .Include(a => a.Artist)
                .Include(a => a.Tracks)
                .SingleOrDefaultAsync(a => a.Id.Equals(id));

            var dto = _mapper.Map<AlbumResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<AlbumResponseDto>> ListAllAsync()
        {
            var result = await _albumRepository.GetAllAsync()
                .Include(a => a.Artist)
                .Include(a => a.Tracks)
                .ToListAsync();

            var dto = _mapper.Map<IEnumerable<AlbumResponseDto>>(result);
            return dto;
        }
    }
}
