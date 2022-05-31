using Contracts;
using Entities.Models;

namespace TestProjectClubsService;

public class ClubRepoFake : IClubRepository
{
    private List<Club?> _clubs;

    public ClubRepoFake()
    {
        _clubs = new List<Club?>()
        {
            new Club()
            {
                Id = 1,
                Name = "Real Madrid",
                Owner = "Perez",
                City = "Madrid",
                Country = "Spain",
            },

            new Club()
            {
                Id = 2,
                Name = "Barcelona",
                Owner = "Unknown",
                City = "Barcelona",
                Country = "Spain",
            },
            new Club()
            {
                Id = 3,
                Name = "Liverpool",
                Owner = "Some owner",
                City = "Liverpool",
                Country = "UK",
            }
        };
    }

    public IEnumerable<Club> GetAllClubs(bool trackChanges)
    {
        return _clubs;
    }

    public Club? GetClub(int id, bool trackChanges) => _clubs.SingleOrDefault(c => c.Id.Equals(id));

    public void CreateClub(Club club)
    {
       _clubs.Add(club);
    }

    public void DeleteClub(Club club)
    {
        _clubs.Remove(club);
    }
}