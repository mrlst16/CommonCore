using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonCore.IOC
{
    class KeyedServiceProvider
    {
        public string Key { get; protected internal set; }
        public IServiceProvider ServiceProvider { get; protected internal set; }
    }


    public class KeyedDependencyResolver
    {
        #region Static
        private static KeyedDependencyResolver _resolver;

        public static KeyedDependencyResolver Instance
        {
            get
            {
                if (_resolver == null)
                    throw new Exception("KeyedDependencyResolver not initialized. You should initialize it in Startup class");
                return _resolver;
            }
        }

        public static void InitDefault(IServiceProvider serviceProvider)
        {
            _resolver = new KeyedDependencyResolver();
            _resolver.AddServiceProvider(new KeyedServiceProvider()
            {
                Key = "default",
                ServiceProvider = serviceProvider
            });
        }

        public static void AddServiceProvider(IServiceProvider serviceProvider, string key)
        {
            _resolver.AddServiceProvider(new KeyedServiceProvider()
            {
                Key = key,
                ServiceProvider = serviceProvider
            });
        }

        public static T GetDefaultService<T>()
        {
            return Instance.GetService<T>();
        }
        #endregion

        List<KeyedServiceProvider> AvailableServiceProviders { get; set; } = new List<KeyedServiceProvider>();

        public IServiceProvider this[string key]
        {
            get { return AvailableServiceProviders.FirstOrDefault(x => x.Key == key)?.ServiceProvider ?? null; }
            set
            {
                var existing = this.AvailableServiceProviders.FirstOrDefault();
                if (existing != null)
                    AvailableServiceProviders.Remove(existing);

                this.AddServiceProvider(new KeyedServiceProvider()
                {
                    Key = key,
                    ServiceProvider = value
                });
            }
        }

        public IServiceProvider Default => this["default"];

        public T GetService<T>()
        {
            return (T)Default.GetService(typeof(T));
        }

        private KeyedDependencyResolver()
        {
        }

        private void AddServiceProvider(KeyedServiceProvider keyedServiceProvider)
        {
            AvailableServiceProviders.Add(keyedServiceProvider);
        }
    }

    public static class Extensions
    {
        public static T GetService<T>(this IServiceProvider serviceProvider)
        {
            return (T)serviceProvider.GetService(typeof(T));
        }
    }

}
