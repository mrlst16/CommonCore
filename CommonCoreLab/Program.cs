using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommonCore.IOC;
using CommonCoreLab.Services;
using CommonCoreLab.Services.Interfaces;
using System;
using System.Reflection;

namespace CommonCoreLab
{

    public class LoggingDecorator<T> : DispatchProxy
    {
        private T _decorated;

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            try
            {
                LogBefore(targetMethod, args);

                var result = targetMethod.Invoke(_decorated, args);

                LogAfter(targetMethod, args, result);
                return result;
            }
            catch (Exception ex) when (ex is TargetInvocationException)
            {
                LogException(ex.InnerException ?? ex, targetMethod);
                throw ex.InnerException ?? ex;
            }
        }

        public static T Create(T decorated)
        {
            object proxy = Create<T, LoggingDecorator<T>>();
            ((LoggingDecorator<T>)proxy).SetParameters(decorated);

            return (T)proxy;
        }

        private void SetParameters(T decorated)
        {
            if (decorated == null)
            {
                throw new ArgumentNullException(nameof(decorated));
            }
            _decorated = decorated;
        }

        private void LogException(Exception exception, MethodInfo methodInfo = null)
        {
            Console.WriteLine($"Class {_decorated.GetType().FullName}, Method {methodInfo.Name} threw exception:\n{exception}");
        }

        private void LogAfter(MethodInfo methodInfo, object[] args, object result)
        {
            Console.WriteLine($"Class {_decorated.GetType().FullName}, Method {methodInfo.Name} executed, Output: {result}");
        }

        private void LogBefore(MethodInfo methodInfo, object[] args)
        {
            Console.WriteLine($"Class {_decorated.GetType().FullName}, Method {methodInfo.Name} is executing");
        }
    }

    //class LoggingWrapper<T> : DispatchProxy
    //{

    //    public LoggingWrapper(T decorated)
    //    {

    //    }

    //    protected override object Invoke(MethodInfo targetMethod, object[] args)
    //    {
    //        return null;
    //    }


    //}

    class Program
    {
        static void Main(string[] args)
        {
            //Setup
            //ContainerBuilder builder = new ContainerBuilder();
            //builder.RegisterType<GoldenRetriver>().As<IDog>();
            //builder.RegisterType<KibblesNBits>().As<ITreat>();
            //var container = builder.Build();
            //KeyedDependencyResolver.InitDefault(new AutofacServiceProvider(container.BeginLifetimeScope()));

            //var builder2 = new ContainerBuilder();
            //builder2.RegisterType<MintyTreat>().As<ITreat>();
            //var container2 = builder2.Build();

            //KeyedDependencyResolver.AddServiceProvider(new AutofacServiceProvider(container2.BeginLifetimeScope()), "puppies");

            ////Resolves Default
            //IDog dog = KeyedDependencyResolver.Instance.GetService<IDog>();
            //Console.WriteLine(dog.Speak());


            
        }
    }
}
