using CommonCore.IOC;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLab.Helpers
{
    public static class DependencyResolverExtensions
    {
        public static T FromPuppies<T>(this KeyedDependencyResolver resolver)
            where T : class
        {
            return resolver.GetService<T>("puppies");
        }
    }
}
