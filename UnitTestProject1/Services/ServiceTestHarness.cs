using AutoFixture;
using Moq;
using SimpleInjector;
using SitecoreDev.Feature.Media.Services;
using SitecoreDev.Foundation.Repository.Content;
namespace SitecoreDev.Feature.Media.Tests.Services
{
    public class ServiceTestHarness : TestHarnessBase
    {
        private Mock<IContentRepository> _contentRepository;
        public Mock<IContentRepository> ContentRepository
        {
            get
            {
                if (_contentRepository == null)
                    _contentRepository =
                    Mock.Get(_container.GetInstance<IContentRepository>());
                return _contentRepository;
            }
        }
        private SitecoreMediaContentService _contentService;
        public SitecoreMediaContentService ContentService
        {
            get
            {
                if (_contentService == null)
                    _contentService = _container.GetInstance<SitecoreMediaContentService>();
                return _contentService;
            }
        }
        public ServiceTestHarness()
         {
            InitializeContainer();
            _fixture = new Fixture();
         }
         protected void InitializeContainer()
         {
            _container.Register<IContentRepository>(() =>
            new Mock<IContentRepository>().Object, Lifestyle.Singleton);
            _container.Register<SitecoreMediaContentService>(Lifestyle.Transient);
         }
         }
}
