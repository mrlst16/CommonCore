using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Interfaces.Helpers
{
    public interface IApplicationHelper
    {
        byte[] GetBytes(string str);
        string GetString(byte[] bytes);
    }
}
