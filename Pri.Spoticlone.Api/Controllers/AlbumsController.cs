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
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var albums = await _albumService.ListAllAsync();

            return Ok(albums);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var album = await _albumService.GetByIdAsync(id);
            if (album == null)
            {
                return NotFound($"Album with ID {id} does not exist");
            }

            return Ok(album);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AlbumRequestDto albumRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var albumResponseDto = await _albumService.AddAsync(albumRequestDto);
            return CreatedAtAction(nameof(Get), new { id = albumResponseDto.Id }, albumResponseDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlbumRequestDto albumRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var albumResponseDto = await _albumService.UpdateAsync(albumRequestDto);
            return Ok(albumResponseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var album = await _albumService.GetByIdAsync(id);
            if (album == null)
            {
                return NotFound($"Album with ID {id} does not exist");
            }

            await _albumService.DeleteAsync(id);
            return Ok();
        }
    }
}
