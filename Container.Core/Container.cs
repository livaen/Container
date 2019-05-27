using System;
using System.Collections.Generic;
using System.Linq;

namespace Container.Core
{
    public class Container
    {
        private readonly Dictionary<Type, Func<object>> _registeredInstances = new Dictionary<Type, Func<object>>();

        public void RegisterInstance<Interface, Implementation>() where Implementation : Interface
        {
            _registeredInstances.Add(typeof(Interface), () => GetInstance(typeof(Implementation)));            
        }

        public void RegisterSingleton<Implementation>(Implementation instance)
        {
            _registeredInstances.Add(typeof(Implementation), () => instance);
        }

        public object GetInstance(Type type)
        {
            if (_registeredInstances.TryGetValue(type, out Func<object> creator)) return creator();
            else if (!type.IsAbstract) return CreateInstance(type);
            else throw new Exception("Service is not registred");
        }

        private object CreateInstance(Type type)
        {
            var constructors = type.GetConstructors().OrderByDescending(x => x.GetParameters().Length)
                .FirstOrDefault();

            var parameters = constructors.GetParameters();
            var dependencies = parameters
                .Select(p => p.ParameterType)
                .Select(x => GetInstance(x))
                .ToArray();

            return Activator.CreateInstance(type, dependencies);
        }
    }
}
