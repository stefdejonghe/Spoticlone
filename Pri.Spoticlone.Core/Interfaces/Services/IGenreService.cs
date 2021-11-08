﻿using Pri.Spoticlone.Core.Dtos;
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
    }
}
