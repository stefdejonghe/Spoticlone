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
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<GenreResponseDto> AddAsync(GenreRequestDto genreRequestDto)
        {
            var genreEntity = _mapper.Map<Genre>(genreRequestDto);
            var result = await _genreRepository.AddAsync(genreEntity);
            var dto = _mapper.Map<GenreResponseDto>(result);
            return dto;
        }

        public async Task<GenreResponseDto> GetByIdAsync(Guid id)
        {
            var result = await _genreRepository.GetByIdAsync(id);

            var dto = _mapper.Map<GenreResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<GenreResponseDto>> ListAllAsync()
        {
            var result = await _genreRepository.ListAllAsync();

            var dto = _mapper.Map<IEnumerable<GenreResponseDto>>(result);
            return dto;
        }
    }
}
