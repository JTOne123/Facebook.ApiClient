﻿using System;
using System.Collections.Generic;
using System.Linq;
using FacebookApi.Enums;
using FacebookApi.Enums.Api;
using FacebookApi.Exceptions;
using RestSharp.Deserializers;

namespace FacebookApi.Entities
{
    /// <summary>
    /// An ad object contains the data necessary to visually display an ad and associate it with a corresponding ad set.
    /// <para>https://developers.facebook.com/docs/marketing-api/reference/adgroup</para>
    /// </summary>
    public class Ad
    {
        /// <summary>
        /// The ID of this ad.
        /// </summary>
        [DeserializeAs(Name = "id")]
        public long? Id { get; set; }

        /// <summary>
        /// The ID of the ad account that this ad belongs to.
        /// </summary>
        [DeserializeAs(Name = "account_id")]
        public long? AccountId { get; set; }

        /// <summary>
        /// The review feedback for this ad after it is reviewed.
        /// </summary>
        [DeserializeAs(Name = "ad_review_feedback")]
        public AdgroupReviewFeedback AdReviewFeedback { get; set; }

        /// <summary>
        /// Ad labels associated with this ad
        /// </summary>
        [DeserializeAs(Name = "adlabels")]
        public List<AdLabel> AdLables { get; set; }

        /// <summary>
        /// Ad set that contains this ad
        /// </summary>
        [DeserializeAs(Name = "adset")]
        public AdSet Adset { get; set; }

        /// <summary>
        /// ID of the ad set that contains the ad
        /// </summary>
        [DeserializeAs(Name = "adset_id")]
        public long? AdsetId { get; set; }

        /// <summary>
        /// Bid amount for this ad which will be used in auction instead of the ad set bid_amount, if specified. Any updates to the ad set bid_amount will overwrite this value with the new ad set value.
        /// </summary>
        [DeserializeAs(Name = "bid_amount")]
        public int? BidAmount { get; set; }

        /// <summary>
        /// A dictionary of {objective}:{value} that you place on your bid, based on the bid_type of ad set. Values are defined in your currency's minimum denomination
        /// </summary>
        /// <example>
        /// <para>For bid_type=CPM, bid_info={'IMPRESSIONS':&lt;value&gt;}</para>
        /// <para>For bid_type=CPC, bid_info={'CLICKS':&lt;value&gt;}</para>
        /// <para>bid_type=ABSOLUTE_OCPM, bid_info={'ACTIONS':&lt;value&gt;, 'REACH':&lt;value&gt;, 'CLICKS':&lt;value&gt;, 'SOCIAL':&lt;value&gt;}</para>
        /// <para>bid_type=CPA, bid_info={'ACTIONS':&lt;value&gt;}</para>
        /// </example>
        [DeserializeAs(Name = "bid_info")]
        public Dictionary<string, int> BidInfo { get; set; }

        /// <summary>
        /// Bid type
        /// </summary>
        [DeserializeAs(Name = "bid_type")]
        public BidType BidType { get; set; }

        /// <summary>
        /// Ad campaign that contains this ad
        /// </summary>
        [DeserializeAs(Name = "campaign")]
        public Campaign Campaign { get; set; }

        /// <summary>
        /// ID of the ad campaign that contains this ad
        /// </summary>
        [DeserializeAs(Name = "campaign_id")]
        public long? CampaignId { get; set; }

        /// <summary>
        /// The configured status of the ad. Prefer using 'status' instead of this.
        /// </summary>
        [DeserializeAs(Name = "configured_status")]
        public AdConfiguredStatus? ConfiguredStatus { get; set; }

        /// <summary>
        /// Conversion specs
        /// </summary>
        [DeserializeAs(Name = "conversion_specs")]
        //public List<ConversionActionQuery> ConversionSpec { get; set; }
        public string ConversionSpec { get; set; }

        /// <summary>
        /// Created time
        /// </summary>
        [DeserializeAs(Name = "created_time")]
        public string CreatedTime { get; set; }

        /// <summary>
        /// Ad creative
        /// </summary>
        [DeserializeAs(Name = "creative")]
        public Creative Creative { get; set; }

        /// <summary>
        /// The effective status of the ad.
        /// </summary>
        [DeserializeAs(Name = "effective_status")]
        public AdEffectiveStatus? EffectiveStatus { get; set; }

        /// <summary>
        /// Last Updated By App ID
        /// </summary>
        [DeserializeAs(Name = "last_updated_by_app_id")]
        public string LastUpdatedByAppId { get; set; }

        /// <summary>
        /// Name of the ad.
        /// </summary>
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// If there are recommendations for this ad, this field includes them. Otherwise, this field will be null.
        /// </summary>
        [DeserializeAs(Name = "recommendations")]
        public List<AdRecommendation> Recommendations { get; set; }

        /// <summary>
        /// The source ad that this ad is copied from
        /// </summary>
        [DeserializeAs(Name= "source_ad")]
        public Ad SourceAd { get; set; }

        /// <summary>
        /// The source ad id that this ad is copied from
        /// </summary>
        [DeserializeAs(Name = "source_ad_id")]
        public long? SourceAdId { get; set; }

        /// <summary>
        /// The configured status of the ad. The field returns the same value as 'configured_status', and is the suggested one to use.
        /// </summary>
        [DeserializeAs(Name = "status")]
        public AdConfiguredStatus Status { get; set; }

        /// <summary>
        /// Tracking specs
        /// </summary>
        [DeserializeAs(Name = "tracking_specs")]
        public string TrackingSpec { get; set; }
        //public List<ConversionActionQuery> TrackingSpec { get; set; }

        /// <summary>
        /// Updated time
        /// </summary>
        [DeserializeAs(Name = "updated_time")]
        public string UpdatedTime { get; set; }


        public static IList<string> GetApiSelectors(bool isIncludeCreativeFields = false,bool isIncludeCampaignFields = false,bool isIncludeAdsetFields = false)
        {
            var apiFields = typeof(Ad).GetProperties()
                .Select(e => e.GetCustomAttributes(typeof(DeserializeAsAttribute), true)).Where(e => e.Length > 0)
                .Select(e => e.First() as DeserializeAsAttribute).Where(e => e != null).Select(e => e.Name).ToList();

            if (isIncludeCampaignFields)
            {
                apiFields.Remove("campaign");
                apiFields.Add($"campaign.fields({string.Join(",", Campaign.GetApiSelectors())})");
            }

            if (isIncludeAdsetFields)
            {
                apiFields.Remove("adset");
                apiFields.Add($"adset.fields({string.Join(",", AdSet.GetApiSelectors(isIncludeCampaignFields))})");
            }

            if (isIncludeCreativeFields)
            {
                apiFields.Remove("creative");
                apiFields.Add($"creative.fields({string.Join(",", Creative.GetApiSelectors())})");
            }

            return apiFields;
        }
    }
}
