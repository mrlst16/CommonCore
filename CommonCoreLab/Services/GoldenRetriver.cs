using CommonCoreLab.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreLab.Services
{
    public class GoldenRetriver : IDog
    {
        public string Speak()
        {
            return "I am a golden retriever";
        }
    }
}
