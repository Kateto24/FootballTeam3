using Moq;
using FootballTeam2.BL.Interfaces;
using FootballTeam2.BL.Services;
using FootballTeam2.DL.Interfaces;
using FootballTeam2.Models.DTO;

internal class TeamServiceTest
{
    public class MovieServiceTests
    {
        private readonly Mock<ITeamRepository> _teamRepositoryMock;
        private readonly Mock<IPlayerRepository> _playerRepositoryMock;

        private List<Team> _teams = new List<Team>()
        {
            new Team()
            {
                Id = "c3bd1985-792e-4208-af81-4d154bff15c8",
                Title = "Team 1",
                Year = 2024,
                Actors = [
                    "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                    "baac2b19-bbd2-468d-bd3b-5bd18aba98d7"]
            },
            new Team()
            {
                Id = "4c304bec-f213-47b5-8ae0-9df4a4eb3b99",
                Title = "Team 2",
                Year = 2025,
                Actors = [
                    "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                    "5c93ba13-e803-49c1-b465-d471607e97b3"
                ]
            }
        };

        private List<Player> _players = new List<Player>
        {
            new Player()
            {
                Id = "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                Name = "Actor 1"
            },
            new Player()
            {
                Id = "baac2b19-bbd2-468d-bd3b-5bd18aba98d7",
                Name = "Actor 2"
            },
            new Player()
            {
                Id = "5c93ba13-e803-49c1-b465-d471607e97b3",
                Name = "Actor 3"
            },
        };

        public TeamServiceTests()
        {
            _playerRepositoryMock = new Mock<IPlayerRepository>();
            _teamRepositoryMock = new Mock<ITeamRepository>();
        }

        [Fact]
        async Task GetTeamsById_ReturnsData()
        {
            // Arrange
            var teamId = _teams[0].Id;

            _teamRepositoryMock.Setup(x => x.GetTeamsById(It.IsAny<string>()))
                    .Returns((string id) =>
                        _teams.FirstOrDefault(x => x.Id == id));

            var teamService = new teamService(_teamRepositoryMock.Object, _playerRepositoryMock.Object);

            // Act
            var result = await teamService.GetTeamsById(teamId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(teamId, result.Id);
        }

        [Fact]
        void GetTeamsById_MovieNotExist()
        {
            // Arrange
            var teamId = "c3bd1985-792e-4208-af81-4d154bff15c9";

            _reamRepositoryMock.Setup(x => x.GetMoviesById(It.IsAny<string>()))
                    .Returns((string id) =>
                        _movies.FirstOrDefault(x => x.Id == id));

            var teamService = new TeamService(_teamRepositoryMock.Object, _playerRepositoryMock.Object);

            // Act
            var result = teamService.GetTeamsById(teamId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        void GetTeamsById_TeamsWithInvalidGuid()
        {
            // Arrange
            var teamId = "c3bd1985-792e-4208-af81-4d154bff15c9-12";

            _teamRepositoryMock.Setup(x => x.GetTeamsById(It.IsAny<string>()))
                    .Returns((string id) =>
                        _teams.First(x => x.Id == id));

            var teamService = new TeamService(_teamRepositoryMock.Object, _playerRepositoryMock.Object);

            // Act
            var result = teamService.GetTeamsById(teamId);

            // Assert
            Assert.Null(result);
        }
    }
}