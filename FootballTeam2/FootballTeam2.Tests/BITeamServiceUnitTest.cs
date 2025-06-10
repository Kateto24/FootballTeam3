using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using FootballTeam2.BL.Interfaces;
using FootballTeam2.Models.DTO;
using FootballTeam2.Models.Requests;

namespace FootballTeam2.Tests
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsBlController : ControllerBase
    {
        private readonly IBlTeamService _teamService;
        private readonly ILogger<TeamsController> _logger;

        public TeamsBlController(
            IBlTeamService teamService,
            ILogger<TeamsController> logger)
        {
            _teamService = teamService;
            _logger = logger;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _teamService.GetAllTeamDetails();

            if (result == null || !result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }
    }

    public class TestRequest
    {
        public int Id { get; set; }

        public string TeamName { get; set; }
    }
}
