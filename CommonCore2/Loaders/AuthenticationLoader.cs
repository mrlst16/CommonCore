using CommonCore.Interfaces.Loaders;
using CommonCore.Interfaces.Repository;
using CommonCore.Models.Authentication;
using CommonCore.Models.Responses;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore2.Loaders
{
    public class AuthenticationLoader : IAuthenticationLoader
    {
        public int Iterations { get; set; } = 10;
        public int SaltLength { get; set; } = 20;
        public int HashLength { get; set; } = 50;

        private readonly ICrudRepository<PasswordRecord> _passwordsRepository;

        public AuthenticationLoader(
            ICrudRepository<PasswordRecord> passwordsRepository
            )
        {
            _passwordsRepository = passwordsRepository;
        }

        public AuthenticationLoader(
            ICrudRepository<PasswordRecord> passwordsRepository,
            IConfiguration configuration
            ) : this(passwordsRepository)
        {
            var iterationsSettings = configuration.GetValue<int>("AppSettings:Authorization:Iterations");
            var saltLengthSettings = configuration.GetValue<int>("AppSettings:Authorization:SaltLength");
            var hashLengthSettings = configuration.GetValue<int>("AppSettings:Authorization:HashLength");

            if (iterationsSettings > 0) Iterations = iterationsSettings;
            if (saltLengthSettings > 0) SaltLength = saltLengthSettings;
            if (hashLengthSettings > 0) HashLength = hashLengthSettings;
        }

        public async Task<IResponse> SetupPassword(PasswordRequest request)
        {
            var (passwordHash, salt) = GenerateHash(request.Password, SaltLength, HashLength, Iterations);

            var record = new PasswordRecord()
            {
                PasswordHash = passwordHash,
                Salt = salt,
                Iterations = Iterations,
                UserName = request.UserName,
                HashLength = HashLength
            };

            await _passwordsRepository.Create(record);

            return new MethodRespsonse()
            {
                Sucess = true,
                Errors = new List<ErrorResponse>()
            };
        }

        private byte[] GenerateSalt(int length)
        {
            byte[] result = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(result);
            }
            return result;
        }

        private byte[] GenerateHash(byte[] password, byte[] salt, int length, int iterations = 100)
        {
            byte[] result = new byte[length];

            using (var derviedBytes = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                result = derviedBytes.GetBytes(length);
            }

            return result;
        }

        private byte[] GenerateHash(string password, byte[] salt, int length, int iterations = 100)
            => GenerateHash(UTF8Encoding.UTF8.GetBytes(password), salt, length, iterations);

        private (byte[], byte[]) GenerateHash(string password, int saltLength, int hashLength, int iterations = 100)
        {
            var salt = GenerateSalt(saltLength);
            return (GenerateHash(password, salt, hashLength, iterations), salt);
        }

        public async Task<IResponse<PasswordRecord>> Authenticate(PasswordRequest request)
        {
            var response = new MethodResponse<PasswordRecord>();

            response.Data = (await _passwordsRepository.Read(x => x.UserName == request.UserName))?.FirstOrDefault();
            if (response.Data == null)
            {
                response.Sucess = false;
                response.Errors = new List<ErrorResponse>()
                {
                    new ErrorResponse(){ Message = $"Could not find user with username {request.UserName}"}
                };
                return response;
            }

            var requestHash = GenerateHash(request.Password, response.Data.Salt, response.Data.HashLength, response.Data.Iterations);
            response.Sucess = requestHash == response.Data.PasswordHash;
            
            if (!response.Sucess)
            {
                response.Data = null;
                response.Errors = new List<ErrorResponse>()
                {
                    new ErrorResponse(){ Message = $"Could not validate user with username {request.UserName}"}
                };
                return response;
            }

            return response;
        }
    }
}
