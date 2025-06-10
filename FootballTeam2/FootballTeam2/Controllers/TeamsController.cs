using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreB.BL.Interfaces;
using MovieStoreB.Models.DTO;
using MovieStoreB.Models.Requests;

namespace FootballTeam2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IMapper _mapper;
        private readonly ILogger<TeamsController> _logger;

        public TeamsController(
            ITeamService teamService,
            IMapper mapper,
            ILogger<TeamsController> logger)
        {
            _teamService = teamService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _teamService.GetTeams();

            if (result == null || !result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(string id) // change Id
        {
            if (!string.IsNullOrEmpty(id)) return BadRequest();

            var result = _teamService.GetTeamsById(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost("AddTeam")]
        public async Task<IActionResult> AddTeam(
            [FromBody] AddTeamRequest teamRequest)
        {
            if (teamRequest == null) return BadRequest();

            var team = _mapper.Map<Team>(teamRequest);

            await _teamService.AddTeam(team);

            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(string id) // change Id
        {
            if (!string.IsNullOrEmpty(id)) return BadRequest($"Wrong id:{id}");

            _teamService.DeleteTeam(id);

            return Ok();
        }
    }
}
