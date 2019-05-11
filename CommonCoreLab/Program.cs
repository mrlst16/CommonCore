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

            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<GoldenRetriver>().As<IDog>();
            var container = builder.Build();
            KeyedDependencyResolver.InitDefault(new AutofacServiceProvider(container.BeginLifetimeScope()));


            IDog dog = KeyedDependencyResolver.GetDefaultService<IDog>();
            Console.WriteLine(dog.Speak());
        }
    }
}
