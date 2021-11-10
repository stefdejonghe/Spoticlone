using AutoMapper;
using Pri.Spoticlone.Core.Dtos;
using Pri.Spoticlone.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Spoticlone.Core.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Artist, ArtistResponseDto>()
                .ForMember(dest => dest.AlbumCount,
                opt => opt.MapFrom(src => src.Albums.Count))
                .ForMember(dest => dest.Genres,
                opt => opt.MapFrom(src => src.ArtistGenres
                .Select(ag => new GenreResponseDto
                {
                    Id = ag.GenreId,
                    Name = ag.Genre.Name
                })));

            CreateMap<Album, AlbumResponseDto>()
                .ForMember(dest => dest.TrackCount,
                opt => opt.MapFrom(src => src.Tracks.Count));

            CreateMap<Genre, GenreResponseDto>()
                .ForMember(dest => dest.ArtistCount,
                opt => opt.MapFrom(src => src.ArtistGenres.Count(a => a.GenreId.Equals(src.Id))));

            CreateMap<Track, TrackResponseDto>();

            CreateMap<ArtistRequestDto, Artist>();
            CreateMap<AlbumRequestDto, Album>();
            CreateMap<GenreRequestDto, Genre>();
        }
    }
}
