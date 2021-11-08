﻿using Pri.Spoticlone.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Spoticlone.Core.Interfaces.Services
{
    public interface ITrackService
    {
        Task<IEnumerable<TrackResponseDto>> ListAllAsync();
        Task<TrackResponseDto> GetByIdAsync(Guid id);
    }
}
