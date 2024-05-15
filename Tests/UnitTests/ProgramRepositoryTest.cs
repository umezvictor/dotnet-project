using dotnet_task.Domain.Models;
using dotnet_task.Repository;

namespace Tests.UnitTests
{
    using dotnet_task.Database;
    using Microsoft.Azure.Cosmos;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;



    public class ProgramRepositoryTest
    {
        private readonly Mock<IConnection> _connecionMock = new();
       
        private readonly ProgramRepository _serviceToTest;

        public ProgramRepositoryTest()
        {

           
            // Initialize the ProgramRepository with the mocked CosmosClient
            _serviceToTest = new ProgramRepository(_connecionMock.Object);
        }

        [Fact]
        public async Task GetProgramsAsync_ReturnsAllPrograms()
        {
            // Arrange
            var questions = new List<Question>
        {
            new Question{Id = "12123232323", Title = "tell us about yourself"},
            new Question{Id = "11143432367", Title = "Have you graduated from college?"},
        };

            var personalInformation = new Dictionary<string, List<Question>>
        {
            { "Paragraph", questions },
            { "YesNo", questions }
        };

            var additionalQuestions = new Dictionary<string, List<Question>>
        {
            { "Paragraph", questions },
            { "YesNo", questions }
        };

            var program = new InternshipProgram
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Summer internship program",
                Description = "A good program for graduates",
                AdditionalQuestions = additionalQuestions,
                PersonalInformation = personalInformation
            };

            var program2 = new InternshipProgram
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Online MBA program",
                Description = "A good program for graduates",
                AdditionalQuestions = additionalQuestions,
                PersonalInformation = personalInformation
            };

            var samplePrograms = new List<InternshipProgram> { program, program2 };


            _connecionMock.Setup(x => x.GetContainer()).Returns(It.IsAny<Container>());



            // Act
            var result = await _serviceToTest.GetProgramsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("Summer internship program", result.First().Title);
        }
    }




    //public class ProgramRepositoryTest
    //{
    //    private readonly Mock<CosmosClient> _cosmosClientMock;
    //    private readonly Mock<Container> _containerMock;
    //    private readonly Mock<Database> _databaseMock;
    //    private readonly ProgramRepository _serviceToTest;


    //    public ProgramRepositoryTest()
    //    {
    //        _cosmosClientMock = new Mock<CosmosClient>();
    //        _containerMock = new Mock<Container>();
    //        _databaseMock = new Mock<Database>();

    //        // Setup the mock for CosmosClient to return the container mock
    //        _cosmosClientMock
    //            .Setup(x => x.GetContainer(It.IsAny<string>(), It.IsAny<string>()))
    //            .Returns(_containerMock.Object);

    //        // Setup the mock for CreateDatabaseIfNotExistsAsync

    //        var databaseResponseMock = new Mock<DatabaseResponse>();
    //        databaseResponseMock.Setup(x => x.Database).Returns(_databaseMock.Object);


    //        _cosmosClientMock
    //        .Setup(x => x.CreateDatabaseIfNotExistsAsync(It.IsAny<string>(), It.IsAny<ThroughputProperties>(), null, It.IsAny<CancellationToken>()))
    //        .ReturnsAsync(databaseResponseMock.Object);

    //        // Setup the mock for CreateContainerIfNotExistsAsync
    //        var containerResponseMock = new Mock<ContainerResponse>();
    //        containerResponseMock.Setup(x => x.Container).Returns(_containerMock.Object);

    //        _databaseMock
    //            .Setup(x => x.CreateContainerIfNotExistsAsync(It.IsAny<ContainerProperties>(), It.IsAny<ThroughputProperties>(), null, It.IsAny<CancellationToken>()))
    //            .ReturnsAsync(containerResponseMock.Object);

    //        // Initialize the ProgramRepository with the mocked CosmosClient
    //        _serviceToTest = new ProgramRepository(_cosmosClientMock.Object, "testdb", "mycontainer");
    //    }

    //    [Fact]
    //    public async Task GetProgramsAsync_ReturnsAllPrograms()
    //    {
    //        // Arrange


    //        var questions = new List<Question>
    //        {
    //            new Question{Id = "12123232323", Title = "tell us about yourself"},
    //            new Question{Id = "11143432367", Title = "Have you graduated from college?"},
    //        };

    //        Dictionary<string, List<Question>> PersonalInformation = new Dictionary<string, List<Question>>();
    //        Dictionary<string, List<Question>> AdditionalQuestions = new Dictionary<string, List<Question>>();

    //        PersonalInformation.Add("Paragraph", questions);
    //        PersonalInformation.Add("YesNo", questions);

    //        AdditionalQuestions.Add("Paragraph", questions);
    //        AdditionalQuestions.Add("YesNo", questions);


    //        var program = new InternshipProgram
    //        {
    //            Id = Guid.NewGuid().ToString(),
    //            Title = "Summer internship program",
    //            Description = "A good program for graduates",
    //            AdditionalQuestions = AdditionalQuestions,
    //            PersonalInformation = PersonalInformation

    //        };

    //        var program2 = new InternshipProgram
    //        {
    //            Id = Guid.NewGuid().ToString(),
    //            Title = "Online MBA program",
    //            Description = "A good program for graduates",
    //            AdditionalQuestions = AdditionalQuestions,
    //            PersonalInformation = PersonalInformation

    //        };

    //        var samplePrograms = new List<InternshipProgram>();
    //        samplePrograms.Add(program);
    //        samplePrograms.Add(program2);



    //        var feedResponseMock = new Mock<FeedResponse<InternshipProgram>>();
    //        feedResponseMock
    //            .Setup(x => x.Resource)
    //            .Returns(samplePrograms);

    //        var feedIteratorMock = new Mock<FeedIterator<InternshipProgram>>();
    //        feedIteratorMock
    //            .SetupSequence(x => x.HasMoreResults)
    //            .Returns(true)
    //            .Returns(false);

    //        feedIteratorMock
    //            .Setup(x => x.ReadNextAsync(It.IsAny<CancellationToken>()))
    //            .ReturnsAsync(feedResponseMock.Object);

    //        _containerMock
    //            .Setup(x => x.GetItemQueryIterator<InternshipProgram>(It.IsAny<QueryDefinition>(), null, null))
    //            .Returns(feedIteratorMock.Object);

    //        // Act
    //        var result = await _serviceToTest.GetProgramsAsync();

    //        // Assert
    //        Assert.NotNull(result);
    //        Assert.Equal(2, result.Count());
    //        Assert.Equal("Program 1", result.First().Title);
    //    }
    //}
}


