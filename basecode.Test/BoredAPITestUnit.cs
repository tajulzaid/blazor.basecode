using basecode.Model;
using basecode.Services;
using Moq;

namespace basecode.Test
{
    public class BoredAPITestUnit
    {
        [Fact]
        public async void GetActivity_ReturnsData()
        {
            //Arange
            var repoStub = new Mock<IBoredService>();

            var data = new Bored
            {
                activity = "read a book",
                type = "educational",
                participants = 1,
                price = (decimal)45.50,
                link = "kedaibuku.com",
                key = "1234",
                accessibility = 2.3
            };

            repoStub.Setup(repo => repo.GetSuggestionAsync()).ReturnsAsync(data);
            var service = new DataActivityService(repoStub.Object);

            //Act
            var result = await service.GetDataActivityAsync();

            //Asset
            Assert.Equal("read a book", result.activity);
            Assert.Equal("educational", result.type);
            Assert.Equal(1, result.participants);
            Assert.Equal((decimal)45.50, result.price);
            Assert.Equal("kedaibuku.com", result.link);
            Assert.Equal("1234", result.key);
            Assert.Equal(2.3, result.accessibility);
        }
    }
}