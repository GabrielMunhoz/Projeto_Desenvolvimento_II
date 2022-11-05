using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PlayersBook.Domain.DTOs;
using PlayersBook.Domain.Entities;
using PlayersBook.Domain.Interfaces;
using System.Net.Http.Headers;
using System.Text;

namespace PlayersBook.Data.Repositories
{
    public class TwitchRepository : ITwitchRespository
    {
        private string ClientSecret = "e2oeysterhf96598rwycb1vm64ozci";
        private string ClientId = "vr5zhytfqelkey6c2wxd9byk3pck8w";

        public readonly TwitchConnected _connected;
        private readonly ILogger<TwitchRepository> logger;

        public TwitchRepository(ILogger<TwitchRepository> logger)
        {
            this.logger = logger;
            _connected = TwitchLoginAsync().Result;
        }
       
        private async Task<TwitchConnected> TwitchLoginAsync()
        {
            logger.LogInformation($"Method: {nameof(TwitchLoginAsync)} -- Repository: {nameof(TwitchRepository)}");

            try
            {
                using (HttpClient ClientHttp = new HttpClient())
                {
                    string baseUrl = "https://id.twitch.tv/oauth2/token?";

                    StringBuilder bodyRequest = new StringBuilder();

                    bodyRequest.AppendFormat("client_id={0}", ClientId);
                    bodyRequest.AppendFormat("&client_secret={0}", ClientSecret);
                    bodyRequest.Append("&grant_type=client_credentials");

                    var reqUrlTwitch = baseUrl + bodyRequest.ToString();

                    var response = await ClientHttp.PostAsync(reqUrlTwitch, null).ConfigureAwait(false);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                        {
                            var retorno = await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false);
                            if (retorno != null)
                            {
                                TwitchConnected connected = JsonConvert.DeserializeObject<TwitchConnected>(retorno);
                                return connected;
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                logger.LogError($"Method: {nameof(TwitchLoginAsync)} -- Repository: {nameof(TwitchRepository)} - Ex : {ex.Message}");
                throw;
            }
        }

        public async Task<RetTopGamesTwitchDto?> GetGamesCategoryAsync(long id)
        {
            logger.LogInformation($"Method: {nameof(GetGamesCategoryAsync)} -- Repository: {nameof(TwitchRepository)}");

            try
            {
                using (HttpClient ClientHttp = new HttpClient())
                {
                    string baseUrl = "https://api.twitch.tv/helix/games";

                    var reqUrlTwitch = $"{baseUrl}?id={id}";

                    ClientHttp.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", _connected.Access_Token);
                    ClientHttp.DefaultRequestHeaders.Add("Client-Id", ClientId);

                    var response = await ClientHttp.GetAsync(reqUrlTwitch);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                        {
                            var retorno = await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false);
                            RetTopGamesTwitchDto gameCategory = JsonConvert.DeserializeObject<RetTopGamesTwitchDto>(retorno);
                            return gameCategory;
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Method: {nameof(GetGamesCategoryAsync)} -- Repository: {nameof(TwitchRepository)} - Ex : {ex.Message}");
                throw;
            }
        }
        
        public async Task<RetTopGamesTwitchDto?> GetTopGamesCategoryAsync()
        {
            logger.LogInformation($"Method: {nameof(GetTopGamesCategoryAsync)} -- Repository: {nameof(TwitchRepository)}");
            try
            {
                using (HttpClient ClientHttp = new HttpClient())
                {
                    string baseUrl = "https://api.twitch.tv/helix/games/top";

                    ClientHttp.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", _connected.Access_Token);
                    ClientHttp.DefaultRequestHeaders.Add("Client-Id", ClientId);

                    var response = await ClientHttp.GetAsync(baseUrl);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                        {
                            var retorno = await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false);

                            RetTopGamesTwitchDto connected = JsonConvert.DeserializeObject<RetTopGamesTwitchDto>(retorno);
                            return connected;

                        }
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Method: {nameof(GetTopGamesCategoryAsync)} -- Repository: {nameof(TwitchRepository)} - Ex : {ex.Message}");
                throw;
            }
        }

        public async Task<List<ChannelStreamDto>?> GetChannelsStreamsByNameAsync(string channelName)
        {
            logger.LogInformation($"Method: {nameof(GetChannelsStreamsByNameAsync)} -- Repository: {nameof(TwitchRepository)}");
            try
            {
                using (HttpClient ClientHttp = new HttpClient())
                {
                    string baseUrl = $"https://api.twitch.tv/helix/search/channels?query={channelName.ToLower()}";

                    ClientHttp.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", _connected.Access_Token);
                    ClientHttp.DefaultRequestHeaders.Add("Client-Id", ClientId);

                    var response = await ClientHttp.GetAsync(baseUrl);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                        {
                            var retorno = await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false);

                            JObject data = JObject.Parse(retorno);
                            IList<JToken> results = data["data"].Children().ToList();

                            List<ChannelStreamDto> listChannelsStreams = results.Select(x => x.ToObject<ChannelStreamDto>()).ToList();

                            return listChannelsStreams;

                        }
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Method: {nameof(GetChannelsStreamsByNameAsync)} -- Repository: {nameof(TwitchRepository)} - Ex : {ex.Message}");
                throw;
            }
        }

        public async Task<List<GamesCategory>?> GetGamesCategoryByNameAsync(string gameName)
        {
            logger.LogInformation($"Method: {nameof(GetGamesCategoryByNameAsync)} -- Repository: {nameof(TwitchRepository)}");
            try
            {
                using (HttpClient ClientHttp = new HttpClient())
                {
                    string baseUrl = $"https://api.twitch.tv/helix/search/categories?query={gameName.ToLower()}";

                    ClientHttp.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", _connected.Access_Token);
                    ClientHttp.DefaultRequestHeaders.Add("Client-Id", ClientId);

                    var response = await ClientHttp.GetAsync(baseUrl);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                        {
                            var retorno = await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false);

                            JObject ret = JObject.Parse(retorno);
                            List<JToken>? data = ret["data"].ToList();

                            List<GamesCategory> gameCategory = data.Select(x => x.ToObject<GamesCategory>()).ToList(); 
                            
                            return gameCategory;
                        }
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Method: {nameof(GetGamesCategoryByNameAsync)} -- Repository: {nameof(TwitchRepository)} - Ex : {ex.Message}");
                throw;
            }
        }
    }

    public class TwitchConnected
    {
        public string Access_Token { get; set; }
        public string Expires_In { get; set; }
        public string Token_type { get; set; }
    }
}
