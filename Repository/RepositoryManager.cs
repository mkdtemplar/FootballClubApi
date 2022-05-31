using Contracts;
using Entities;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
    private RepositoryContext _repositoryContext;
    private IClubRepository _clubRepository;
    private IPlayerRepository _playerRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }

    public IClubRepository Club
    {
        get
        {
            if (_clubRepository == null)
            {
                _clubRepository = new ClubRepository(_repositoryContext);
            }

            return _clubRepository;
        }
    }

    public IPlayerRepository Player
    {
        get
        {
            if (_playerRepository == null)
            {
                _playerRepository = new PlayerRepository(_repositoryContext);
            }

            return _playerRepository;
        }
    }

    public void Save() => _repositoryContext.SaveChanges();
}