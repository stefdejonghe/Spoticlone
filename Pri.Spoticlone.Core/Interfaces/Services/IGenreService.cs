using Pri.Spoticlone.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Spoticlone.Core.Interfaces.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreResponseDto>> ListAllAsync();
        Task<GenreResponseDto> GetByIdAsync(Guid id);
        Task<GenreResponseDto> AddAsync(GenreRequestDto genreRequestDto);
        Task<GenreResponseDto> UpdateAsync(GenreRequestDto genreRequestDto);
        Task DeleteAsync(Guid id);
    }
}
