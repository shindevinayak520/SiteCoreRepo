using AutoFixture;
using FluentAssertions;
using Glass.Mapper.Sc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SitecoreDev.Feature.Media.Controllers;
using SitecoreDev.Feature.Media.Models;
using SitecoreDev.Feature.Media.Services;
using SitecoreDev.Feature.Media.ViewModels;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace UnitTestProject1.Controllers
{
    [TestClass]
    public class HeroSliderTests
    {
        [TestMethod]
        public void HeroSliderSuccessful()
        {
            //Arrange
            var fixture = new Fixture();
            var content = fixture.Build<HeroSlider>()
            .With(x => x.Slides, fixture.CreateMany<HeroSliderSlide>().ToList())
            .Create();
            var contentService = new Mock<SitecoreMediaContentService>();
            contentService.Setup(x => x.GetHeroSliderContent(It.IsAny<string>()))
            .Returns(content)
            .Verifiable();
            //var contextWrapper = new Mock<IContextWrapper>();
            //contextWrapper.Setup(x => x.GetParameterValue(It.IsAny<string>()))
            //.Returns("500")
            //.Verifiable();
            //contextWrapper.SetupGet(x => x.IsExperienceEditor)
            //.Returns(true)
            //.Verifiable();
            var glassHtml = new Mock<IGlassHtml>();
            glassHtml.Setup(x => x.Editable(
            It.IsAny<IHeroSliderSlide>(),
            It.IsAny<Expression<Func<IHeroSliderSlide, object>>>(),
            It.IsAny<object>()))
            .Returns("test")
            .Verifiable();
            var controller = new MediaController();
            //Act
            var result = controller.HeroSlider();
            //Assert
            AssertionExtensions.Should(result).NotBeNull();
            result.Model.Should().BeOfType<HeroSliderViewModel>();
            var viewModel = result.Model as HeroSliderViewModel;
            AssertionExtensions.Should(viewModel).NotBeNull();
        }
    }
}
