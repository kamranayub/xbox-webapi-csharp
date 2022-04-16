using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using XboxWebApi.Common;
using XboxWebApi.Services.Model.Achievement;

namespace XboxWebApi.Services.Api
{
    public class AchievementService : XblService
    {
        private Dictionary<string,string> Headers_XONE;
        private Dictionary<string,string> Headers_X360;

        public AchievementService(IXblConfiguration config)
            : base(config, "https://achievements.xboxlive.com/")
        {
            Headers_X360 = new Dictionary<string,string>(){
                {"x-xbl-contract-version", "1"}
            };

            Headers_XONE = new Dictionary<string,string>(){
                {"x-xbl-contract-version", "2"}
            };
        }

        public async Task<HttpResponseMessage> GetAchievementDetailAsync(ulong xuid, string scid, string achievementId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"users/xuid({xuid})/achievements/{scid}/{achievementId}");
            request.Headers.Add(Headers_XONE);
            
            var response = await HttpClient.SendAsync(request);
            return response;
        }

        public async Task<HttpResponseMessage> GetAchievementGameprogressAsync(ulong xuid, ulong titleId)
        {
            AchievementRequestQuery query = new AchievementRequestQuery(titleId);
            var request = new HttpRequestMessage(HttpMethod.Get, $"users/xuid({xuid})/achievements");
            request.Headers.Add(Headers_XONE);
            request.AddQueryParameter(query.GetQuery());
            
            var response = await HttpClient.SendAsync(request);
            return response;
        }

        /// <summary>
        /// Get V2 achievement title history
        /// </summary>
        /// <param name="xuid"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAchievementsRecentProgressAsync(ulong xuid, AchievementTitleHistoryQuery query = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"users/xuid({xuid})/history/titles");
            request.Headers.Add(Headers_XONE);

            if (query != null)
            {
                request.AddQueryParameter(query.GetQuery());
            }

            var response = await HttpClient.SendAsync(request);
            return response;
        }

        public async Task<HttpResponseMessage> GetAchievementsXbox360AllAsync(ulong xuid, ulong titleId)
        {
            AchievementRequestQuery query = new AchievementRequestQuery(titleId);
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"users/xuid({xuid})/titleachievements");
            request.Headers.Add(Headers_X360);
            request.AddQueryParameter(query.GetQuery());
            
            var response = await HttpClient.SendAsync(request);
            return response;
        }

        public async Task<HttpResponseMessage> GetAchievementsXbox360EarnedAsync(ulong xuid, ulong titleId)
        {
            AchievementRequestQuery query = new AchievementRequestQuery(titleId);
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"users/xuid({xuid})/achievements");
            request.Headers.Add(Headers_X360);
            request.AddQueryParameter(query.GetQuery());

            var response = await HttpClient.SendAsync(request);
            return response;
        }


        /// <summary>
        /// Get V1 achievement title history
        /// </summary>
        /// <param name="xuid"></param>
        /// <param name="titleId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAchievementsXbox360RecentProgressAsync(ulong xuid, AchievementTitleHistoryQuery query = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"users/xuid({xuid})/history/titles");
            request.Headers.Add(Headers_X360);

            if (query != null)
            {
                request.AddQueryParameter(query.GetQuery());
            }

            var response = await HttpClient.SendAsync(request);
            return response;
        }
    }
}