using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubApi.Controllers
{
    [Route("api/clubs")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ClubController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetClubs()
        {
            var clubs = _repository.Club.GetAllClubs(trackChanges: false);

            var clubDto = _mapper.Map<IEnumerable<ClubDto>>(clubs);

            return Ok(clubDto);
        }

        [HttpGet("{id}", Name = "ClubById")]
        public IActionResult GetClub(int id)
        {
            var club = _repository.Club.GetClub(id, trackChanges: false);
            if (club == null)
            {
                _logger.LogInfo($"Club with id: {id} not found");
                return NotFound();
            }

            var clubDto = _mapper.Map<ClubDto>(club);

            return Ok(clubDto);
        }

        [HttpPost]
        public IActionResult CreateClub([FromBody] ClubForCreationDto? club)
        {
            if (club == null)
            {
                _logger.LogError("Club object sent from client is null");
                return BadRequest("Club object sent from client is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the ClubForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var clubEntity = _mapper.Map<Club>(club);

            _repository.Club.CreateClub(clubEntity);

            _repository.Save();

            var clubToReturn = _mapper.Map<ClubDto>(clubEntity);

            return CreatedAtRoute("ClubById", new { id = clubToReturn.Id }, clubToReturn);
        }

        [HttpPost("Club and player creation")]
        public IActionResult CreateClubAndPlayer([FromBody] ClubAndPlayerForCreationDto? clubAndPlayer)
        {
            if (clubAndPlayer == null)
            {
                _logger.LogError("Club object sent from client is null");
                return BadRequest("Club object sent from client is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the ClubAndPlayerForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            var clubAndPlayerEntity = _mapper.Map<Club>(clubAndPlayer);
            _repository.Club.CreateClub(clubAndPlayerEntity);

            _repository.Save();

            var resultToReturn = _mapper.Map<ClubDto>(clubAndPlayerEntity);



            return CreatedAtRoute("ClubById", new { id = resultToReturn.Id }, resultToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClub(int id)
        {
            var club = _repository.Club.GetClub(id, trackChanges: false);

            if (club == null)
            {
                _logger.LogInfo($"Club with id: {id} not found");
                return NotFound();
            }

            _repository.Club.DeleteClub(club);
            _repository.Save();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClub(int id, [FromBody] ClubForUpdateDto? club)
        {
            if (club == null)
            {

                _logger.LogError("Club object sent from client is null");
                return BadRequest("Club object sent from client is null");
            }

            var clubEntity = _repository.Club.GetClub(id, trackChanges: true);

            if (clubEntity == null)
            {
                _logger.LogInfo($"Club with id: {id} not found");
                return NotFound();
            }

            _mapper.Map(club, clubEntity);
            _repository.Save();

            return NoContent();
        }
    }
}
