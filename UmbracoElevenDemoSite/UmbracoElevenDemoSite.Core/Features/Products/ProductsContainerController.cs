﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using System.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Extensions;
using UmbracoElevenDemoSite.Core.Features.Shared.Extensions;
using UmbracoElevenDemoSite.Integrations.Products.Entities;
using UmbracoElevenDemoSite.Integrations.Products.Services;
using generatedModels = UmbracoElevenDemoSite.Core;

namespace UmbracoElevenDemoSite.Core.Features.Products
{
    public class ProductsContainerController : RenderController
    {
        private readonly IProductService productService;

        public ProductsContainerController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, IProductService productService) : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            this.productService = productService;
        }

        public IActionResult ProductsContainer(ContentModel model)
        {
            var mbModel = model.Content as generatedModels.ProductsContainer ?? new generatedModels.ProductsContainer(model.Content, null);
            var currentProduct = CurrentProduct;
            if (currentProduct == null)
            {
                var viewModel = new ProductsContainerViewModel()
                {
                    Products = this.productService.GetAll().Select(product => new ProductPageViewModel(product)),
                    Heading = mbModel.Heading
                };
                viewModel.MapSitePageBase(mbModel);

                return View("ProductsContainer", viewModel);
            }
            else
            {
                var viewModel = new ProductPageViewModel(currentProduct)
                {
                    Heading = mbModel.Heading,
                    SiteName = mbModel?.Root().Name
                };

                return View("ProductPage", viewModel);
            }
        }

        public IProduct CurrentProduct
        {
            get
            {
                var segments = Request.Path.Value.Split("/");
                if (!int.TryParse(segments[2], out var id))
                {
                    return null;
                }
                return this.productService.Get(id);
            }
        }
    }
}
