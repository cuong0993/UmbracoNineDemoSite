﻿using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.Blocks;

namespace UmbracoElevenDemoSite.Core.Features.Shared.Components.ContactForm
{
    [ViewComponent(Name = "contactForm")]
    public class ContactFormComponent : ViewComponent
    {
        public IViewComponentResult Invoke(BlockListItem model)
        {
            return View(new ContactFormViewModel(model));
        }
    }
}
