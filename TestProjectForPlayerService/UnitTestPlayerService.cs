using Contracts;
using Entities.Models;

namespace TestProjectForPlayerService
{
    public class UnitTestPlayerService
    {
        private IPlayerRepository _playerRepository;

        public UnitTestPlayerService()
        {
            _playerRepository = new PlayerRepoFake();
        }


        [Fact]
        public void GetAllPlayers()
        {
            var okResult = _playerRepository.GetAllPlayers(false);
            Assert.NotNull(okResult);
            Assert.True(okResult != null);
        }

        [Fact]
        public void GetPlayer()
        {
            var okResult = _playerRepository.GetPlayer(1, false);
            Assert.True(okResult != null);
            Assert.NotNull(okResult);
            Assert.Equal(1, okResult.Id);
            Assert.Equal("Kareem", okResult.FirstName);
        }

        [Fact]
        public void CreatePlayer()
        {
            var testItem = new Player()
            {
                Id = 4,
                FirstName = "Rodrigo",
                LastName = "Brazil",
                DateOfBirth = new DateTime(1990, 10, 10),
                SigningDate = new DateTime(2010, 11, 11),
                Rank = 10,
                TotalGoals = 100,
                ClubId = 1
            };

            _playerRepository.CreatePlayer(testItem);

            var getCreatedItem = _playerRepository.GetPlayer(4, false);

            Assert.IsType<Player>(getCreatedItem);
            Assert.Equal(4, getCreatedItem.Id);
            Assert.Equal("Rodrigo", getCreatedItem.FirstName);
        }
    }
}