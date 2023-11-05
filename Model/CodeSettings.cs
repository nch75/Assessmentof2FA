namespace TwoFactorService.Model
{
    public class CodeSettings
    {
        public int CodeLifetime { get; set; }
        public int MaxConcurrentCodes { get; set; }
    }
}
