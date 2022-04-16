using System;
using System.Collections.Generic;
using System.Text;

namespace XboxWebApi.Services.Model.Achievement
{
    public class AchievementTitleHistoryQuery : Common.IHttpRequestQuery
    {
        /// <summary>
        /// Return items beginning after the given number of items. For example, skipItems=3 will retrieve items beginning with the fourth item retrieved.
        /// </summary>
        public int? SkipItems { get; set; }

        /// <summary>
        /// Maximum number of items to return from the collection, which can be combined with skipItems and continuationToken to return a range of items. The service may provide a default value if maxItems is not present, and may return fewer than maxItems, even if the last page of results has not yet been returned.
        /// </summary>
        public int? MaxItems { get; set; }

        /// <summary>
        /// Return the items starting at the given continuation token.
        /// </summary>
        public string ContinuationToken { get; set; }

        public Dictionary<string, string> GetQuery()
        {
            var query = new Dictionary<string, string>();

            if (SkipItems != null) 
                query.Add("skipItems", SkipItems.ToString());

            if (MaxItems != null) 
                query.Add("maxItems", MaxItems.ToString());

            if (ContinuationToken != null) 
                query.Add("continuationToken", ContinuationToken);

            return query;
        }
    }
}
