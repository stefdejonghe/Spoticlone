using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pri.Spoticlone.Core.Dtos;
using Pri.Spoticlone.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.Spoticlone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;
        public ArtistsController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var artists = await _artistService.ListAllAsync();

            return Ok(artists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var artist = await _artistService.GetByIdAsync(id);
            if (artist == null)
            {
                return NotFound($"Artist with ID {id} does not exist");
            }

            return Ok(artist);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ArtistRequestDto artistRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artistResponseDto = await _artistService.AddAsync(artistRequestDto);
            return CreatedAtAction(nameof(Get), new { id = artistResponseDto.Id }, artistResponseDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ArtistRequestDto artistRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artistResponseDto = await _artistService.UpdateAsync(artistRequestDto);
            return Ok(artistResponseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var artist = await _artistService.GetByIdAsync(id);
            if (artist == null)
            {
                return NotFound($"Arist with ID {id} does not exist");
            }

            await _artistService.DeleteAsync(id);
            return Ok();
        }
    }
}
