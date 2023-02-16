using AutoFixture;
using SimpleInjector;
using UnitTestProject1.Services;

namespace SitecoreDev.Feature.Media.Tests
{
    public abstract class TestHarnessBase : ITestHarness
    {
        protected Container _container = new Container();
        protected IFixture _fixture;
        public IFixture Fixture { get { return _fixture; } }
    }
}
