using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using PlayersBook.Data.Repositories;
using PlayersBook.Domain.DTOs;
using PlayersBook.Domain.Interfaces;

namespace PlayersBook.Application.Test.TestTwitch
{
    public class TwitchRepositoryTest
    {
        private readonly Mock<ILogger<TwitchRepository>> logger;
        private readonly TwitchRepository twitchRepository;

        public TwitchRepositoryTest()
        {
            logger = new Mock<ILogger<TwitchRepository>>();

            twitchRepository = new TwitchRepository(logger.Object);

        }
        [Fact]
        public async Task LoginTwitchTest()
        {
            var result = await twitchRepository.GetGamesCategoryAsync(516575); //Valorant

            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetGamesCategoryAsync_Success()
        {
            var result = await twitchRepository.GetGamesCategoryAsync(516575); //Valorant
            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetTopGamesCategoryAsync_Success()
        {
            var result = await twitchRepository.GetTopGamesCategoryAsync();
            Assert.NotNull(result?.GamesCategories?.FirstOrDefault()?.BoxArtUrl);
            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetChannelsStreamsByNameAsync_Success()
        {
            string channelName = "dmunhoz20"; 

            List<ChannelStreamDto>? result = await twitchRepository.GetChannelsStreamsByNameAsync(channelName);
            Assert.NotNull(result?.FirstOrDefault()?.ImageProfile);
            Assert.NotNull(result);
        }
        [Fact]
        public async Task GetGamesCategoryByNameAsync_Success()
        {
            string gameName = "Fortnite"; 

            var result = await twitchRepository.GetGamesCategoryByNameAsync(gameName);
            Assert.NotNull(result?.FirstOrDefault()?.BoxArtUrl);
            Assert.NotNull(result);
        }
    }
}
