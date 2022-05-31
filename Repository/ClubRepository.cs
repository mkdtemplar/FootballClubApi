using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ClubRepository : RepositoryBase<Club>, IClubRepository
    {
        public ClubRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Club> GetAllClubs(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(a => a.City).Include(p => p.Players).ToList();

        public Club? GetClub(int id, bool trackChanges) =>
            FindByCondition(a => a.Id.Equals(id), trackChanges).Include(p => p.Players).SingleOrDefault();

        public void CreateClub(Club club) => Create(club);
        public void DeleteClub(Club club) => Delete(club);
    }
}