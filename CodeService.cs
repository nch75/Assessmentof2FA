using Microsoft.Extensions.Options;
using TwoFactorService.Model;

namespace TwoFactorService
{
    public class CodeService
    {
      
        private readonly CodeSettings _settings;
        public CodeService(IOptions<CodeSettings> settings)
        {
            
            _settings = settings.Value;
        }

    }
}
