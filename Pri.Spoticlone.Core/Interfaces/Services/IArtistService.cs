using Pri.Spoticlone.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Spoticlone.Core.Interfaces.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistResponseDto>> ListAllAsync();
        Task<ArtistResponseDto> GetByIdAsync(Guid id);
        Task<ArtistResponseDto> AddAsync(ArtistRequestDto artistRequestDto);
        Task<ArtistResponseDto> UpdateAsync(ArtistRequestDto artistRequestDto);
    }
}
