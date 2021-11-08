using Pri.Spoticlone.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Spoticlone.Core.Interfaces.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumResponseDto>> ListAllAsync();
        Task<AlbumResponseDto> GetByIdAsync(Guid id);
    }
}
