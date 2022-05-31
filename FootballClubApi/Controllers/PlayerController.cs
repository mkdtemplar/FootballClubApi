using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubApi.Controllers
{
    [Route("api/clubs/players")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PlayersController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetPlayers()
        {
            var playersFromDb = _repository.Player.GetAllPlayers(trackChanges: false);

            var playersDto = _mapper.Map<IEnumerable<PlayerDto>>(playersFromDb);

            return Ok(playersDto);
        }

        [HttpGet("{id}", Name = "GetPlayerById")]
        public IActionResult GetPlayer(int id)
        {
            var playerFromDb = _repository.Player.GetPlayer(id, trackChanges: false);

            if (playerFromDb == null)
            {
                _logger.LogInfo($"Player with id: {id} not found");
                return NotFound();
            }

            var playerDto = _mapper.Map<PlayerDto>(playerFromDb);

            return Ok(playerDto);
        }

        [HttpPost]
        public IActionResult CreatePlayer([FromBody] PlayerForCreationDto player)
        {
            if (player == null)
            {
                _logger.LogError("Player object sent from client is null");
                return BadRequest("Player object sent from client is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the PlayerForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var playerEntity = _mapper.Map<Player>(player);

            _repository.Player.CreatePlayer(playerEntity);
            _repository.Save();

            var playerToReturn = _mapper.Map<PlayerDto>(playerEntity);

            return CreatedAtRoute("GetPlayerById", new { id = playerToReturn.Id }, playerToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlayer(int id)
        {
            var player = _repository.Player.GetPlayer(id, trackChanges: false);

            if (player == null)
            {
                _logger.LogInfo($"Player with id: {id} not in db");
                return NotFound();
            }

            _repository.Player.DeletePlayer(player);
            _repository.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePlayer(int id, [FromBody] PlayerForUpdateDto? player)
        {
            if (player == null)
            {
                _logger.LogError("Player object sent from client is null");
                return BadRequest("Player object sent from client is null");
            }

            var playerEntity = _repository.Player.GetPlayer(id, trackChanges: true);
            if (playerEntity == null)
            {
                _logger.LogInfo($"Player with id: {id} not in db");
                return NotFound();
            }

            _mapper.Map(player, playerEntity);
            _repository.Save();

            return NoContent();
        }

    }
}
