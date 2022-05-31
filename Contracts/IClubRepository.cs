using Entities.Models;

namespace Contracts;

public interface IClubRepository
{
    IEnumerable<Club> GetAllClubs(bool trackChanges);
    Club? GetClub(int id, bool trackChanges);

    void CreateClub(Club club);

    void DeleteClub(Club club);
}