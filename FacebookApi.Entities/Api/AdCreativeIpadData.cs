﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Deserializers;

namespace FacebookApi.Entities
{
    /// <summary>
    /// The specification for iPad template spec.
    /// <para>https://developers.facebook.com/docs/marketing-api/reference/ad-creative-ipad-data/</para>
    /// </summary>
    public class AdCreativeIpadData
    {
        /// <summary>
        /// The name of the app, suitable for display, e.g. Electronic Example iPad
        /// </summary>
        [DeserializeAs(Name = "app_name")]
        public string AppName { get; set; }

        /// <summary>
        /// The app ID for the App Store, e.g. 9010
        /// </summary>
        [DeserializeAs(Name = "app_store_id")]
        public string AppStoreId { get; set; }

        /// <summary>
        /// A custom URL scheme for the iPad app, e.g. example-ipad://electronic/id={{product.retailor_id | urlencode}}
        /// </summary>
        [DeserializeAs(Name = "url")]
        public string Url { get; set; }
    }
}