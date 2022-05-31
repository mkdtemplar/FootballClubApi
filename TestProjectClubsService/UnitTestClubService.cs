using Contracts;
using Entities.Models;

namespace TestProjectClubsService
{
    public class UnitTestClubService
    {
        private IClubRepository _clubRepository;

        public UnitTestClubService()
        {
            _clubRepository = new ClubRepoFake();
        }

        [Fact]
        public void GetAllClubs()
        {
            var okResult = _clubRepository.GetAllClubs(false);
            Assert.NotNull(okResult);
            Assert.True(okResult != null);
        }

        [Fact]
        public void GetClub()
        {
            var okResult = _clubRepository.GetClub(1, false);

            Assert.True(okResult != null);
            Assert.NotNull(okResult);
            Assert.Equal(1, okResult.Id);
            Assert.Equal("Real Madrid", okResult.Name);
        }

        [Fact]
        public void CreateClub()
        {
            var testItem = new Club()
            {
                Id = 4,
                Name = "Atletico Madrid",
                Owner = "Not known",
                City = "Madrid",
                Country = "Spain",
            };

            _clubRepository.CreateClub(testItem);
            var getCreatedItem = _clubRepository.GetClub(4, false);
           Assert.IsType<Club>(getCreatedItem);
            Assert.Equal(4, getCreatedItem.Id);
            Assert.Equal("Atletico Madrid", getCreatedItem.Name);
        }
    }
}