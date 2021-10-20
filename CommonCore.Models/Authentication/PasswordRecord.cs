using System.Collections.Generic;
using System.Security.Claims;

namespace CommonCore.Models.Authentication
{
    public class PasswordRecord
    {
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }
        public int Iterations { get; set; }
        public int HashLength { get; set; }
        public List<Claim> Claims { get; set; } = new List<Claim>();
    }
}
