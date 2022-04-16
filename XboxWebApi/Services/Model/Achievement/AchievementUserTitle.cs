using System;
using System.Collections.Generic;
using System.Linq;

namespace XboxWebApi.Services.Model.Achievement
{
    public enum UserTitleTypeV2
    {
        Unknown = -1,
        Game,
        DGame,
        LiveApp
    }

    public enum UserTitlePlatformV2
    {
        Unknown = -1,
        XboxOne,

        /// <summary>
        /// Xbox One Dev Kit
        /// </summary>
        Durango,

        WindowsOneCore
    }

    public enum UserTitleTypeV1
    {
        Unknown = -1,
        Game = 1,
        DigitalGame = 3,
        App = 5
    }

    public enum UserTitlePlatformV1
    {
        Unknown = -1,
        Xbox360 = 1,
        WindowsPhone = 15,
        WindowsStore = 17
    }

    /// <summary>
    /// Xbox One (v2) API UserTitle object
    /// </summary>
    public class AchievementUserTitleV2
    {
        /// <summary>
        /// The time an achievement was last earned.
        /// </summary>
        public DateTime LastUnlock { get; set; }

        /// <summary>
        /// The unique identifier for the title.
        /// </summary>
        public uint TitleId { get; set; }

        /// <summary>
        /// ID of the primary service config set associated with the title.
        /// </summary>
        public string ServiceConfigId { get; set; }

        /// <summary>
        /// The title type.
        /// </summary>
        public string TitleType { get; set; }

        public UserTitleTypeV2 TitleTypeEnum
        {
            get
            {
                if (Enum.TryParse<UserTitleTypeV2>(TitleType, out var titleType))
                {
                    return titleType;
                }
                return UserTitleTypeV2.Unknown;
            }
        }

        /// <summary>
        /// The supported platform.
        /// </summary>
        public string Platform { get; set; }

        public UserTitlePlatformV2 PlatformEnum
        {
            get
            {
                if (Enum.TryParse<UserTitlePlatformV2>(Platform, out var platform))
                {
                    return platform;
                }
                return UserTitlePlatformV2.Unknown;
            }
        }

        /// <summary>
        /// The text name of this title. Maximum length 22.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The number of achievements earned for the title, including unlocked achievements and successfully completed challenges.
        /// </summary>
        public uint EarnedAchievements { get; set; }

        /// <summary>
        /// The total gamerscore this user has earned in this title.
        /// </summary>
        public uint CurrentGamerscore { get; set; }

        /// <summary>
        /// The total possible gamerscore for this title.
        /// </summary>
        public uint MaxGamerscore { get; set; }
    }

    /// <summary>
    /// Xbox 360 (v1) API UserTitle object
    /// </summary>
    public class AchievementUserTitleV1
    {
        /// <summary>
        /// The time the title was last played.
        /// </summary>
        public DateTime LastPlayed { get; set; }

        /// <summary>
        /// The unique identifier for the title.
        /// </summary>
        public uint TitleId { get; set; }  
        
        public uint Sequence { get; set; }

        /// <summary>
        /// The title type.
        /// </summary>
        public uint TitleType { get; set; }

        public UserTitleTypeV1 TitleTypeEnum
        {
            get
            {
                if (Enum.IsDefined(typeof(UserTitleTypeV1), TitleType))
                {
                    return (UserTitleTypeV1)TitleType;
                }
                return UserTitleTypeV1.Unknown;
            }
        }

        /// <summary>
        /// The supported platform.
        /// </summary>
        public ICollection<uint> Platforms { get; set; }

        public ICollection<UserTitlePlatformV1> PlatformsEnum
        {
            get
            {
                return Platforms.Select(p => Enum.IsDefined(typeof(UserTitlePlatformV1), p) ? (UserTitlePlatformV1)p : UserTitlePlatformV1.Unknown).ToList();
            }
        }

        /// <summary>
        /// The text name of this title. Maximum length 22.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The number of achievements earned for the title, including unlocked achievements and successfully completed challenges.
        /// </summary>
        public uint CurrentAchievements { get; set; }

        /// <summary>
        /// The number of total achievements for the title
        /// </summary>
        public uint TotalAchievements { get; set; }

        /// <summary>
        /// The total gamerscore this user has earned in this title.
        /// </summary>
        public uint CurrentGamerscore { get; set; }

        /// <summary>
        /// The total possible gamerscore for this title.
        /// </summary>
        public uint TotalGamerscore { get; set; }
    }
}
