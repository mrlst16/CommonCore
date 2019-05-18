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
        public int SeekOrder { get; set; } = -1;

        public override bool Equals(object obj)
        {
            if (!(obj is KeyedServiceProvider)) return false;

            var kdr = obj as KeyedServiceProvider;

            return kdr.Key == Key;
        }
    }


    public class KeyedDependencyResolver
    {
        #region Static
        private static KeyedDependencyResolver _instance;

        public static KeyedDependencyResolver Instance
        {
            get
            {
                if (_instance == null)
                    throw new Exception("KeyedDependencyResolver not initialized. You should initialize it in Startup class");
                return _instance;
            }
        }

        public static void InitDefault(IServiceProvider serviceProvider)
        {
            _instance = new KeyedDependencyResolver();
            _instance.AddServiceProvider(new KeyedServiceProvider()
            {
                Key = "default",
                ServiceProvider = serviceProvider,
                SeekOrder = 0
            });
        }

        public static void AddServiceProvider(IServiceProvider serviceProvider, string key)
        {
            _instance.AddServiceProvider(new KeyedServiceProvider()
            {
                Key = key,
                ServiceProvider = serviceProvider,
                SeekOrder = _instance.AvailableServiceProviders.Count
            });
        }

        public static T GetDefaultService<T>()
            where T : class
        {
            return Instance.GetService<T>("default");
        }
        #endregion

        List<KeyedServiceProvider> AvailableServiceProviders { get; set; } = new List<KeyedServiceProvider>();

        protected IServiceProvider this[string key]
        {
            get
            {
                return AvailableServiceProviders.FirstOrDefault(x => x.Key == key)?.ServiceProvider
                  ?? AvailableServiceProviders.FirstOrDefault(x => x.Key == "default")?.ServiceProvider
                    ?? null;
            }
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

        public T GetService<T>(string key = "default")
            where T : class
        {
            return Seek<T>(key);
        }

        private T Seek<T>(string key = "default")
            where T : class
        {
            var firstChoice = AvailableServiceProviders.FirstOrDefault(x => x.Key == key);
            if (firstChoice == null && key == "default") return null;

            T result = firstChoice.ServiceProvider.GetService<T>();
            if (result != null) return result;

            var keyedServiceProvidersOrdered = AvailableServiceProviders.OrderBy(x => x.SeekOrder).ToList();
            for (int i = 0; i < keyedServiceProvidersOrdered.Count(); i++)
            {
                var ksp = keyedServiceProvidersOrdered[i];
                result = ksp.ServiceProvider.GetService<T>();
                if (result != null) return result;
            }

            return result;
        }

        private KeyedDependencyResolver()
        {
        }

        private void AddServiceProvider(KeyedServiceProvider keyedServiceProvider)
        {
            if (AvailableServiceProviders.Contains(keyedServiceProvider))
                AvailableServiceProviders.Remove(keyedServiceProvider);
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
