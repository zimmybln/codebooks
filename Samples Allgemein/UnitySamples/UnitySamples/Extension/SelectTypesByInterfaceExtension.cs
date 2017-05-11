using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitySamples.Extension
{
    public class SelectTypesByInterfaceExtension : UnityContainerExtension
    {
        private readonly Type _interfaceType;

        public SelectTypesByInterfaceExtension(Type interfaceType)
        {
            _interfaceType = interfaceType;
        }

        protected override void Initialize()
        {
            var implementationTypes = this.GetType().Assembly.GetExportedTypes()
                           .Where(x => x.IsClass && _interfaceType.IsAssignableFrom(x));

            foreach (Type implementationType in implementationTypes)
            {
                // IMPORTANT: Give each instance a name, or else Unity won't be able
                // to resolve the collection.
                this.Container.RegisterType(_interfaceType, implementationType,
                    implementationType.Name, new ContainerControlledLifetimeManager());
            }
        }

        
    }
}
