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
        private readonly ITrackRepository _trackRepository;
        private readonly IMapper _mapper;

        public TrackService(ITrackRepository trackRepository, IMapper mapper)
        {
            _trackRepository = trackRepository;
            _mapper = mapper;
        }
        public async Task<TrackResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _trackRepository.GetByIdAsync(id);

            var dto = _mapper.Map<TrackResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<TrackResponseDto>> ListAllAsync()
        {
            var result = await _trackRepository.ListAllAsync();

            var dto = _mapper.Map<IEnumerable<TrackResponseDto>>(result);
            return dto;
        }

        public async Task<IEnumerable<TrackResponseDto>> GetByAlbumIdAsync(Guid id)
        {
            var result = await _trackRepository.GetByAlbumIdAsync(id);

            var dto = _mapper.Map<IEnumerable<TrackResponseDto>>(result);
            return dto;
        }

        public async Task<TrackResponseDto> AddAsync(TrackRequestDto trackRequestDto)
        {
            var trackEntity = _mapper.Map<Track>(trackRequestDto);
            var result = await _trackRepository.AddAsync(trackEntity);
            var dto = _mapper.Map<TrackResponseDto>(result);
            return dto;
        }

        public async Task<TrackResponseDto> UpdateAsync(TrackRequestDto trackRequestDto)
        {
            var trackEntity = _mapper.Map<Track>(trackRequestDto);
            var result = await _trackRepository.UpdateAsync(trackEntity);
            var dto = _mapper.Map<TrackResponseDto>(result);
            return dto;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _trackRepository.DeleteAsync(id);
        }
    }
}
