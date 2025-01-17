﻿using Umbraco.Cms.Core.Strings;

namespace UmbracoElevenDemoSite.Core.Features.Shared.Components.ContentBlock
{
    public class ContentBlockViewModel
    {
        public string Heading { get; set; }

        public IHtmlEncodedString BodyText { get; set; }
    }
}
