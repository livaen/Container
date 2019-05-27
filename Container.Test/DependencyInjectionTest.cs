using Container.Test.TestHelpers.TestClasses;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Container.Test
{
    [TestFixture]
    public class DependencyInjectionTest
    {
        private Core.Container _container;

        [SetUp]
        public void Setup()
        {
            _container = new Core.Container();
        }

        [Test]
        public void ShouldCreateInstanceWithParameterlessConstructor()
        {
            var testClass = _container.GetInstance(typeof(ParameterlessTestClass));
            Assert.IsInstanceOf<ParameterlessTestClass>(testClass);
        }

        [Test]
        public void ShouldCreateInstanceWithDependencies()
        {
            var testClass = (WithDependenciesTestClass)_container.GetInstance(typeof(WithDependenciesTestClass));
            var dependencies = testClass.ParameterlessTestClass;

            Assert.IsNotNull(dependencies);
            Assert.IsInstanceOf<WithDependenciesTestClass>(testClass);
        }

        [Test]
        public void ShouldCreateInstanceByInterface()
        {
            _container.RegisterInstance<TestInterface, ClassImplementingTestInterface>();
            var testClass = _container.GetInstance(typeof(TestInterface));
            Assert.IsInstanceOf<ClassImplementingTestInterface>(testClass);
        }

        [Test]
        public void ShouldCreateSingleton()
        {
            var testClass = new ParameterlessTestClass();
            _container.RegisterSingleton(testClass);
            var resolvedTestClass = _container.GetInstance(typeof(ParameterlessTestClass));

            Assert.AreEqual(testClass, resolvedTestClass);
        }

        [Test]
        public void ShouldCreateInstanceWithInterfaceDependencies()
        {
            _container.RegisterInstance<TestInterface, ClassImplementingTestInterface>();
            var instance = (WithInterfaceDependenciesTestClass)_container.GetInstance(typeof(WithInterfaceDependenciesTestClass));

            Assert.IsNotNull(instance.TestInterface);
        }

    }
}
