﻿using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using NUnit.Framework;
using UmbracoElevenDemoSite.Core.Features.Shared.Components.Header;
using UmbracoElevenDemoSite.Core.Features.Shared.Settings;

namespace UmbracoElevenDemoSite.Tests.Unit.Features.Shared.Components.Footer
{
    [TestFixture]
    public class HeaderViewComponentTests
    {
        private Mock<ISiteSettings> siteSettings;
        private HeaderViewComponent headerViewComponent;

        [SetUp]
        public void SetUp()
        {
            this.siteSettings = new Mock<ISiteSettings>();
            this.headerViewComponent = new HeaderViewComponent(this.siteSettings.Object);
        }

        [Test]
        [TestCase("siteName")]
        [TestCase("Umbraco 9 Demo")]
        public void Given_SiteSettingsHasSiteName_When_Invoke_Then_ReturnViewModelWithHeading(string siteName)
        {
            this.siteSettings.Setup(x => x.SiteName).Returns(siteName);

            var model = (HeaderViewModel)((ViewViewComponentResult)this.headerViewComponent.Invoke(0)).ViewData.Model;

            Assert.AreEqual(siteName, model.Heading);
        }

        [Test]
        [TestCase(1)]
        [TestCase(12)]
        public void Given_SelectedParameter_When_Invoke_Then_ReturnViewModelWithSelectedValue(int selected)
        {
            var model = (HeaderViewModel)((ViewViewComponentResult)this.headerViewComponent.Invoke(selected)).ViewData.Model;

            Assert.AreEqual(selected, model.Selected);
        }
    }
}
