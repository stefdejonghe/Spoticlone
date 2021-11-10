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
    public class TracksController : ControllerBase
    {
        private readonly ITrackService _trackService;

        public TracksController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tracks = await _trackService.ListAllAsync();

            return Ok(tracks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var track = await _trackService.GetByIdAsync(id);
            if (track == null)
            {
                return NotFound($"Track with ID {id} does not exist");
            }

            return Ok(track);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TrackRequestDto trackRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trackResponseDto = await _trackService.AddAsync(trackRequestDto);
            return CreatedAtAction(nameof(Get), new { id = trackResponseDto.Id }, trackResponseDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(TrackRequestDto trackRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trackResponseDto = await _trackService.UpdateAsync(trackRequestDto);
            return Ok(trackResponseDto);
        }
    }
}
