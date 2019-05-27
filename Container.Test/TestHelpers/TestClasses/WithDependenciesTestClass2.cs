using System;
using System.Collections.Generic;
using System.Text;

namespace Container.Test.TestHelpers.TestClasses
{
    public class WithDependenciesTestClass2
    {
        public ParameterlessTestClass TestClass { get; }

        public WithDependenciesTestClass2(ParameterlessTestClass testClass)
        {
            TestClass = testClass;
        }
    }
}
