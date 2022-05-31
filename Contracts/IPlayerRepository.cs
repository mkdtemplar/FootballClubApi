using Entities.Models;

namespace Contracts;

public interface IPlayerRepository
{
    IEnumerable<Player> GetAllPlayers(bool trackChanges);
    Player? GetPlayer(int id, bool trackChanges);
    void CreatePlayer(Player player);
    void DeletePlayer(Player player);
}