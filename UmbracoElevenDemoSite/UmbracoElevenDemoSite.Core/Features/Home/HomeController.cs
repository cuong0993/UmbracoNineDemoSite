﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;
using UmbracoElevenDemoSite.Core.Features.Shared.Components.Hero;
using UmbracoElevenDemoSite.Core.Features.Shared.Extensions;
using generatedModels = UmbracoElevenDemoSite.Core;

namespace UmbracoElevenDemoSite.Core.Features.Home
{
    public class HomeController : RenderController
    {
        public HomeController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor) { }

        public IActionResult Home(ContentModel model)
        {
            var mbModel = model.Content as generatedModels.Home ?? new generatedModels.Home(model.Content, null);
            var viewModel = new HomeViewModel()
            {
                Heading = mbModel.Heading,
                Preamble = mbModel.Preamble,
                BackgroundImage = mbModel.BackgroundImage,
                CallToActionLabel = mbModel.CallToActionLabel,
                CallToActionUrl = mbModel.CallToActionUrl?.Url(),
                Blocks = mbModel.Blocks
            };
            viewModel.Hero = new HeroViewModel()
            {
                CallToActionUrl = viewModel.CallToActionUrl,
                CallToActionLabel = viewModel.CallToActionLabel,
                BackgroundImageUrl = viewModel.BackgroundImage,
                Preamble = viewModel.Preamble,
                Heading = viewModel.Heading
            };
            viewModel.MapSitePageBase(mbModel);

            return View(viewModel);
        }
    }
}