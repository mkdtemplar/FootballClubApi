using Contracts;
using Entities.Models;

namespace TestProjectForPlayerService;

public class PlayerRepoFake : IPlayerRepository
{
    private List<Player?> _players;

    public PlayerRepoFake()
    {
        _players = new List<Player?>()
        {
            new Player()
            {
                Id = 1,
                FirstName = "Kareem",
                LastName = "Benzema",
                DateOfBirth = new DateTime(1990, 10,10),
                SigningDate = new DateTime(2010,11,11),
                Rank = 1,
                TotalGoals = 345,
                ClubId = 1
            },
            new Player()
            {
                Id = 2,
                FirstName = "Vinicius",
                LastName = "Junior",
                DateOfBirth = new DateTime(1990, 10,10),
                SigningDate = new DateTime(2010,11,11),
                Rank = 2,
                TotalGoals = 123,
                ClubId = 1
            },

            new Player()
            {
                Id = 3,
                FirstName = "Lucas",
                LastName = "Vasces",
                DateOfBirth = new DateTime(1990, 10,10),
                SigningDate = new DateTime(2010,11,11),
                Rank = 10,
                TotalGoals = 100,
                ClubId = 1
            },
        };
    }

    public IEnumerable<Player> GetAllPlayers(bool trackChanges)
    {
        return _players;
    }

    public Player? GetPlayer(int id, bool trackChanges) => _players.SingleOrDefault(p => p.Id.Equals(id));

    public void CreatePlayer(Player player)
    {
        _players.Add(player);
    }

    public void DeletePlayer(Player player)
    {
        _players.Remove(player);
    }
}