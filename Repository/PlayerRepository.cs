using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
{
    public PlayerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Player> GetAllPlayers(bool trackChanges) =>
        FindAll(trackChanges).OrderBy(s => s.FirstName).ToList();

    public Player? GetPlayer(int id, bool trackChanges) =>
        FindByCondition(s => s.Id.Equals(id), trackChanges).SingleOrDefault();

    public void CreatePlayer(Player player) => Create(player);
    public void DeletePlayer(Player player) => Delete(player);
}