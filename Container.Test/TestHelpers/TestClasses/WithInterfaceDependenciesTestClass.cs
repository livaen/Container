namespace Container.Test.TestHelpers.TestClasses
{
    public class WithInterfaceDependenciesTestClass
    {
        public TestInterface TestInterface { get; }

        public WithInterfaceDependenciesTestClass(TestInterface testInterface)
        {
            TestInterface = testInterface;
        }
    }
}
