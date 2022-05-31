namespace Contracts;

public interface IRepositoryManager
{
    public IClubRepository Club { get; }
    public IPlayerRepository Player { get; }

    void Save();
}