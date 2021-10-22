﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoNineDemoSite.Core.Features.Shared.Extensions;
using generatedModels = UmbracoNineDemoSite.Core;

namespace UmbracoNineDemoSite.Core.Features.SearchPage
{
	public class SearchPageController : RenderController
	{
		public SearchPageController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor) { }

		public IActionResult SearchPage(ContentModel model)
		{
			var mbModel = model.Content as generatedModels.SearchPage ?? new generatedModels.SearchPage(model.Content, null);
			var viewModel = new SearchPageViewModel()
			{
				Heading = mbModel.Heading,
				SearchForm = new SearchFormModel
				{
					NoResultsFound = mbModel.NoResultsFoundText,
					TotalResults = mbModel.TotalResults,
					SearchTermText = mbModel.SearchTermText
				}
			};
			viewModel.MapSitePageBase(mbModel);

			return CurrentTemplate(viewModel);
		}
	}
}
