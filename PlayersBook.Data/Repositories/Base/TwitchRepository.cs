using Newtonsoft.Json;
using PlayersBook.Domain.DTOs;
using PlayersBook.Domain.Entities;
using PlayersBook.Domain.Interfaces;
using System.Net.Http.Headers;
using System.Text;

namespace PlayersBook.Data.Repositories.Base
{
    public class TwitchRepository : ITwitchRespository
    {
        private string ClientSecret = "e2oeysterhf96598rwycb1vm64ozci";
        private string ClientId = "vr5zhytfqelkey6c2wxd9byk3pck8w";

        public readonly TwitchConnected _connected;
        public TwitchRepository()
        {
            _connected = TwitchLoginAsync().Result;
        }
        private async Task<TwitchConnected> TwitchLoginAsync()
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
                            return (connected);
                        }
                    }
                }
            }
            return null;
        }

        public async Task<RetTopGamesTwitchDto> GetGamesCategoryAsync(long id)
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
        public async Task<RetTopGamesTwitchDto> GetTopGamesCategoryAsync()
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
    }

    public class TwitchConnected
    {
        public string Access_Token { get; set; }
        public string Expires_In { get; set; }
        public string Token_type { get; set; }
    }
}
