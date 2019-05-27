namespace Container.Test.TestHelpers.TestClasses
{
    public class WithDependenciesTestClass
    {
        public ParameterlessTestClass ParameterlessTestClass { get; }
       // public WithDependenciesTestClass _WithDependenciesTest { get; set; }
        public WithDependenciesTestClass2 WithDependenciesTestClass2 { get; }

        public WithDependenciesTestClass(ParameterlessTestClass testClass, WithDependenciesTestClass2 withDependenciesTestClass2)
        {
            ParameterlessTestClass = testClass;
          //  _WithDependenciesTest = withDependenciesTestClass;
            WithDependenciesTestClass2 = withDependenciesTestClass2;
        }
    }
}
