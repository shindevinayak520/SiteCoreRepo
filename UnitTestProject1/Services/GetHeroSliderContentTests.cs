using System;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sitecore.Data;
using Sitecore.FakeDb;
using SitecoreDev.Feature.Media.Models;
using SitecoreDev.Feature.Media.Services;
using SitecoreDev.Feature.Media.Tests;
using SitecoreDev.Feature.Media.Tests.Services;
using SitecoreDev.Feature.Media.ViewModels;
using SitecoreDev.Foundation.Repository.Content;

namespace UnitTestProject1.Services
{
    [TestClass]
    public class UnitTest1 : TestBase<ServiceTestHarness>
    {
        [TestMethod]
        public void GetHeroSliderContentSuccessful()
        {
            //Arrange
            var fixture = new Fixture();
            var heroSlide = fixture
            .Build<HeroSlider>()
            .Without(x => x.Slides)
            .Create();
            var children = fixture
            .CreateMany<HeroSliderSlide>()
            .ToList();
            var repository = new Mock<IContentRepository>();
            repository
            .Setup(x => x.GetContentItem<IHeroSlider>(It.IsAny<string>()))
            .Returns(heroSlide)
            .Verifiable();
            repository
            .Setup(x => x.GetChildren<IHeroSliderSlide>(It.IsAny<string>()))
            .Returns(children)
            .Verifiable();
            var service = new SitecoreMediaContentService(repository.Object);
            //Act
            var result = service.GetHeroSliderContent("123");
            //Assert
            repository.Verify();
            //result.Should().NotBeNull();
            AssertionExtensions.Should(result).NotBeNull();
            result.Slides.Should().NotBeNullOrEmpty();
            result.Slides.Count().Should().Be(children.Count());
            var slides = result.Slides.ToList();
            foreach (var slide in slides)
            AssertionExtensions.Should(slide.Image).NotBeNull();
        }

        [TestMethod]
        public void GetHeroSliderContentEmptyContentGuid()
        {
             //Arrange
             var contentGuidNullException = new ArgumentNullException("contentGuid");
             var parentGuidNullException = new ArgumentNullException("parentGuid");
             var repository = new Mock<IContentRepository>();
             repository
             .Setup(x => x.GetContentItem<IHeroSlider>(String.Empty))
             .Throws(contentGuidNullException);
             repository
             .Setup(x => x.GetChildren<IHeroSliderSlide>(String.Empty))
             .Throws(parentGuidNullException);
             var service = new SitecoreMediaContentService(repository.Object);
             //Act
             var result = service.GetHeroSliderContent(String.Empty);
                        //Assert
             AssertionExtensions.Should(result).BeNull();
                        //result.Should().BeNull();
        }


        [TestMethod]
        public void GetHeroSliderContentSuccessful2()
        {
            //Arrange
            var heroSlide = _testHarness.Fixture
            .Build<HeroSlider>()
            .Without(x => x.Slides)
            .Create();
            var children = _testHarness.Fixture
            .CreateMany<HeroSliderSlide>()
            .ToList();
            _testHarness.ContentRepository
            .Setup(x => x.GetContentItem<IHeroSlider>(It.IsAny<string>()))
            .Returns(heroSlide)
            .Verifiable();
            _testHarness.ContentRepository
            .Setup(x => x.GetChildren<IHeroSliderSlide>(It.IsAny<string>()))
            .Returns(children)
            .Verifiable();
            //Act
            var result = _testHarness.ContentService.GetHeroSliderContent("123");
            //Assert
            _testHarness.ContentRepository.Verify();
            AssertionExtensions.Should(result).NotBeNull();
            result.Slides.Should().NotBeNullOrEmpty();
            result.Slides.Count().Should().Be(children.Count());
            var slides = result.Slides.ToList();
            foreach (var slide in slides)
                AssertionExtensions.Should(slide.Image).NotBeNull();
        }

        [TestMethod]
        public void GetHeroSliderContentEmptyContentGuid2()
        {
            //Arrange
            var contentGuidNullException = new ArgumentNullException("contentGuid");
            var parentGuidNullException = new ArgumentNullException("parentGuid");
            _testHarness.ContentRepository
            .Setup(x => x.GetContentItem<IHeroSlider>(String.Empty))
            .Throws(contentGuidNullException);
            _testHarness.ContentRepository
            .Setup(x => x.GetChildren<IHeroSliderSlide>(String.Empty))
            .Throws(parentGuidNullException);
            //Act
            var result = _testHarness.ContentService.GetHeroSliderContent(String.Empty);
            //Assert
            AssertionExtensions.Should(result).BeNull();
        }

        [TestMethod]
        public void TestGetItemTitle()
        {
            // Arrange
            string expectedTitle = "Hello World!";
            using (Db db = new Db
            {
                new DbItem("Home") { { "Title", expectedTitle } }
            });
                SitecoreHelpers sut = new SitecoreHelpers();
            // Act
            var result = sut.GetItemTitle("/sitecore/content/Home");
            // Assert
            result.Should().Be(expectedTitle);
        }

        [TestMethod]
        public void TestChildItems()
        {
            // Arrange
            string expectedParentTitle = "Hello Son!";
            string expectedChildTitle = "Hello Dad!";
            using (Db db = new Db
           {
                new DbItem("Home")
                {
                    { "Title", expectedParentTitle },
                    new DbItem("Child") { { "Title", expectedChildTitle } }
                }
           }) ;
                    SitecoreHelpers sut = new SitecoreHelpers();
                   // Act
                var result = sut.GetItemTitle("/sitecore/content/Home");
                var childResult = sut.GetItemTitle("/sitecore/content/Home/child");
                // Assert
                result.Should().Be(expectedParentTitle);
                childResult.Should().Be(expectedChildTitle);
        }
    }
}
