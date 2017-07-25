﻿using RestSharp.Deserializers;

namespace FacebookApi.Entities
{
    /// <summary>
    /// A category for a Facebook Page
    /// <see cref="https://developers.facebook.com/docs/graph-api/reference/page-category/"/>
    /// </summary>
    public class PageCategory
    {
        /// <summary>
        /// The id of the category
        /// </summary>
        [DeserializeAs(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the category
        /// </summary>
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }
    }
}