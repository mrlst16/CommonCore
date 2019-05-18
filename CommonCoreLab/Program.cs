using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommonCore.IOC;
using CommonCoreLab.Services;
using CommonCoreLab.Services.Interfaces;
using System;

namespace CommonCoreLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Setup
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<GoldenRetriver>().As<IDog>();
            builder.RegisterType<KibblesNBits>().As<ITreat>();
            var container = builder.Build();
            KeyedDependencyResolver.InitDefault(new AutofacServiceProvider(container.BeginLifetimeScope()));

            var builder2 = new ContainerBuilder();
            builder2.RegisterType<MintyTreat>().As<ITreat>();
            var container2 = builder2.Build();

            KeyedDependencyResolver.AddServiceProvider(new AutofacServiceProvider(container2.BeginLifetimeScope()), "puppies");

            //Resolves Default
            IDog dog = KeyedDependencyResolver.Instance.GetService<IDog>();
            Console.WriteLine(dog.Speak());
        }
    }
}
