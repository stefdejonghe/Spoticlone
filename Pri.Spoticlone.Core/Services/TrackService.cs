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
    public class TrackService : ITrackService
    {
        private readonly IRepository<Track> _trackRepository;
        private readonly IMapper _mapper;

        public TrackService(IRepository<Track> trackRepository, IMapper mapper)
        {
            _trackRepository = trackRepository;
            _mapper = mapper;
        }
        public async Task<TrackResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _trackRepository.GetAllAsync()
                .Include(t => t.Album)
                    .ThenInclude(a => a.Artist)
                .SingleOrDefaultAsync(t => t.Id.Equals(id));

            var dto = _mapper.Map<TrackResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<TrackResponseDto>> ListAllAsync()
        {
            var result = await _trackRepository.GetAllAsync()
                .Include(t => t.Album)
                    .ThenInclude(a => a.Artist)
                .ToListAsync();

            var dto = _mapper.Map<IEnumerable<TrackResponseDto>>(result);
            return dto;
        }
    }
}
