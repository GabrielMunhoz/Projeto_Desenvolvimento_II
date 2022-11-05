using PlayersBook.Data.Repositories;

namespace PlayersBook.Application.Test.TestTwitch
{
    public class TwitchRepositoryTest
    {
        [Fact]
        public async Task LoginTwitchTest()
        {
            TwitchRepository twitchRepository = new TwitchRepository();

            await twitchRepository.GetGamesCategoryAsync(516575); //Valorant
            await twitchRepository.GetTopGamesCategoryAsync(); 
        }
    }
}
