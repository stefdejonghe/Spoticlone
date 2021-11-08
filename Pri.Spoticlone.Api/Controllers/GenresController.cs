using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pri.Spoticlone.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.Spoticlone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var genres = await _genreService.ListAllAsync();

            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var genre = await _genreService.GetByIdAsync(id);
            if (genre == null)
            {
                return NotFound($"Genre with ID {id} does not exist");
            }

            return Ok(genre);
        }
    }
}
