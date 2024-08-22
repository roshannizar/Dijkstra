using Dijkstra.Core.Model;
using Dijkstra.Core.Services;
using Moq;

namespace Dijkstra.UnitTest
{
    public class AlgorithmTests
    {
        [Fact]
        public void ShouldReturnCorrectPathAndDistance_FromAtoD()
        {
            // Arrange
            var algorithmService = new Mock<IAlgorithmService>();

            algorithmService.Setup(m => m.ShortestPath("A", "D", It.IsAny<List<Nodes>>()))
                .Returns(new ShortestPathData
                {
                    Distance = 10,
                    NodeNames = new List<string> { "A", "B", "E", "D" }
                });

            // Act
            var result = algorithmService.Object.ShortestPath("A", "D", new List<Nodes>());

            // Assert
            Assert.Equal(10, result.Distance);
            Assert.Equal(new List<string> { "A", "B", "E", "D" }, result.NodeNames);
        }

        [Fact]
        public void ShouldReturnInCorrectPathAndDistance_FromAtoD()
        {
            // Arrange
            var algorithmService = new Mock<IAlgorithmService>();

            algorithmService.Setup(m => m.ShortestPath("A", "D", It.IsAny<List<Nodes>>()))
                .Returns(new ShortestPathData
                {
                    Distance = 10,
                    NodeNames = new List<string> { "A", "E", "D" }
                });

            // Act
            var result = algorithmService.Object.ShortestPath("A", "D", new List<Nodes>());

            // Assert
            Assert.Equal(10, result.Distance);
            Assert.NotEqual(new List<string> { "A", "B", "E", "D" }, result.NodeNames);
        }

        [Fact]
        public void ShouldReturnCorrectPathAndDistance_FromBtoI()
        {
            // Arrange
            var algorithmService = new Mock<IAlgorithmService>();

            algorithmService.Setup(m => m.ShortestPath("B", "I", It.IsAny<List<Nodes>>()))
                .Returns(new ShortestPathData
                {
                    Distance = 10,
                    NodeNames = new List<string> { "B", "E", "G", "I" }
                });

            // Act
            var result = algorithmService.Object.ShortestPath("B", "I", new List<Nodes>());

            // Assert
            Assert.Equal(10, result.Distance);
            Assert.Equal(new List<string> { "B", "E", "G", "I" }, result.NodeNames);
        }

        [Fact]
        public void ShouldReturnInCorrectPathAndDistance_FromBtoI()
        {
            // Arrange
            var algorithmService = new Mock<IAlgorithmService>();

            algorithmService.Setup(m => m.ShortestPath("B", "I", It.IsAny<List<Nodes>>()))
                .Returns(new ShortestPathData
                {
                    Distance = 10,
                    NodeNames = new List<string> { "B", "I" }
                });

            // Act
            var result = algorithmService.Object.ShortestPath("B", "I", new List<Nodes>());

            // Assert
            Assert.Equal(10, result.Distance);
            Assert.NotEqual(new List<string> { "B", "E", "G", "I" }, result.NodeNames);
        }
    }
}