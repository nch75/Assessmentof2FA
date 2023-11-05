using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using TwoFactorService.Model;

namespace TwoFactorService
{
    public class CodeService
    {
      
        private readonly CodeSettings _settings;
        private readonly IMemoryCache _cache;
        public CodeService(IOptions<CodeSettings> settings , IMemoryCache cache)
        {
            
            _settings = settings.Value;
            _cache = cache;
        }
        public string GenerateCode(string phone)
        {
            var existingCodes = _cache.TryGetValue<List<string>>(phone, out var codes) ? codes : new List<string>();

            if (existingCodes?.Count >= _settings.MaxConcurrentCodes)
            {
                return null;
            }

            var newCode = new Random().Next(100000, 999999).ToString();
            existingCodes?.Add(newCode);
            _cache.Set(phone, existingCodes, TimeSpan.FromSeconds(_settings.CodeLifetime));

            Console.WriteLine($"Generated code for {phone}: {newCode}");  // Logging the code for debugging

            return newCode;
        }

        public bool ValidateCode(string phone, string code)
        {
            if (_cache.TryGetValue<List<string>>(phone, out var codes))
            {
                return codes.Contains(code);
            }
            return false;
        }

    }
}
