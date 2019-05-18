using CommonCore.IOC;
using CommonCoreLab.Helpers;
using CommonCoreLab.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLab.Services
{
    public class GoldenRetriver : IDog
    {
        protected ITreat Treat = KeyedDependencyResolver.Instance.FromPuppies<ITreat>();
        public string Speak()
        {
            return $"I am a golden retriever: I have a treat, it's {Treat.Name}";
        }
    }
}
