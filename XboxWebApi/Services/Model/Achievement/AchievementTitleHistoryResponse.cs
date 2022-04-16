using System;
using System.Collections.Generic;
using System.Text;

namespace XboxWebApi.Services.Model.Achievement
{
    public class AchievementTitleHistoryV2Response
    {
        public AchievementTitleHistoryV2Response()
        {
            Titles = new List<AchievementUserTitleV2>();
        }

        public IReadOnlyCollection<AchievementUserTitleV2> Titles { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }

    public class AchievementTitleHistoryV1Response
    {
        public AchievementTitleHistoryV1Response()
        {
            Titles = new List<AchievementUserTitleV1>();
        }

        public DateTime Version { get; set; }

        public IReadOnlyCollection<AchievementUserTitleV1> Titles { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
